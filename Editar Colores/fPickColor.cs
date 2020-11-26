//-----------------------------------------------------------------------------
// fPickColor                                                       (25/Nov/20)
// Formulario para seleccionar un color
//
// Código de Hannes DuPreez
//
//
// (c) Guillermo (elGuille) Som, 2020
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Editar_Colores.WellPanel;

namespace Editar_Colores
{
    public partial class fPickColor : Form
    {
        public Color ElColor 
        {
            get { return ctPicker.Color; } 
            set { ctPicker.Color = value; } 
        }

        public fPickColor()
        {
            InitializeComponent();

            Utilities.SetBackColor(lblBackColor, ctPicker.Color, true);
            Utilities.SetForeColor(lblForeColor, ctPicker.Color, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            duSort.Items.AddRange(Enum.GetValues(typeof(Order)));
            duSort.SelectedIndex = 0;

            duScheme.Items.AddRange(Enum.GetValues(typeof(Scheme)));
            duScheme.SelectedIndex = 0;

            Utilities.SetBackColor(lblBackColor, ctPicker.Color, true);
            Utilities.SetForeColor(lblForeColor, ctPicker.Color, true);
        }

        private void duSort_SelectedItemChanged(object sender, EventArgs e)
        {
            ctPicker.SortOrder = (Order)duSort.SelectedItem;
        }

        private void duScheme_SelectedItemChanged(object sender, EventArgs e)
        {
            ctPicker.ColorScheme = (Scheme)duScheme.SelectedItem;
        }

        private void ctPicker_ColorChanged(object sender, ColorChangedEventArgs e)
        {
            Utilities.SetBackColor(lblBackColor, e.Color, true);
            Utilities.SetForeColor(lblForeColor, e.Color, true);

            //this.ElColor = e.Color;
        }

        //public static void SetBackColor(Control ctrl, Color col)
        //{
        //    ctrl.BackColor = col;

        //    string s = string.Format("{0}\r\n{1:X}", col.Name, col.ToArgb());
        //    ctrl.Text = s;
        //    ctrl.ForeColor = (col.GetBrightness() < 0.6) ? (Color.White) : (Color.Black);
        //}

        //public static void SetForeColor(Control ctrl, Color col)
        //{
        //    ctrl.ForeColor = col;

        //    string s = string.Format("{0}\r\n{1:X}", col.Name, col.ToArgb());
        //    ctrl.Text = s;

        //    ctrl.BackColor = (col.GetBrightness() < 0.6) ? (Color.White) : (Color.Black);
        //}

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
