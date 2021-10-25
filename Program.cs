using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//Задаємо потрібний нам простір імен
namespace Practice2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задаємо функцію для обробки паролів і файлів
            GenerateKey();
            Encrypting();
            Decoding();
            
        }
        private static void GenerateKey()
        {
            //Задаємо методи для обробки файлів, в даному випадку для генерації паролю
            byte[] Data = File.ReadAllBytes("input.txt").ToArray();
            byte[] key = Crypto.GetCryptoRng(Data.Length);
            File.WriteAllBytes("key.dat", key);
        }

        private static void Encrypting()
        {
            //Тут задаємо методи для шифрування паролю в текстовому документі і запису його у інший файл
            byte[] decData = File.ReadAllBytes("input.txt").ToArray();
            byte[] key = File.ReadAllBytes("key.dat").ToArray();
            byte[] encData = new byte[decData.Length];
            for (int i = 0; i < decData.Length; i++)
            {
                encData[i] = (byte)(decData[i] ^ key[i]);
            }
            File.WriteAllBytes("encFile.dat", encData);
        }
        private static void Decoding()
        {
            //Задаємо методи для зчитування і розшифрування паролю у файлі і запису його у інший файл
            byte[] encData = File.ReadAllBytes("encFile.dat").ToArray();
            byte[] key = File.ReadAllBytes("key.dat").ToArray();
            byte[] decData = new byte[encData.Length];
            for (int i = 0; i < encData.Length; i++)
            {
                decData[i] = (byte)(encData[i] ^ key[i]);
            }
            string text = Encoding.UTF8.GetString(decData);
            File.WriteAllText("decodedFile.txt", text);
        }
        
    }
}
