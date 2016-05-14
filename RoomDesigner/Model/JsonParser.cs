using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace RoomDesigner.Model
{
    public static class JsonParser
    {
        public static void LoadJson(out Flat target, string JsonSource)
        {
            using (StreamReader r = new StreamReader(JsonSource))
            {
                string json = r.ReadToEnd();
                target = JsonConvert.DeserializeObject<Flat>(json);
            }

        }
    }
}
