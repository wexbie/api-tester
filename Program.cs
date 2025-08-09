using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiTester
{
    class Program
    {
        static HttpClient httpClient = new HttpClient();

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
                    Console.WriteLine("Sadece GET ve POST destekleniyor!");
                }
            }
            catch (Exception hata)
            {
                Console.WriteLine($"Bir hata oluştu: {hata.Message}");
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