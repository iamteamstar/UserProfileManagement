# UserLoginRegister – ASP.NET Core MVC Kullanıcı Yönetim Sistemi

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş **kapsamlı bir kullanıcı yönetimi, rol sistemi, admin paneli, profil yönetimi ve birim test altyapısına sahip** tam fonksiyonel bir web uygulamasıdır.

Proje; kullanıcı kayıt/giriş işlemleri, admin kontrol paneli, kullanıcı filtreleme, profil düzenleme, gelişmiş dashboard grafikleri ve birim testleri (XUnit) gibi modern özellikler içerir.

---

##  Proje Ekran Görüntüleri


###  **Giriş Ekranı**
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/c602eb4c-97ed-4c85-bb54-d25c55d76684" />



###  **Kayıt Ekranı**
<img width="1918" height="1019" alt="image" src="https://github.com/user-attachments/assets/af4780f2-460b-4baa-9fe5-e65548a570aa" />



###  **Kullanıcı Anasayfası**
 <img width="1914" height="1018" alt="image" src="https://github.com/user-attachments/assets/312cc452-003a-42ca-b38c-ac5e6f7aefda" />



###  **Admin Panel Dashboard**
<img width="1918" height="1018" alt="image" src="https://github.com/user-attachments/assets/9922ef4c-36ab-494e-a4c0-ae66f9544ebb" />
<img width="1919" height="1017" alt="image" src="https://github.com/user-attachments/assets/24614840-32ef-41f1-819a-d52c04306e82" />




###  **Kullanıcı Yönetimi Ekranı**
 
 <img width="1919" height="821" alt="image" src="https://github.com/user-attachments/assets/643ff67b-4b2d-4346-91c2-e74a6f7da9d7" />

###  **Profil Düzenleme Ekranı**

<img width="1915" height="1008" alt="image" src="https://github.com/user-attachments/assets/bd7562fd-3d07-4486-9a65-7f05c7296a83" />


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

<img width="978" height="480" alt="image" src="https://github.com/user-attachments/assets/83c3b4e5-2894-4ebd-abd0-d9da7a7345b2" />


### 4. Admin girişi için varsayılan kullanıcı

| Email | Şifre | Rol |
|-------|-------|-----|
| admintest@example.com | Password1+ | Admin |

(Projede ilk çalıştırmada otomatik oluşturulmuş olabilir ya da manuel eklenir.)

---

#Docker
<img width="1915" height="913" alt="image" src="https://github.com/user-attachments/assets/36e88a30-02c2-44fa-bc8f-a8f34b2c9e0b" />
<img width="1917" height="1007" alt="image" src="https://github.com/user-attachments/assets/4db45eb5-8254-470d-ba9f-c94ad9b9c0cc" />



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
