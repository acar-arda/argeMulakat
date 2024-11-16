using System;
using System.IO;

namespace argeMulakat
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = File.AppendText("database.txt");
            string[] database = File.ReadAllLines("database.txt");
            
            List<string> usernames = new List<string>();
            List<string> passwords = new List<string>();

            for (int i = 0; i < database.Length; i++)
            {
                if (i % 2 == 0)
                {
                    usernames.Add(database[i]);
                }
                else
                {
                    passwords.Add(database[i]);
                }
            }

            Console.Write("Hoş Geldiniz!\nÜyeliğiniz varsa sisteme giriş yapmak için 1 yazınız.\nÜyeliğiniz yoksa kayıt olmak için 2 yazınız.\nSeçim: ");
            var secim = Console.ReadLine();
            while (secim != "1" && secim != "2")
            {
                Console.Write("Lütfen geçerli bir seçim yapınız! (1/2): ");
                secim = Console.ReadLine();
            }

            if (secim == "1")
            {
                Console.Write("Kullanıcı adınızı giriniz: ");
                var username = Console.ReadLine();

                Console.Write("Şifrenizi giriniz: ");
                var password = Console.ReadLine();

                if (usernames.Contains(username ?? ""))
                {
                    if ((passwords.Contains(password ?? "")) && (usernames.IndexOf(username ?? "") == passwords.IndexOf(password ?? "")))
                    {
                        Console.WriteLine("Giriş Başarılı! Hoş Geldin {0}!", username);
                    }
                    else
                    {
                        Console.WriteLine("Şifre Hatalı!");
                    }
                }
                else
                {
                    Console.WriteLine("Kullanıcı Adı Hatalı!");
                }
            }
            else if (secim == "2")
            {
                Console.Write("Lütfen belirleyeceğiniz kullanıcı adını giriniz: ");
                string? newUsername = Console.ReadLine();
                while (newUsername == "" || usernames.Contains(newUsername ?? ""))
                {
                    Console.Write("Bu kullanıcı adı kullanılıyor veya boş değer giremezsiniz!\nKullanıcı adınız: ");
                    newUsername = Console.ReadLine();
                }
                sw.WriteLine(newUsername);
                Console.Write("Lütfen 4 - 12 harf aralığındaki şifrenizi belirleyiniz: ");
                string? newPassword = Console.ReadLine();
                while (newPassword!.Length < 4 || newPassword!.Length > 12)
                {
                    Console.Write("Lütfen geçerli bir şifre giriniz: ");
                    newPassword = Console.ReadLine();
                }
                sw.WriteLine(newPassword);
                Console.WriteLine("Başarıyla kayıt oldun {0}! Uygulamayı tekrar çalıştırarak giriş yapabilirsiniz.", newUsername);
            }
            sw.Close();
        }
    }
}