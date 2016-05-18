using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoomDesigner.Model;

namespace RoomDesigner
{
    public partial class MainForm : Form
    {
        Flat flat;
        View view;
        public MainForm()
        {
            InitializeComponent();
            ctrBar.Visible = false;
            this.DoubleBuffered = true;
        }
        
        private void ViewSwitcherBtn_Click(object sender, EventArgs e)
        {
            view.IsView2D = !view.IsView2D;
            if(!view.IsView2D)
            {
                ViewSwitcherBtn.Text = "to 2D";
            }
            else
            {
                ViewSwitcherBtn.Text = "to 3D";
            }
            view.Refresh();
        }

        private void openJsonBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Json files(*.json) | *.json";
            fd.InitialDirectory = Environment.CurrentDirectory;
            if(fd.ShowDialog() == DialogResult.OK)
            {
                string error="";
                flat = new Flat();
                JsonParser.LoadJson(out flat, "test.json",out error);     
                if(flat !=null)
                {
                    this.Controls.Remove(view);
                    view = new View(flat);
                    this.Controls.Add(view);     
                    
                                   
                    ctrBar.Visible = true;
                    Scale_tb.Text = ModelEntity.Scale.ToString();
                    this.Text += " " + fd.FileName;
                }
                else
                {
                    MessageBox.Show(error);
                }
                
            }
            fd.Dispose();            
        }

        private void Scale_tb_TextChanged(object sender, EventArgs e)
        {
            int newScale;
            bool state = int.TryParse((sender as TextBox).Text, out newScale);
            if (state && newScale>0 && newScale<500)
            {
                ModelEntity.Scale = newScale;
                view.Refresh();                
            }

        }
        
    }
}
