using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoomDesigner.Model
{
    public enum ifcCass { flat, room, furniture, sanitaryEngineering, door, window };


    public abstract class ModelEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ifcCass? ifcClass { get; set; }
        public string Height { get; set; }
        public  List<PointF> coord;


        public static int Scale = 50;

        public virtual float ScaledLengthX
        {
            get
            {
                return this.ScaledCoord[1].X - this.ScaledCoord[0].X;
            }
        }
        public virtual float ScaledLengthY
        {
            get
            {
                return this.ScaledCoord[3].Y - this.ScaledCoord[0].Y;
            }
        }                
        
        
        public List<PointF> ScaledCoord
        {
            get
            {
                List<PointF> tempList = new List<PointF>();
                PointF tempPoint = new PointF();
                
                foreach (var c in coord)
                {
                    
                    if (c.X == 0)
                    {
                        tempPoint.X = 0;
                    }
                    else
                    {
                        tempPoint.X = c.X  / Scale;
                    }
                    if (c.Y == 0)
                    {
                        tempPoint.Y = 0;
                    }
                    else
                    {
                        tempPoint.Y = c.Y / Scale;
                    }
                    tempList.Add(tempPoint);
                }
                return tempList;
            }
        }

        public virtual float GetArea()
        {
            //m2
            return (ScaledLengthX * ScaledLengthY)/1000000*Scale*Scale;
        }
        
        public PointF ScaledTop
        {
            get { return ScaledCoord[0]; }
        }
        
    }

    public class Flat : ModelEntity
    {    
        public List<Room> Rooms;

        //public List<PointF> RoomPoints
        //{
        //    get
        //    {
        //        List<PointF> temp = new List<PointF>();
        //        foreach (var room in this.Rooms)
        //        {
        //            temp.AddRange(room.ScaledCoord);
        //        }
        //        return temp;
        //    }
        //}

    }

    public class Room : ModelEntity
    {
        public List<Furniture> Furniture;
        public List<SanitaryEngineering> SanitaryEngineering;
        public List<Door> Doors;
        public List<Window> Windows;
    }


    public class Furniture : ModelEntity
    {

    }
    public class SanitaryEngineering: ModelEntity
    {

    }
    public class Door : ModelEntity
    {
        public override float GetArea()
        {
            return 0F;
        }
        public bool IsOpenInside { get; set; }
    }
    public class Window : ModelEntity
    {

    }



}
