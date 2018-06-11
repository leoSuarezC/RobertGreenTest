using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace RobertGreenTest
{
    public class ObjectsManager<T> : IDisposable where T : new()
    {
        public string Id;
        public ObjectsManager()
        {

        }
        public void Save()
        {
            var objectType = this.GetType();
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\" + objectType + @"\";
            DirectoryInfo di = Directory.CreateDirectory(path);
            var fileCount = GetLastId(path);
            string fileName = fileCount + ".json";
            this.Id = fileCount.ToString();
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(path + fileName, json);
        }
        private int GetLastId(string path)
        {
            if (File.Exists(path))
            {
                string[] filePaths = Directory.GetFiles(path, "*.json");
                int max = 0;
                foreach (var filePath in filePaths)
                {
                    var number = filePath.Replace(path, "").Replace(".json", "");
                    int val = Int32.Parse(number);
                    if (val > max)
                    {
                        max = val;
                    }
                }
                return max + 1;
            }
            else
            {
                return 1;
            }
        }
        public static T Find(string id)
        {
            T instance = new T();
            var objectType = instance.GetType();
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\" + objectType + @"\";
            var fileName = id + ".json";
            if (File.Exists(path + fileName))
            {
                string json = File.ReadAllText(path + fileName);
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
            else
            {
                return default(T);
            }
        }
        public static void Delete(string id)
        {
            T instance = new T();
            var objectType = instance.GetType();
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\" + objectType + @"\";
            var fileName = id + ".json";
            if (File.Exists(path + fileName))
            {
                File.Delete(path + fileName);
            }
        }
        public void Delete()
        {
            var objectType = this.GetType();
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\" + objectType + @"\";
            var fileName = this.Id + ".json";
            if (File.Exists(path + fileName))
            {
                File.Delete(path + fileName);
            }
            this.Dispose();
        }

        public bool IsSaved()
        {
            var objectType = this.GetType();
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\" + objectType + @"\";
            var fileName = this.Id + ".json";
            return File.Exists(path + fileName) ? true : false;

        }

        public void Dispose()
        {
            this.Id = null;
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
