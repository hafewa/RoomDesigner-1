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
            DrawingPanel.Width = Convert.ToInt32((flat.ScaledLengthX))+50;
            DrawingPanel.Height = Convert.ToInt32((flat.ScaledLengthY))+50;
            
        }

        private void View_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void Draw2Dmodel(PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 3);

            //рисуем комнаты 
            foreach (var room in flat.Rooms)
            {
                e.Graphics.DrawRectangles(p, new RectangleF[] { new RectangleF(new PointF(room.ScaledTop.X + 30, room.ScaledTop.Y + 30), new SizeF(room.ScaledLengthX, room.ScaledLengthY)) });
                DrawRoomName(e, room);
                DrawArea(e, room);
            }

        }
        private void DrawRoomName(PaintEventArgs e, Room r)
        {
            string dString = r.Name;
            Font dFont = new Font("Arial", 14);
            SolidBrush dBrush = new SolidBrush(Color.Black);
            PointF dPoint = new PointF(r.ScaledTop.X + 40, r.ScaledTop.Y + 40);
            e.Graphics.DrawString(dString,dFont,dBrush,dPoint);
        }

       
        private void DrawArea(PaintEventArgs e, Room r)
        {
            string dString = $"S = {r.GetArea() / 1000000 : #.##} кв.м";
            PointF dPoint = new PointF(r.ScaledTop.X + 40, r.ScaledTop.Y + 65);
            Font dFont = new Font("Arial", 12);
            SolidBrush dBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString(dString, dFont, dBrush, dPoint);
        }
        

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            //drawing axis
            Pen p = new Pen(Color.Black, 2);
            e.Graphics.DrawLine(p, new Point(15, 15), new Point(15, DrawingPanel.Height-15));
            e.Graphics.DrawLine(p, new Point(15, 15), new Point(DrawingPanel.Width-15, 15));
            Draw2Dmodel(e);
        }

    }
}
