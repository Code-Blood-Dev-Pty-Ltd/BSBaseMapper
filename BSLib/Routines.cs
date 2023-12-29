using BSLib.Models;
using Newtonsoft.Json;

namespace BSLib
{
    public static class Routines
    {
        public static RootMapObject ParseMapJson(string jsonString)
        {
            return JsonConvert.DeserializeObject<RootMapObject>(jsonString)!;
        }

        public static void WriteMapToJsonFile(string filePath, RootMapObject rootObject)
        {
            string json = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static RootInfoObject ParseInfoJson(string jsonString)
        {
            return JsonConvert.DeserializeObject<RootInfoObject>(jsonString)!;
        }

        public static void WriteInfoToJsonFile(string filePath, RootInfoObject rootObject)
        {
            string json = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
