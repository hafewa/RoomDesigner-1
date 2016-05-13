using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace RoomDesigner.Model
{
    public enum ifcCass { flat, room};
    public struct XY
    {
        public int x;
        public int y;
    }

    public class Flat
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ifcClass { get; set; }
        public string Height { get; set; }

        public List<XY> coord;
        public List<Room> Rooms;  
    }

    public class Room
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ifcCass ifcCass { get; set; }
        public string Height { get; set; }
    }

    public  static class JsonParser
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
