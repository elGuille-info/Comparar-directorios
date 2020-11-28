
namespace Editar_Colores
{
    partial class fEditarColores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fEditarColores));
            this.FlowPanelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.lblForeColor = new System.Windows.Forms.Label();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.btnSeleccionarBack = new System.Windows.Forms.Button();
            this.btnSeleccionarFore = new System.Windows.Forms.Button();
            this.FlowPanelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowPanelBotones
            // 
            this.FlowPanelBotones.Controls.Add(this.btnCancelar);
            this.FlowPanelBotones.Controls.Add(this.btnAceptar);
            this.FlowPanelBotones.Controls.Add(this.labelInfo);
            this.FlowPanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowPanelBotones.Location = new System.Drawing.Point(0, 408);
            this.FlowPanelBotones.Name = "FlowPanelBotones";
            this.FlowPanelBotones.Size = new System.Drawing.Size(821, 42);
            this.FlowPanelBotones.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(734, 8);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 8, 12, 8);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.Location = new System.Drawing.Point(648, 8);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.Location = new System.Drawing.Point(20, 12);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(1, 12, 3, 3);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(622, 23);
            this.labelInfo.TabIndex = 4;
            this.labelInfo.Text = "label1";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForeColor
            // 
            this.lblForeColor.BackColor = System.Drawing.Color.Black;
            this.lblForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblForeColor.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForeColor.ForeColor = System.Drawing.Color.BurlyWood;
            this.lblForeColor.Location = new System.Drawing.Point(648, 23);
            this.lblForeColor.Margin = new System.Windows.Forms.Padding(3);
            this.lblForeColor.Name = "lblForeColor";
            this.lblForeColor.Size = new System.Drawing.Size(145, 84);
            this.lblForeColor.TabIndex = 8;
            this.lblForeColor.Text = "Fore Nombre color:\r\nvalor x\r\n";
            this.lblForeColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBackColor
            // 
            this.lblBackColor.BackColor = System.Drawing.Color.BurlyWood;
            this.lblBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBackColor.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackColor.Location = new System.Drawing.Point(497, 23);
            this.lblBackColor.Margin = new System.Windows.Forms.Padding(3);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(145, 84);
            this.lblBackColor.TabIndex = 7;
            this.lblBackColor.Text = "Back Nombre color:\r\nvalor x";
            this.lblBackColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSeleccionarBack
            // 
            this.btnSeleccionarBack.Location = new System.Drawing.Point(497, 113);
            this.btnSeleccionarBack.Name = "btnSeleccionarBack";
            this.btnSeleccionarBack.Size = new System.Drawing.Size(145, 25);
            this.btnSeleccionarBack.TabIndex = 9;
            this.btnSeleccionarBack.Text = "Seleccionar color";
            this.btnSeleccionarBack.UseVisualStyleBackColor = true;
            this.btnSeleccionarBack.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnSeleccionarFore
            // 
            this.btnSeleccionarFore.Location = new System.Drawing.Point(648, 113);
            this.btnSeleccionarFore.Name = "btnSeleccionarFore";
            this.btnSeleccionarFore.Size = new System.Drawing.Size(145, 25);
            this.btnSeleccionarFore.TabIndex = 10;
            this.btnSeleccionarFore.Text = "Seleccionar color";
            this.btnSeleccionarFore.UseVisualStyleBackColor = true;
            this.btnSeleccionarFore.Click += new System.EventHandler(this.btnSeleccionarFore_Click);
            // 
            // fEditarColores
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.Controls.Add(this.btnSeleccionarFore);
            this.Controls.Add(this.btnSeleccionarBack);
            this.Controls.Add(this.lblForeColor);
            this.Controls.Add(this.lblBackColor);
            this.Controls.Add(this.FlowPanelBotones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fEditarColores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar colores";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.FlowPanelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowPanelBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label lblForeColor;
        private System.Windows.Forms.Label lblBackColor;
        private System.Windows.Forms.Button btnSeleccionarBack;
        private System.Windows.Forms.Button btnSeleccionarFore;
    }
}

