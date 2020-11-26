using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editar_Colores
{
    public partial class fPickColorVert : Form
    {
        public Color ElColor
        {
            get { return wellPanel1.Color; }
            set 
            { 
                wellPanel1.Color = value;
                Utilities.SetBackColor(lblBackColor, value);
            }
        }

        public fPickColorVert()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void wellPanel1_ColorChanged(object sender, WellPanel.ColorChangedEventArgs e)
        {
            Utilities.SetBackColor(lblBackColor, e.Color);
        }
    }
}
