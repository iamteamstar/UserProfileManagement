# UserLoginRegister – ASP.NET Core MVC Kullanıcı Yönetim Sistemi

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş **kapsamlı bir kullanıcı yönetimi, rol sistemi, admin paneli, profil yönetimi ve birim test altyapısına sahip** tam fonksiyonel bir web uygulamasıdır.

Proje; kullanıcı kayıt/giriş işlemleri, admin kontrol paneli, kullanıcı filtreleme, profil düzenleme, gelişmiş dashboard grafikleri ve birim testleri (XUnit) gibi modern özellikler içerir.

---

##  Proje Ekran Görüntüleri

> Aşağıdaki bölümlere kendi ekran görüntülerini eklemelisin.

###  **Giriş Ekranı**
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/c602eb4c-97ed-4c85-bb54-d25c55d76684" />



###  **Kayıt Ekranı**
 Buraya kayıt ekranı görseli eklenecek  
**EKLE:**  
`![Register Page](images/register.png)`


###  **Kullanıcı Anasayfası**
 Buraya kullanıcı için görünen ana sayfa eklenecek  
**EKLE:**  
`![Home Page](images/home.png)`


###  **Admin Panel Dashboard**
 Grafikli dashboard görüntüsü  
**EKLE:**  
`![Admin Dashboard](images/admin-dashboard.png)`


###  **Kullanıcı Yönetimi Ekranı**
 Kullanıcı listeleme + arama + filtreleme görselleri  
**EKLE:**  
`![User Management](images/user-management.png)`


###  **Profil Düzenleme Ekranı**
 Kullanıcı profilini düzenleme görseli  
**EKLE:**  
`![Edit Profile](images/edit-profile.png)`

---

#  Proje Özellikleri

##  Kullanıcı İşlevleri
- Kayıt olma  
- Giriş yapma  
- Çıkış yapma  
- Profil görüntüleme  
- Profil düzenleme (ad, email, şifre)  
- Profil resmi yükleme (wwwroot/uploads/profiles)  
- Varsayılan layout üzerinden kişisel navbar gösterimi  

---

##  Admin Paneli Özellikleri

###  Kullanıcı Yönetimi
- Tüm kullanıcıları listeleme  
- Rol bazlı filtreleme (Admin / User)  
- Durum filtreleme (Aktif / Pasif)  
- Arama (isim veya e-posta)  
- Kullanıcı detay sayfası  
- Kullanıcı düzenleme  
- Profil fotoğrafı değiştirme  
- Kullanıcı silme / pasif etme  

###  Admin Dashboard
- Toplam kullanıcı sayısı  
- Aktif kullanıcı sayısı  
- Pasif kullanıcı sayısı  
- Admin sayısı  
- Son 5 kullanıcı listesi  
- Son 7 gün kayıt grafiği (Chart.js)
- Rol dağılımı Pie Chart  
- Aktif/Pasif Bar Chart  

 **Admin ilk login olduğunda otomatik `Admin/Index` sayfasına yönlendirilir.**

---

#  Kullanılan Teknolojiler

| Teknoloji | Amaç |
|----------|------|
| **ASP.NET Core MVC** | Backend & UI |
| **Entity Framework Core** | ORM & Veritabanı |
| **EF Core InMemory** | Test veritabanı |
| **XUnit** | Unit test sistemi |
| **Chart.js** | Dashboard grafikler |
| **Bootstrap 5** | UI düzeni |
| **LINQ** | Filtreleme & sorgular |
| **IWebHostEnvironment** | Dosya yönetimi |
| **Razor Views** | Frontend |

---

#  Proje Dizini

UserLoginRegister
│
├── Controllers
│ ├── AccountController.cs
│ ├── AdminController.cs
│ └── HomeController.cs
│
├── Data
│ └── AppDbContext.cs
│
├── Models
│ ├── User.cs
│ └── ViewModels/
│
├── Views
│ ├── Account/
│ ├── Admin/
│ ├── Home/
│ └── Shared/
│
├── UserLoginRegisterTests (XUnit)
│ ├── AccountControllerTests.cs
│ ├── FakeWebHostEnvironment.cs
│ └── ...
│
└── wwwroot
├── css
├── js
├── lib
└── uploads/profiles/


---

# ✔ Birim Testleri (XUnit)

Test projesi tamamen izole çalışır, gerçek veritabanına dokunmaz.  
**Microsoft.EntityFrameworkCore.InMemory** kullanır.

### Test Edilen Senaryolar

### 🔹 Register() Testleri
- Boş parola → Error
- Boş email → Error
- Geçersiz email → Error
- Aynı email iki kez kayıt → Error
- Doğru kayıt → Başarılı

### 🔹 Login() Testleri
- Yanlış email → Error
- Yanlış parola → Error



### 4. Admin girişi için varsayılan kullanıcı

| Email | Şifre | Rol |
|-------|-------|-----|
| admintest@example.com | Password1+ | Admin |

(Projede ilk çalıştırmada otomatik oluşturulmuş olabilir ya da manuel eklenir.)

---

#  Notlar

- Unit testler tam izole çalışır, test veritabanı gerçek veritabanını etkilemez.  
- Proje tamamen **Clean MVC Architecture** prensiplerine uygundur.

---

#  Lisans

MIT License

---

#  Geliştirici

**Azad Koçak**  
Full Stack Developer  



- Pasif kullanıcı → Error
- Doğru bilgiler → Başarılı login

Test sonucu örneği:

7 Tests — 7 Passed — 0 Failed
