using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.ComponentModel;

namespace MEA_AP
{
    public class CustomGrpBox : GroupBox
    {
        private string _Text = "";

        private Color _BorderColor = Color.Black;

        public CustomGrpBox()
        {
            //set the base text to empty 
            //base class will draw empty string
            //in such way we see only text what we draw
            base.Text = "";
        }

        // Create a new property a
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue("GroupBoxText")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new string Text
        {
            get { return _Text; }

            set
            {
                _Text = value;
                this.Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            // first let the base class to draw the control 
            base.OnPaint(e);

            // create a brush with fore color
            SolidBrush colorBrush = new SolidBrush(this.ForeColor);

            // create a brush with back color
            var backColor = new SolidBrush(this.BackColor);

            // measure the text size
            var size = TextRenderer.MeasureText(this.Text, this.Font);

            // evaluate the postiong of text from left;
            int left = (this.Width - size.Width) / 2;

            // draw a fill rectangle in order to remove the border
            e.Graphics.FillRectangle(backColor, new Rectangle(left, 0, size.Width, size.Height));

            // draw the text Now
            e.Graphics.DrawString(this.Text, this.Font, colorBrush, new PointF(left, 0));

        }
    }

}
