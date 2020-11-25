
namespace Editar_Colores
{
    partial class fPickColor
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
            this.components = new System.ComponentModel.Container();
            this.ctPicker = new Editar_Colores.ctlColorPanel();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.duSort = new System.Windows.Forms.DomainUpDown();
            this.duScheme = new System.Windows.Forms.DomainUpDown();
            this.lblForeColor = new System.Windows.Forms.Label();
            this.FlowPanelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.FlowPanelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctPicker
            // 
            this.ctPicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctPicker.Color = System.Drawing.Color.Black;
            this.ctPicker.ColorScheme = Editar_Colores.WellPanel.Scheme.Web;
            this.ctPicker.Columns = 0;
            this.ctPicker.Location = new System.Drawing.Point(12, 41);
            this.ctPicker.Margin = new System.Windows.Forms.Padding(6);
            this.ctPicker.Name = "ctPicker";
            this.ctPicker.Size = new System.Drawing.Size(292, 132);
            this.ctPicker.SortOrder = Editar_Colores.WellPanel.Order.Hue;
            this.ctPicker.TabIndex = 4;
            this.ctPicker.WellSize = new System.Drawing.Size(16, 16);
            this.ctPicker.ColorChanged += new Editar_Colores.WellPanel.ColorChangedEventHandler(this.ctPicker_ColorChanged);
            // 
            // lblBackColor
            // 
            this.lblBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBackColor.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackColor.Location = new System.Drawing.Point(12, 182);
            this.lblBackColor.Margin = new System.Windows.Forms.Padding(3);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(145, 84);
            this.lblBackColor.TabIndex = 5;
            this.lblBackColor.Text = "Nombre color:\r\nvalor x";
            this.lblBackColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Orden";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label1, "El orden de los colores");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Esquema";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label2, "El esquema de los colores");
            // 
            // duSort
            // 
            this.duSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.duSort.BackColor = System.Drawing.SystemColors.Control;
            this.duSort.Location = new System.Drawing.Point(220, 12);
            this.duSort.Name = "duSort";
            this.duSort.Size = new System.Drawing.Size(88, 20);
            this.duSort.TabIndex = 3;
            this.duSort.SelectedItemChanged += new System.EventHandler(this.duSort_SelectedItemChanged);
            // 
            // duScheme
            // 
            this.duScheme.BackColor = System.Drawing.SystemColors.Control;
            this.duScheme.Location = new System.Drawing.Point(69, 12);
            this.duScheme.Name = "duScheme";
            this.duScheme.Size = new System.Drawing.Size(88, 20);
            this.duScheme.TabIndex = 1;
            this.duScheme.SelectedItemChanged += new System.EventHandler(this.duScheme_SelectedItemChanged);
            // 
            // lblForeColor
            // 
            this.lblForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblForeColor.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForeColor.Location = new System.Drawing.Point(163, 182);
            this.lblForeColor.Margin = new System.Windows.Forms.Padding(3);
            this.lblForeColor.Name = "lblForeColor";
            this.lblForeColor.Size = new System.Drawing.Size(145, 84);
            this.lblForeColor.TabIndex = 6;
            this.lblForeColor.Text = "Nombre color:\r\nvalor x\r\n";
            this.lblForeColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlowPanelBotones
            // 
            this.FlowPanelBotones.Controls.Add(this.btnCancelar);
            this.FlowPanelBotones.Controls.Add(this.btnAceptar);
            this.FlowPanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowPanelBotones.Location = new System.Drawing.Point(0, 283);
            this.FlowPanelBotones.Name = "FlowPanelBotones";
            this.FlowPanelBotones.Size = new System.Drawing.Size(320, 46);
            this.FlowPanelBotones.TabIndex = 7;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(233, 8);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 8, 12, 8);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.Location = new System.Drawing.Point(147, 8);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(320, 329);
            this.Controls.Add(this.FlowPanelBotones);
            this.Controls.Add(this.lblForeColor);
            this.Controls.Add(this.duScheme);
            this.Controls.Add(this.duSort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBackColor);
            this.Controls.Add(this.ctPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(336, 200);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar color";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FlowPanelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctlColorPanel ctPicker;
        private System.Windows.Forms.Label lblBackColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DomainUpDown duSort;
        private System.Windows.Forms.DomainUpDown duScheme;
        private System.Windows.Forms.Label lblForeColor;
        private System.Windows.Forms.FlowLayoutPanel FlowPanelBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}