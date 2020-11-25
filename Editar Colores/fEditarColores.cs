//-----------------------------------------------------------------------------
// Editar colores                                                   (25/Nov/20)
// Utilidad para editar los colores de Comparar directorios
//
// Se mostrarán todos los colores y se podrán modificar
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

namespace Editar_Colores
{
    public partial class fEditarColores : Form
    {
        public fEditarColores(Color backColor, Color foreColor) : this()
        {
            lblBackColor.BackColor = backColor;
            lblForeColor.BackColor = foreColor;
        }

        public fEditarColores()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// El título de la aplicación
        /// </summary>
        public string Titulo { 
            get { return this.Text; }
            set { this.Text = value; }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            labelInfo.Width = FlowPanelBotones.ClientRectangle.Width - (btnAceptar.Width * 2 + 30);
        }

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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            fPickColor fPicker = new fPickColor
            {
                ElColor = lblBackColor.BackColor
            };
            if (fPicker.ShowDialog() == DialogResult.OK)
            {
                lblBackColor.BackColor = fPicker.ElColor;
                //lblForeColor.ForeColor = fPicker.ElColor;
            }
        }

        private void btnSeleccionarFore_Click(object sender, EventArgs e)
        {
            fPickColor fPicker = new fPickColor
            {
                ElColor = lblForeColor.BackColor
            };
            if (fPicker.ShowDialog() == DialogResult.OK)
            {
                //lblBackColor.BackColor = fPicker.ElColor;
                lblForeColor.ForeColor = fPicker.ElColor;
            }
        }
    }
}
