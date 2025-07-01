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
            var userData = new List<UserData> // userdata를 json 파일로 넘기는 예제
            {
                new UserData { Level = 10, Gold = 1000}
            };

            string jjson = JsonConvert.SerializeObject(userData, Formatting.Indented);
            //객체를 json 문자열로 직렬화

            File.WriteAllText("UserData.json", jjson);

            foreach (var c in userData)
            {
                Console.WriteLine($"레벨: {c.Level}, 골드: {c.Gold} G");
            }

            string path = "characters.json";  //json 파일에서 캐릭터 데이터를 c#으로 불러오는 예제

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
