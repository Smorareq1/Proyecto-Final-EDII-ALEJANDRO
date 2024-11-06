using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Estructuras
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void LoadUserControl(UserControl userControl)
        {
            panel1.Controls.Clear(); 
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(userControl); 
        }
    }
}
