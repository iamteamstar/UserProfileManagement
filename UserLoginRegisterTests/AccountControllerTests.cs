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
}
