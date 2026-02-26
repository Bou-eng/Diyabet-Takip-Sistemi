# 🩺 Diyabet Takip Sistemi

Bu proje, diyabet hastalarının günlük sağlık verilerini (kan şekeri ölçümleri, diyet, egzersiz ve semptom takibi) kayıt altına alarak hem hastaya hem de doktora düzenli geri bildirim sağlayan bir **masaüstü uygulamasıdır**.

## 🚀 Özellikler

- **Kullanıcı rolleri**
  - 👨‍⚕️ **Doktor**: Hasta ekleme, verileri görüntüleme, öneri girme
  - 🧑‍🦱 **Hasta**: Kan şekeri ölçümü, diyet ve egzersiz raporlama, semptom takibi
- **Şifre güvenliği**: Kullanıcı şifreleri MD5 hash ile veritabanında tutulur
- **Veri tabanı**: PostgreSQL üzerinde normalize edilmiş yapıda tablo ilişkileri
- **Arayüz**: Windows Form (C#)
- **Uyarı sistemi**: Ölçümlere göre otomatik uyarılar ve doktor bilgilendirmesi
- **İnsülin önerisi**: Ortalama kan şekeri değerine göre dozaj önerisi
- **Diyet & Egzersiz öneri kuralları**: Kan şekeri seviyesi ve semptomlara göre

## 🛠 Kullanılan Teknolojiler

- **C#** (Windows Forms)
- **PostgreSQL**
- **MD5** (şifre hash için)

## 📂 Proje Durumu

- [x] Temel sistem mimarisi
- [x] Kullanıcı giriş & kayıt ekranları
- [x] PostgreSQL veritabanı bağlantısı
- [x] Hasta/Doktor yetkileri
- [ ] Arayüz tasarımının iyileştirilmesi
- [ ] Kod temizliği & tekrarların azaltılması

> Not: Kodun %70–75’i tamamlanmıştır. Arayüz basit tutulmuştur. Amaç, konseptin çalışır hale getirilmesidir.

## 🔧 Kurulum

1. PostgreSQL üzerinde `diabet_takip` isminde bir veritabanı oluşturun.
2. İlgili tabloları SQL scripti ile veritabanına ekleyin.
3. Visual Studio üzerinden projeyi açın.
4. `App.config` dosyasında veritabanı bağlantı bilgilerini güncelleyin.
5. Projeyi çalıştırın.

## 📸 Ekran Görüntüleri

<img width="1920" height="1080" alt="Screenshot (3)" src="https://github.com/user-attachments/assets/eb9b94bb-c6d4-4f45-91ef-21edab72444a" />
<img width="19<img width="1920" height="1080" alt="Doktor panrl listele" src="https://github.com/user-attachments/assets/561d9fea-4a52-45f7-881a-868f33bab5a5" />
<img width="1920" height="1080" alt="Screenshot (7)" src="https://github.com/user-attachments/assets/e026358d-b336-44e5-b573-cb9f965f0d72" />
<img width="1920" height="1080" alt="Screenshot (8)" src="https://github.com/user-attachments/assets/36a92436-c398-475b-91d9-72fe5e070680" />
<img width="1920" height="1080" alt="Screenshot (9)" src="https://github.com/user-attachments/assets/3051ab7c-74ee-4359-8b17-c5785a2f1d55" />
<img width="1920" height="1080" alt="Screenshot (10)" src="https://github.com/user-att<img width="1920" height="1080" alt="hasta giris" src="https://github.com/user-attachments/assets/cabc0902-4506-45d4-964e-4423c5888304" />
<img width="1920" height="1080" alt="Screenshot (12)" src="https://github.com/user-attachments/assets/816e05f3-2311-466d-aee7-73a380da5898" />
<img width="1920" height="1080" alt="Screenshot (14)" src="https://github.com/user-attachments/assets/8c255df0-08d2-43b8-a70f-05e2f7be3ec5" />
<img width="1920" height="1080" alt="Screenshot (15)" src="https://github.com/user-attachments/assets/22193aa1-8940-415d-beba-80025c1147b1" />
<img width="1920" height="1080" alt="Screenshot (16)" src="https://github.com/user-attachments/assets/07ece16b-9dc0-4fd8-8be1-39d0dab689ab" />
<img width="1920" height="1080" alt="Screenshot (17)" src="https://github.com/user-attachments/assets/0ae9c043-a749-4e21-bee0-bbfeab5dabe2" />
<img width="1920" height="1080" alt="Screenshot (18)" src="https://github.com/user-attachments/assets/1d1961ee-8d67-4281-bb7e-7f6d57173a9c" />


## 📜 Lisans

Bu proje **MIT License** ile lisanslanmıştır.  
İsteyen herkes inceleyebilir, öğrenebilir ve geliştirebilir.
