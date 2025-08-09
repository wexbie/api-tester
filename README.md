# API Test Aracı

Bu konsol uygulaması, API endpoint'lerinizi kolayca test etmenizi sağlar. GET ve POST istekleri gönderebilir, sonuçları konsol üzerinden görebilirsiniz.

---

## 🚀 Özellikler

- **Kullanıcı dostu konsol arayüzü** - Türkçe menüler ve açıklamalar
- **GET ve POST metodları** - Temel HTTP isteklerini destekler
- **JSON veri gönderme** - POST istekleri için JSON formatında veri gönderebilirsiniz
- **Detaylı yanıt gösterimi** - HTTP durum kodları ve Türkçe açıklamalar
- **Hata yönetimi** - Güvenli kullanım için kapsamlı hata yakalama
- **Çok satırlı JSON desteği** - Karmaşık JSON verilerini kolayca girebilirsiniz

---

## 📋 Gereksinimler

- **.NET 8.0** veya üzeri
- **İnternet bağlantısı** (API erişimi için)
- **Windows/Linux/macOS** (cross-platform destek)

---

## 🛠️ Kurulum ve Çalıştırma

### 1. Projeyi İndirin
```bash
git clone <repository-url>
cd ApiTester
```

### 2. Bağımlılıkları Yükleyin
```bash
dotnet restore
```

### 3. Projeyi Derleyin
```bash
dotnet build
```

### 4. Uygulamayı Çalıştırın
```bash
dotnet run
```

---

## 📖 Kullanım Kılavuzu

### Ana Menü
Program başlatıldığında size iki seçenek sunulur:

```
=== API Test Aracı ===
Bu program API'leri test eder

Ne yapmak istiyorsun ?
1. Kendi API'nizi test edin
2. Konsoldan çıkın
Seçiminizi yazın (1 veya 2):
```

### API Test Etme Adımları

#### 1. Seçim Yapın
- API test etmek için `1` yazıp Enter'a basın
- Programdan çıkmak için `2` yazıp Enter'a basın

#### 2. URL Girin
```
Test etmek istediğin API URL adresini yaz: https://api.example.com/data
```

#### 3. HTTP Metodu Seçin
```
Hangi yöntemi kullanacaksın? (GET veya POST): POST
```

#### 4. JSON Veri Girin (POST için)
```
Göndermek istediğin JSON verisini yaz:
(Bitirmek için 'BİTTİ' yaz)

{
  "name": "Wexbie",
  "role": "Developer",
  "skills": ["C#", "JavaScript", "Python"]
}
BİTTİ
```

#### 5. Sonuçları İnceleyin
```
API isteği gönderiliyor...
Web adresi: https://api.example.com/data
Yöntem: POST
Gönderilen veri: {"name":"Wexbie","role":"Developer"}

| SONUÇ |
Durum kodu: 200 OK (Başarılı)

Gelen yanıt:
{
  "result": "Başarılı",
  "message": "Veri başarıyla kaydedildi"
}
```

---

## 🔍 Desteklenen HTTP Durum Kodları

Program aşağıdaki HTTP durum kodlarını Türkçe açıklamalarla gösterir:

| Kod | Açıklama |
|-----|----------|
| 200 | Başarılı |
| 201 | Oluşturuldu |
| 400 | Hatalı İstek |
| 404 | Bulunamadı |
| 500 | Sunucu Hatası |
| Diğer | Bilinmeyen |

---

## 💡 Örnek Kullanım Senaryoları

### GET İsteği Örneği
```
Test etmek istediğin API URL adresini yaz: https://jsonplaceholder.typicode.com/posts/1
Hangi yöntemi kullanacaksın? (GET veya POST): GET
```

### POST İsteği Örneği
```
Test etmek istediğin API URL adresini yaz: https://jsonplaceholder.typicode.com/posts
Hangi yöntemi kullanacaksın? (GET veya POST): POST
Göndermek istediğin JSON verisini yaz:
{
  "title": "Test Başlığı",
  "body": "Test içeriği",
  "userId": 1
}
BİTTİ
```

---

## 🐛 Hata Yönetimi

Program aşağıdaki hata durumlarını güvenli şekilde yönetir:

- **Ağ bağlantı hataları** - İnternet bağlantısı sorunları
- **Geçersiz URL** - Yanlış formatlanmış URL'ler
- **Sunucu hataları** - API sunucusundan gelen hatalar
- **Timeout hataları** - Uzun süren istekler

---

## 🔧 Teknik Detaylar

### Kullanılan Teknolojiler
- **C# 8.0+** - Modern C# özellikleri
- **.NET 8.0** - Cross-platform runtime
- **HttpClient** - HTTP istekleri için
- **async/await** - Asenkron programlama

### Proje Yapısı
```
ApiTester/
├── Program.cs          # Ana program dosyası
├── ApiTester.csproj    # Proje dosyası
└── README.md          # Bu dosya
```

---

## 🤝 Katkıda Bulunma

Bu projeye katkıda bulunmak istiyorsanız:

1. Projeyi fork edin
2. Yeni bir branch oluşturun (`git checkout -b feature/yeni-ozellik`)
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik eklendi'`)
4. Branch'inizi push edin (`git push origin feature/yeni-ozellik`)
5. Pull Request oluşturun

---

## 📞 İletişim

Herhangi bir sorun veya öneriniz olursa bana ulaşabilirsiniz:

- **E-posta**: wexbie@hotmail.com
- **Instagram**: @eyupaslnn
- **GitHub**: wexbie

---

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına bakın.

---

**İyi kodlamalar! 🚀**
