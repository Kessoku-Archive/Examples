using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json; // 도구 << nuget
namespace JsonTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "characters.json";

            List<Character>? characters = null;
            try
            {
                string json = File.ReadAllText(path);
                characters = JsonConvert.DeserializeObject<List<Character>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("에러: " + ex.Message);
            }

            if (characters == null)
            {

                Console.WriteLine("데이터가 없습니다");
                return;
            }
                foreach (var c in characters)
                {
                    Console.WriteLine($"이름: {c.name}, HP: {c.CurrentHP} / {c.MaxHP}");
                }
            
        }
    }
}
