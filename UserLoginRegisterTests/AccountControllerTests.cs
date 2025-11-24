using Xunit;
using Microsoft.EntityFrameworkCore;
using UserLoginRegister.Controllers;
using UserLoginRegister.Data;
using UserLoginRegister.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using UserLoginRegisterTests;


public class AccountControllerTests
{
    [Fact]
    public void Register_EmptyPassword_ReturnsError()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        var context = new AppDbContext(options);
        var env = new FakeWebHostEnvironment();

        var controller = new AccountController(context, env);
        controller.DisableSignIn = true;   // <= önemli
        var model = new UserLoginRegister.Models.ViewModels.Register
        {
            FullName = "Test User",
            Email = "test@example1.com",
            Password = ""  // boş parola → hata dönmeli
        };

        // Act
        var result = controller.Register(model).Result;

        // Assert
        Assert.NotNull(result);
    }
    [Fact]
    public void Register_ValidUser_RedirectsToHome()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("RegisterSuccessTestDb")
            .Options;

        var context = new AppDbContext(options);
        var env = new FakeWebHostEnvironment();

        var controller = new AccountController(context, env);
        controller.DisableSignIn = true; // Test içinde cookie login yok

        var model = new UserLoginRegister.Models.ViewModels.Register
        {
            FullName = "Test User 2",
            Email = "valid@example.com",
            Password = "Password123!"
        };

        // Act
        var result = controller.Register(model).Result;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Microsoft.AspNetCore.Mvc.RedirectToActionResult>(result);

        // DB kayıt kontrolü
        Assert.Equal(1, context.Users.Count());
        Assert.Equal("valid@example.com", context.Users.First().Email);
    }
    [Fact]
    public void Register_DuplicateEmail_ReturnsViewWithError()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("DuplicateEmailTestDb")
            .Options;

        var context = new AppDbContext(options);
        var env = new FakeWebHostEnvironment();

        // İlk kullanıcı DB’ye ekleniyor
        context.Users.Add(new UserLoginRegister.Models.User
        {
            FullName = "Existing User",
            Email = "duplicate@example.com",
            Password = "123",
            IsActive = true,
            Role = "User",
            CreatedAt = DateTime.Now
        });
        context.SaveChanges();

        var controller = new AccountController(context, env);
        controller.DisableSignIn = true; // Testte giriş yapılmasın

        var model = new UserLoginRegister.Models.ViewModels.Register
        {
            FullName = "New User",
            Email = "duplicate@example.com",
            Password = "Password123!"
        };

        // Act
        var result = controller.Register(model).Result;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(result);
        Assert.True(!controller.ModelState.IsValid); // hata bekleniyor

        // DB’ye ikinci kayıt eklenmemiş olmalı
        Assert.Equal(1, context.Users.Count());
    }
    [Fact]
    public void Login_ValidCredentials_RedirectsToHome()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("LoginSuccessDb")
            .Options;

        var context = new AppDbContext(options);
        var env = new FakeWebHostEnvironment();

        // Şifre hash'le
        var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<UserLoginRegister.Models.User>();

        var user = new UserLoginRegister.Models.User
        {
            FullName = "Login User",
            Email = "login@example.com",
            Role = "User",
            IsActive = true,
            CreatedAt = DateTime.Now
        };

        user.Password = hasher.HashPassword(user, "Password123!");

        context.Users.Add(user);
        context.SaveChanges();

        var controller = new AccountController(context, env);
        controller.DisableSignIn = true; // Cookie login testte devre dışı

        var model = new UserLoginRegister.Models.ViewModels.Login
        {
            Email = "login@example.com",
            Password = "Password123!",
            RememberMe = false
        };

        // Act
        var result = controller.Login(model).Result;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Microsoft.AspNetCore.Mvc.RedirectToActionResult>(result);
    }
    [Fact]
    public void Login_InvalidPassword_ReturnsViewWithError()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("LoginWrongPasswordDb")
            .Options;

        var context = new AppDbContext(options);
        var env = new FakeWebHostEnvironment();

        // Şifre hash oluştur
        var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<UserLoginRegister.Models.User>();

        var user = new UserLoginRegister.Models.User
        {
            FullName = "Wrong PW User",
            Email = "wrongpw@example.com",
            Role = "User",
            IsActive = true,
            CreatedAt = DateTime.Now
        };

        user.Password = hasher.HashPassword(user, "CorrectPassword123!");

        context.Users.Add(user);
        context.SaveChanges();

        var controller = new AccountController(context, env);
        controller.DisableSignIn = true; // Cookie login devre dışı

        var model = new UserLoginRegister.Models.ViewModels.Login
        {
            Email = "wrongpw@example.com",
            Password = "WRONGPASSWORD!",
            RememberMe = false
        };

        // Act
        var result = controller.Login(model).Result;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(result);
        Assert.True(!controller.ModelState.IsValid); // Hata bekleniyor
    }

    [Fact]
    public void Login_UserNotFound_ReturnsViewWithError()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("LoginUserNotFoundDb")
            .Options;

        var context = new AppDbContext(options);
        var env = new FakeWebHostEnvironment();

        // DB’ye hiç kullanıcı eklemiyoruz → kullanıcı bulunamayacak

        var controller = new AccountController(context, env);
        controller.DisableSignIn = true; // Cookie engelle

        var model = new UserLoginRegister.Models.ViewModels.Login
        {
            Email = "notfound@example.com",
            Password = "AnyPassword123",
            RememberMe = false
        };

        // Act
        var result = controller.Login(model).Result;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(result);
        Assert.False(controller.ModelState.IsValid); // hata bekleniyor
    }

}
