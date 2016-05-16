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
            flat = new Flat();
            JsonParser.LoadJson(out flat, "test.json");
            view = new View(flat);
            this.Controls.Add(view);
            
        }
        
        private void ViewSwitcher_Click(object sender, EventArgs e)
        {
            view.IsView2D = !view.IsView2D;
            view.Refresh();
        }
    }
}
