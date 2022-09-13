using Newtonsoft.Json;
using System;
using System.IO;

namespace Jenkins2.Readers
{
    public static class JsonReader
    {

        public static T ReadFile<T>(string fileName)
        {
            var directory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent;
            var jsonFolder = Path.Combine(directory.FullName, "Jsons");
            return JsonConvert.DeserializeObject<T>(File.ReadAllText($"{jsonFolder}\\{fileName}"));
        }
    }
}
