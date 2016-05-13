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
    public partial class Form1 : Form
    {
        Flat flat;
        public Form1()
        {
            InitializeComponent();
            flat = new Flat();
            JsonParser.LoadJson(out flat, "test.json");
            MessageBox.Show(flat.coord[2].x.ToString());
        }

    }
}
