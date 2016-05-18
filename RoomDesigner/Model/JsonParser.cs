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
        public static void LoadJson(out Flat target, string JsonSource, out string error)
        {

            using (StreamReader r = new StreamReader(JsonSource))
            {

                string json = r.ReadToEnd();
                error = "";

                try
                {
                    target = JsonConvert.DeserializeObject<Flat>(json);
                    
                }
                catch (Exception ex)
                {
                    error = "Invalid Json data : " + ex.Message;
                    target = null;
                }
            }
            
        }
    }
}
