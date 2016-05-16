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
        public Control Draw2D { get; set; } //for accession from MainForm
        public View(Flat flatParam)
        {
            this.flat = flatParam; 
            InitializeComponent();
            this.BackColor = Color.White;
            
            Draw2D = this.DrawingPanel;


        }

        private void View_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            
        }
        private void Draw2Dmodel(PaintEventArgs e)
        {
            //e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            Pen p = new Pen(Color.Black, 1F);
            DrawingPanel.Width = Convert.ToInt32((flat.ScaledLengthX * 4)) + 50;
            DrawingPanel.Height = Convert.ToInt32((flat.ScaledLengthY * 4)) + 50;
            //drawing the rooms
            foreach (var room in flat.Rooms)
            {
                e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                e.Graphics.DrawRectangles(p, new RectangleF[] { new RectangleF(new PointF(room.ScaledTop.X + 8, room.ScaledTop.Y + 8), new SizeF(room.ScaledLengthX, room.ScaledLengthY)) });
                DrawRoomName(e, room);
                DrawArea(e, room);
            }

        }
        private void DrawRoomName(PaintEventArgs e, Room r)
        {
            //e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            string dString = r.Name;
            Font dFont = new Font("Arial", 14);
            SolidBrush dBrush = new SolidBrush(Color.Black);
            PointF dPoint = new PointF(r.ScaledTop.X + 10, r.ScaledTop.Y + 10);
            e.Graphics.DrawString(dString,dFont,dBrush,dPoint);
        }

       
        private void DrawArea(PaintEventArgs e, Room r)
        {
            //e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            string dString = $"S = {r.GetArea() : ####.##} кв.м";
            PointF dPoint = new PointF(r.ScaledTop.X + 10, r.ScaledTop.Y + 15);
            Font dFont = new Font("Arial", 12);
            SolidBrush dBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString(dString, dFont, dBrush, dPoint);
        }
        private void DrawAxis(PaintEventArgs e)
        {
            //drawing axis
            Pen p = new Pen(Color.Black, 0.2F);
            e.Graphics.DrawLine(p, new Point(2, 2), new Point(2, DrawingPanel.Height - 10));
            e.Graphics.DrawLine(p, new Point(2, 2), new Point(DrawingPanel.Width - 10, 2));

            //Font dFont = new Font("Arial", 12);
            //SolidBrush dBrush = new SolidBrush(Color.Black);
            //e.Graphics.DrawString("Y", dFont, dBrush, 3f, (DrawingPanel.Height - 10F)/25.6F);
            //e.Graphics.DrawString("X", dFont, dBrush, DrawingPanel.Width - 10F, 5f);

        }


        public bool IsView2D = true;
        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            DrawAxis(e);
            if (IsView2D)
                Draw2Dmodel(e);
            else
                Drawd3Dmodel(e);
            
        }
        //3D
        private void Drawd3Dmodel(PaintEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            Pen p1 = new Pen(Color.Black, 1F);
            Pen p2 = new Pen(Color.Blue, 0.5f);
            DrawingPanel.Width = Convert.ToInt32((flat.ScaledLengthX * 4)) + 150;
            DrawingPanel.Height = Convert.ToInt32((flat.ScaledLengthY * 4)) + 150;
            //drawing the rooms
            
            
            foreach (var room in flat.Rooms)
            {
                e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                e.Graphics.DrawRectangles(p1, new RectangleF[] { new RectangleF(new PointF(room.ScaledTop.X + 8, room.ScaledTop.Y + 8), new SizeF(room.ScaledLengthX, room.ScaledLengthY)) });
                float delta = 15F;
                PointF ul = new PointF(room.ScaledCoord[0].X+8, room.ScaledCoord[0].Y+8);
                PointF ur = new PointF(room.ScaledCoord[1].X + 8, room.ScaledCoord[1].Y + 8);
                PointF _ul = new PointF(ul.X + delta, ul.Y + delta);
                PointF _ur = new PointF(ur.X + delta, ur.Y + delta);                
                PointF[]  Uside = new PointF[] { ul, ur, _ur, _ul };

                PointF ll = new PointF(room.ScaledCoord[3].X + 8, room.ScaledCoord[3].Y + 8);
                PointF lr = new PointF(room.ScaledCoord[2].X + 8, room.ScaledCoord[2].Y + 8);
                PointF _ll = new PointF(ll.X + delta, ll.Y + delta);
                PointF _lr = new PointF(lr.X + delta, lr.Y + delta);
                PointF[] Lside = new PointF[] { ll, lr, _lr, _ll };

                e.Graphics.DrawPolygon(p1, Uside);
                e.Graphics.DrawPolygon(p1, Lside);
                e.Graphics.DrawLine(p1, _ul, _ll);
                e.Graphics.DrawLine(p1, _ur, _lr);
                //DrawRoomName(e, room);
                //DrawArea(e, room);
            }
            

        }



    }
}
