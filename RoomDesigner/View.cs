using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoomDesigner.Model;

namespace RoomDesigner
{
    public partial class View : UserControl
    {
        Flat flat;
        
        public View(Flat flatParam)
        {
            this.flat = flatParam;           

            InitializeComponent();
            this.BackColor = Color.White;            
            
        }

        private void View_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics gr = e.Graphics;
            Pen p = new Pen(Color.Black, 2);

            //рисуем комнаты 
            foreach (var room in flat.Rooms)
            {
                gr.DrawRectangles(p, new RectangleF[] { new RectangleF(room.ScaledTop, new SizeF(room.ScaledLengthX, room.ScaledLengthY)) });
            }

            //gr.DrawLine(p, flat.Rooms[3].ScaledCoord[0], flat.Rooms[3].ScaledCoord[3]);           




            //gr.DrawPolygon(p, flat.RoomPoints.ToArray());

            //gr.DrawRectangle(p, new Rectangle(new Point(flat.coord[0].x/20+50, flat.coord[0].y/20+50),
            //    new Size((flat.coord[1].x-flat.coord[0].x)/20, (flat.coord[3].y - flat.coord[0].y)/20)));

            //foreach(var room in flat.Rooms)
            //{

            //    gr.DrawRectangle(p, new Rectangle(new Point(room.coord[0].x / 20 + 50, room.coord[0].y / 20 + 50),
            //    new Size((room.coord[1].x - room.coord[0].x) / 20, (room.coord[3].y - room.coord[0].y) / 20)));

            //}

        }
    }
}
