using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiTester
{
    class Program
    {
        static HttpClient httpClient = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        static async Task Main(string[] args)
        {
            Console.WriteLine(" API Test Aracı ");
            Console.WriteLine("Bu program API'leri test eder");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Ne yapmak istiyorsun ?");
                Console.WriteLine("1. Kendi API'nizi test edin");
                Console.WriteLine("2. Konsoldan çıkın");
                Console.Write("Seçiminizi yazın (1 veya 2): ");
                
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    await ApiTest();
                }
                else if (secim == "2")
                {
                    Console.WriteLine("Program kapatılıyor...");
                    break;
                }
                else
                {
                    Console.WriteLine("Yanlış seçim! Lütfen 1 veya 2 yazın.");
                }

                Console.WriteLine();
            }
        }

        static async Task ApiTest()
        {
            Console.Write("Test etmek istediğin API URL adresini yaz: ");
            string webAdresi = Console.ReadLine();

            Console.Write("Hangi yöntemi kullanacaksın? (GET veya POST): ");
            string yontem = Console.ReadLine().ToUpper();

            string veri = "";
            
            if (yontem == "POST")
            {
                Console.WriteLine("Göndermek istediğin JSON verisini yaz:");
                Console.WriteLine("(Bitirmek için 'BİTTİ' yaz)");
                
                string satir;
                while ((satir = Console.ReadLine()) != "BİTTİ")
                {
                    veri = veri + satir + "\n";
                }
                veri = veri.TrimEnd('\n');
                
                try
                {
                    System.Text.Json.JsonDocument.Parse(veri);
                }
                catch (System.Text.Json.JsonException)
                {
                    Console.WriteLine("Hata: Geçersiz JSON formatı!");
                    Console.WriteLine("İpucu: JSON sözdizimini kontrol edin");
                    return;
                }
            }

            Console.WriteLine("\nAPI isteği gönderiliyor...");
            Console.WriteLine($"Web adresi: {webAdresi}");
            Console.WriteLine($"Yöntem: {yontem}");
            if (veri != "")
            {
                Console.WriteLine($"Gönderilen veri: {veri}");
            }
            Console.WriteLine();

            try
            {
                if (!Uri.IsWellFormedUriString(webAdresi, UriKind.Absolute))
                {
                    Console.WriteLine("Hata: Geçersiz URL formatı! Lütfen tam URL adresini yazın (örn: https://api.example.com/data)");
                    return;
                }

                if (yontem == "GET")
                {
                    var yanit = await httpClient.GetAsync(webAdresi);
                    await SonucuGoster(yanit);
                }
                else if (yontem == "POST")
                {
                    var icerik = new StringContent(veri, Encoding.UTF8, "application/json");
                    var yanit = await httpClient.PostAsync(webAdresi, icerik);
                    await SonucuGoster(yanit);
                }
                else
                {
                    Console.WriteLine("Hata: Sadece GET ve POST destekleniyor!");
                }
            }
            catch (HttpRequestException hata)
            {
                Console.WriteLine($"Ağ Bağlantı Hatası: {hata.Message}");
                Console.WriteLine("İpucu: İnternet bağlantınızı kontrol edin");
            }
            catch (TaskCanceledException hata)
            {
                Console.WriteLine($"Timeout Hatası: İstek zaman aşımına uğradı");
                Console.WriteLine("İpucu: Daha kısa bir süre bekleyip tekrar deneyin");
            }
            catch (UriFormatException hata)
            {
                Console.WriteLine($"URL Format Hatası: {hata.Message}");
                Console.WriteLine("İpucu: URL'nin doğru formatta olduğundan emin olun");
            }
            catch (Exception hata)
            {
                Console.WriteLine($"Beklenmeyen Hata: {hata.Message}");
                Console.WriteLine("İpucu: Lütfen tekrar deneyin");
            }
        }

        static async Task SonucuGoster(HttpResponseMessage yanit)
        {
            Console.WriteLine("| SONUÇ |");
            string durumAciklamasi = "";
            if ((int)yanit.StatusCode == 200)
                durumAciklamasi = " (Başarılı)";
            else if ((int)yanit.StatusCode == 201)
                durumAciklamasi = " (Oluşturuldu)";
            else if ((int)yanit.StatusCode == 400)
                durumAciklamasi = " (Hatalı İstek)";
            else if ((int)yanit.StatusCode == 404)
                durumAciklamasi = " (Bulunamadı)";
            else if ((int)yanit.StatusCode == 500)
                durumAciklamasi = " (Sunucu Hatası)";
            else
                durumAciklamasi = " (Bilinmeyen)";
            

            Console.WriteLine($"Durum kodu: {(int)yanit.StatusCode} {yanit.StatusCode}{durumAciklamasi}");
            string yanitMetni = await yanit.Content.ReadAsStringAsync();
            Console.WriteLine();
            Console.WriteLine("Gelen yanıt:");
            Console.WriteLine(yanitMetni);
        }
    }
}