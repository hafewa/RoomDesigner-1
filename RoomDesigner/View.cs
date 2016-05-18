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
using System.Runtime.InteropServices;

namespace RoomDesigner
{
    public partial class View : UserControl
    {
        Flat flat;
        public Control Draw2D { get; set; } //for accession from MainForm

        int margin = 15;

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

        public bool IsView2D = true;
        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            if (IsView2D)
            {
                Draw2Dmodel(e);
                DrawAxis(e);
            }

            else
                Drawd3Dmodel(e);
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
                DrawFurniture(e, room);
                DrawSanitaryEngineering(e, room);
                e.Graphics.DrawRectangles(p, new RectangleF[] { new RectangleF(new PointF(room.ScaledTop.X + margin, room.ScaledTop.Y + margin), new SizeF(room.ScaledLengthX, room.ScaledLengthY)) });
                DrawName(e, room, Color.Black, 14);
                DrawArea(e, room);                                
            }
            
        }        

        private void DrawName(PaintEventArgs e, ModelEntity obj, Color col, int fontSize)
        {
            //e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            string dString = obj.Name;
            Font dFont = new Font("Arial", fontSize);
            SolidBrush dBrush = new SolidBrush(col);
            RectangleF dRect = new RectangleF(new PointF(obj.ScaledTop.X + margin, obj.ScaledTop.Y + margin), new SizeF(obj.ScaledLengthX, obj.ScaledLengthY));
            //StringFormat dFormat = new StringFormat();
            //dFormat.FormatFlags = StringFormatFlags;           
            e.Graphics.DrawString(dString, dFont, dBrush, dRect);
        }


        private void DrawArea(PaintEventArgs e, Room r)
        {
            //e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            string dString = $"S = {r.GetArea(): #######.##} кв.м";
            PointF dPoint = new PointF(r.ScaledTop.X + margin, r.ScaledTop.Y + margin + 5);
            Font dFont = new Font("Arial", 12);
            SolidBrush dBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString(dString, dFont, dBrush, dPoint);
        }

        private void DrawAxis(PaintEventArgs e)
        {
            //drawing axis
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            Pen p = new Pen(Color.Black, 0.2F);
            e.Graphics.DrawLine(p, new Point(10, 10), new Point(10, DrawingPanel.Height / 3));
            e.Graphics.DrawLine(p, new Point(10, 10), new Point(DrawingPanel.Width / 3, 10));

            Font dFont = new Font("Arial", 12);
            SolidBrush dBrush = new SolidBrush(Color.Black);

            List<float> xPoints = new List<float>();
            List<float> yPoints = new List<float>();
            foreach (var room in flat.Rooms)
            {
                xPoints.AddRange(room.coord.Select(c => c.X));
                yPoints.AddRange(room.coord.Select(c => c.Y));

            }
            xPoints = xPoints.Distinct().ToList();
            yPoints = yPoints.Distinct().ToList();

            foreach (var x in xPoints)
            {
                e.Graphics.FillRectangle(dBrush, new RectangleF(new PointF(x / ModelEntity.Scale + margin, 9), new SizeF(1f, 2f)));
                e.Graphics.DrawString(x.ToString(), dFont, dBrush, new PointF(x / ModelEntity.Scale + margin - 5, 5));

            }
            foreach (var y in yPoints)
            {
                e.Graphics.FillRectangle(dBrush, new RectangleF(new PointF(9, y / ModelEntity.Scale + margin), new SizeF(2f, 1f)));
                e.Graphics.DrawString(y.ToString(), dFont, dBrush, new PointF(5, y / ModelEntity.Scale + margin - 5), new StringFormat(StringFormatFlags.DirectionVertical));
            }

        }


        private void DrawFurniture(PaintEventArgs e, Room r)
        {
            Pen p = new Pen(Color.Brown, 0.5F);
            if (r.Furniture != null)
            {
                foreach (var fur in r.Furniture)
                {
                    RectangleF rect = new RectangleF(new PointF(fur.ScaledTop.X + margin, fur.ScaledTop.Y + margin), new SizeF(fur.ScaledLengthX, fur.ScaledLengthY));
                    e.Graphics.DrawRectangles(p, new RectangleF[] { rect });
                    DrawName(e, fur, Color.Brown, 9);
                }
            }
            
        }

        private void DrawSanitaryEngineering(PaintEventArgs e, Room r)
        {
            Pen p = new Pen(Color.Blue, 0.5F);
            if (r.SanitaryEngineering != null)
            {
                foreach (var san in r.SanitaryEngineering)
                {
                    RectangleF rect = new RectangleF(new PointF(san.ScaledTop.X + margin, san.ScaledTop.Y + margin), new SizeF(san.ScaledLengthX, san.ScaledLengthY));
                    e.Graphics.DrawRectangles(p, new RectangleF[] { rect });
                    DrawName(e, san, Color.Blue, 9);
                }
            }

        }



        
        //3D
        private void Drawd3Dmodel(PaintEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            Pen p1 = new Pen(Color.Black, 0.5F);
            Pen p2 = new Pen(Color.Blue, 0.5f);
            DrawingPanel.Width = Convert.ToInt32((flat.ScaledLengthX * 4)) + 100;
            DrawingPanel.Height = Convert.ToInt32((flat.ScaledLengthY * 4)) + 100;

            //drawing the rooms                       
            
            foreach (var room in flat.Rooms)
            {
                e.Graphics.PageUnit = GraphicsUnit.Millimeter;

                //e.Graphics.DrawRectangles(p1, new RectangleF[] { new RectangleF(new PointF(room.ScaledTop.X + 8, room.ScaledTop.Y + 8), new SizeF(room.ScaledLengthX, room.ScaledLengthY)) });
               
                float delta = 25F;
                PointF ul = new PointF(room.ScaledCoord[0].X+8, room.ScaledCoord[0].Y+8);
                PointF ur = new PointF(room.ScaledCoord[1].X + 8, room.ScaledCoord[1].Y + 8);
                PointF _ul = new PointF(ul.X + delta, ul.Y + delta);
                PointF _ur = new PointF(ur.X + delta, ur.Y + delta);                
                PointF[]  Uside = new PointF[] { ul, ur, _ur, _ul };  //проекция верхняя

                PointF ll = new PointF(room.ScaledCoord[3].X + 8, room.ScaledCoord[3].Y + 8);
                PointF lr = new PointF(room.ScaledCoord[2].X + 8, room.ScaledCoord[2].Y + 8);
                PointF _ll = new PointF(ll.X + delta, ll.Y + delta);
                PointF _lr = new PointF(lr.X + delta, lr.Y + delta);
                PointF[] Lside = new PointF[] { ll, lr, _lr, _ll };  //проекция нижняя

                PointF[] mainSide = new PointF[] { ul, ur, lr, ll };
                e.Graphics.DrawPolygon(p1, mainSide);
                e.Graphics.DrawPolygon(p1, Uside);
                e.Graphics.DrawPolygon(p1, Lside);
                e.Graphics.DrawLine(p1, _ul, _ll);
                e.Graphics.DrawLine(p1, _ur, _lr);

                RectangleF floor = new RectangleF(_ul, new SizeF(lr.X - _ul.X, lr.Y - _ur.Y ));
                e.Graphics.FillRectangle(Brushes.DimGray, floor);
                                
                //DrawRoomName(e, room);
                //DrawArea(e, room);
            }            

        }


        #region drag'n'drop fail
        //!!!!!!!!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!!! DRAG AND DROP!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!


        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        foreach(var room in flat.Rooms)
        //        {
        //            MessageBox.Show((room.ScaledCoord[0].X + margin).ToString());
        //            if(e.X>room.ScaledCoord[0].X+margin && e.X<room.ScaledCoord[1].X+margin && Math.Abs(room.ScaledCoord[0].Y+margin - e.Y) <= 150)
        //            {
        //                MessageBox.Show("aga");
        //            }
        //        }


        //        Invalidate();
        //    }

        //}
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        //rec.Width = e.X - rec.X;
        //        //rec.Height = e.Y - rec.Y;
        //        Invalidate();
        //    }
        //}




        //const int HORZSIZE = 4;
        //const int VERTSIZE = 6;

        //const int HORZRES = 8;
        //const int VERTRES = 10;

        //[DllImport("gdi32.dll", SetLastError = true)]
        //static extern int GetDeviceCaps(
        //    IntPtr hDc,
        //    int index
        //    );

        //[DllImport("user32.dll", SetLastError = true)]
        //static extern IntPtr GetDC(IntPtr hWnd);

        //[DllImport("user32.dll", SetLastError = true)]
        //static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        //float GetPixelSizePerMM_X()
        //{
        //    IntPtr hDC = GetDC(IntPtr.Zero);
        //    float wM = (float)GetDeviceCaps(hDC, HORZRES)/ (float)GetDeviceCaps(hDC, HORZSIZE);
        //    //float hM = (float)GetDeviceCaps(hDC, VERTSIZE)/(float)GetDeviceCaps(hDC, VERTRES) ;
        //    ReleaseDC(IntPtr.Zero, hDC);

        //    return wM;
        //}

        //float GetPixelSizePerMM_Y()
        //{
        //    IntPtr hDC = GetDC(IntPtr.Zero);
        //    //float wM = (float)GetDeviceCaps(hDC, HORZSIZE) / (float)GetDeviceCaps(hDC, HORZRES);
        //    float hM =  (float)GetDeviceCaps(hDC, VERTRES)/(float)GetDeviceCaps(hDC, VERTSIZE);
        //    ReleaseDC(IntPtr.Zero, hDC);

        //    return hM;
        //}

        //private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        //{

        //    if (e.Button == MouseButtons.Left)
        //    {
        //        foreach (var room in flat.Rooms)
        //        {

        //            //MessageBox.Show((room.ScaledCoord[0].X + margin).ToString());
        //            if (e.X > (room.ScaledCoord[0].X + margin)*GetPixelSizePerMM_X() && e.X < (room.ScaledCoord[1].X + margin)*GetPixelSizePerMM_X() && Math.Abs((room.ScaledCoord[0].Y + margin)*GetPixelSizePerMM_Y() - e.Y) <= 5)
        //            {
        //                MessageBox.Show("ClickTopSide");
        //            }
        //            if (e.X > (room.ScaledCoord[3].X + margin)*GetPixelSizePerMM_X() && e.X < (room.ScaledCoord[2].X + margin)*GetPixelSizePerMM_X() && Math.Abs((room.ScaledCoord[3].Y + margin)*GetPixelSizePerMM_Y() - e.Y) <= 5)
        //            {
        //                MessageBox.Show("ClickBottSide");
        //            }
        //        }


        //        Invalidate();
        //    }
        //}
        #endregion

    }
}
