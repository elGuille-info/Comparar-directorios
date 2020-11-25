//-----------------------------------------------------------------------------
// ctlColorPanel                                                    (25/Nov/20)
//
// Código de Hannes DuPreez
//
//
// (c) Guillermo (elGuille) Som, 2020
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Windows.Forms;

namespace Editar_Colores
{
    internal delegate void ColorPanelClosingEventHandler(object sender, System.EventArgs e);

    internal class ctlColorPanel : WellPanel
    {
        private IContainer components = null;
        private int width = 300;

        public ctlColorPanel()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Name = "ctlColorPanel";
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (Capture)
            {
                if (!ClientRectangle.Contains(e.X, e.Y))
                {
                    OnClosePanel();
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            Capture = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                OnClosePanel();
            }
        }

        [Browsable(true)]
        internal event ColorPanelClosingEventHandler PanelClosing;

        protected virtual void OnClosePanel()
        {
            PanelClosing?.Invoke(this, new System.EventArgs());
        }

        internal int ParentWidth
        {
            set
            {
                width = value;
                AutoSizePanel();
            }
        }

        protected override int GetPreferredWidth()
        {
            return width;
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            Capture = true;
        }
    }
}
