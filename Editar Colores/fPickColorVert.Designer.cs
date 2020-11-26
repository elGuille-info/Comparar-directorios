
namespace Editar_Colores
{
    partial class fPickColorVert
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.wellPanel1 = new Editar_Colores.WellPanel();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.Location = new System.Drawing.Point(85, 337);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblBackColor
            // 
            this.lblBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBackColor.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackColor.Location = new System.Drawing.Point(12, 281);
            this.lblBackColor.Margin = new System.Windows.Forms.Padding(3);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(148, 39);
            this.lblBackColor.TabIndex = 6;
            this.lblBackColor.Text = "Black\r\nFF000000";
            this.lblBackColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wellPanel1
            // 
            this.wellPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wellPanel1.Color = System.Drawing.Color.Black;
            this.wellPanel1.ColorScheme = Editar_Colores.WellPanel.Scheme.Web;
            this.wellPanel1.Columns = 0;
            this.wellPanel1.Location = new System.Drawing.Point(12, 12);
            this.wellPanel1.Name = "wellPanel1";
            this.wellPanel1.Size = new System.Drawing.Size(148, 260);
            this.wellPanel1.SortOrder = Editar_Colores.WellPanel.Order.Hue;
            this.wellPanel1.TabIndex = 7;
            this.wellPanel1.WellSize = new System.Drawing.Size(16, 16);
            this.wellPanel1.ColorChanged += new Editar_Colores.WellPanel.ColorChangedEventHandler(this.wellPanel1_ColorChanged);
            // 
            // fPickColorVert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 370);
            this.Controls.Add(this.wellPanel1);
            this.Controls.Add(this.lblBackColor);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fPickColorVert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Color";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblBackColor;
        private WellPanel wellPanel1;
    }
}