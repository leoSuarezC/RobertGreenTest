using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RobertGreenTest
{
    public class ObjectsManager
    {
        private int _id;

        public void Save()
        {
            string json = JsonConvert.SerializeObject(this);
            string fileName = "test.json";
            //write string to file
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Storage\" + fileName, json);
            this._id = 1;
        }
    }
}
