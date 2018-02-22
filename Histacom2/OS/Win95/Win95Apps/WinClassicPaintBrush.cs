using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Text;
using static Histacom2.Engine.FileDialogBoxManager;
using Histacom2.Engine;

namespace Histacom2.OS.Win95.Win95Apps
{
    public partial class WinClassicPaintBrush : UserControl
    {
        Color paintcolor = Color.Black;
        Pen pen;
        bool choose = false;  //never used, but I will using it in the future!
        bool draw = false;
        int x, y, lx, ly = 0; //same for lx and ly!
        Item currItem;

        public enum Item
        {
            DeformedSelect, Select, Rubber, Fill, Pen, ColorPicker, Zoom, Brush, Sprayer, Line, DeformedLine, Box, DeformedBox, Ellipse, CircledBox,
        }

        WindowManager wm = new WindowManager();
        public WinClassicPaintBrush()
        {
            // Toolstripmenu zone
            InitializeComponent();
            foreach (ToolStripMenuItem item in topmenu.Items)
            {
                item.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
                item.BackColor = Color.Silver;
                item.BackgroundImage = Properties.Resources.sliversilver;
                item.BackgroundImageLayout = ImageLayout.Center;
                item.DisplayStyle = ToolStripItemDisplayStyle.Text;
            }

            this.closeToolStripMenuItem.Click += (sender, args) => ((Form)this.TopLevelControl).Close(); //File>Exit
            this.aboutToolStripMenuItem.Click += (sender, args) => wm.StartAboutBox95("Paintbrush", "Microsoft Paintbrush", Properties.Resources.Win95IconPaintAbout); //Help>About..
            //this.undoToolStripMenuItem.Click += (sender, args) => canvas.UnDo();

            //

            // Time to prepare to load all the fonts up for the combo boxes
            //foreach (FontFamily font in FontFamily.Families) comboFont.Items.Add(font.Name);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canvas.Refresh();
        }

        // Drawing Functions

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (currItem == Item.ColorPicker)
            {
                Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);
                Graphics g = Graphics.FromImage(bmp);
                Rectangle rect = canvas.RectangleToScreen(canvas.ClientRectangle);
                g.CopyFromScreen(rect.Location, Point.Empty, canvas.Size);
                paintcolor = bmp.GetPixel(e.X, e.Y);
                pictureBox56.BackColor = paintcolor;
                bmp.Dispose();
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            x = e.X;
            y = e.Y;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
            /*
            draw = false;
            lx = e.X;
            ly = e.Y;
            if(currItem == Item.Pen)
            */
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Graphics g = canvas.CreateGraphics();
                switch (currItem)
                {
                    case Item.Box:
                        g.FillRectangle(new SolidBrush(paintcolor), x, y, e.X - x, e.Y - y);
                        break;
                    case Item.Ellipse:
                        g.FillEllipse(new SolidBrush(paintcolor), x, y, e.X - x, e.Y - y);
                        break;
                    case Item.Pen:
                        //g.FillEllipse(new SolidBrush(paintcolor), e.X - x + x, e.Y - y + y, 2, 2);
                        pen = new Pen(paintcolor, 1);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //no spaces between the line
                        pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        g.DrawLine(pen, new Point(x, y), e.Location);
                        x = e.X;
                        y = e.Y;
                        break;
                    case Item.Brush:
                        pen = new Pen(paintcolor, 5);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //no spaces between the line
                        pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        g.DrawLine(pen, new Point(x, y), e.Location);
                        x = e.X;
                        y = e.Y;
                        break;
                    case Item.Rubber:
                        pen = new Pen(canvas.BackColor, 10);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //no spaces between the line
                        pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
                        g.DrawLine(pen, new Point(x, y), e.Location);
                        x = e.X;
                        y = e.Y;
                        break;
                }
                g.Dispose();
            }
        }

        private void canvas_Click(object sender, EventArgs e)
        {

        }

        // ----------------  Color Picking --------------------

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox1.BackColor;
            paintcolor = pictureBox1.BackColor;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox2.BackColor;
            paintcolor = pictureBox2.BackColor;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox3.BackColor;
            paintcolor = pictureBox3.BackColor;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox4.BackColor;
            paintcolor = pictureBox4.BackColor;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox5.BackColor;
            paintcolor = pictureBox5.BackColor;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox6.BackColor;
            paintcolor = pictureBox6.BackColor;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox7.BackColor;
            paintcolor = pictureBox7.BackColor;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox8.BackColor;
            paintcolor = pictureBox8.BackColor;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox9.BackColor;
            paintcolor = pictureBox9.BackColor;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox11.BackColor;
            paintcolor = pictureBox11.BackColor;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox10.BackColor;
            paintcolor = pictureBox10.BackColor;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox12.BackColor;
            paintcolor = pictureBox12.BackColor;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox13.BackColor;
            paintcolor = pictureBox13.BackColor;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox14.BackColor;
            paintcolor = pictureBox14.BackColor;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox15.BackColor;
            paintcolor = pictureBox15.BackColor;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox16.BackColor;
            paintcolor = pictureBox16.BackColor;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox18.BackColor;
            paintcolor = pictureBox18.BackColor;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox17.BackColor;
            paintcolor = pictureBox17.BackColor;
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox34.BackColor;
            paintcolor = pictureBox34.BackColor;
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox33.BackColor;
            paintcolor = pictureBox33.BackColor;
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox32.BackColor;
            paintcolor = pictureBox32.BackColor;
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox31.BackColor;
            paintcolor = pictureBox31.BackColor;
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox30.BackColor;
            paintcolor = pictureBox30.BackColor;
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox29.BackColor;
            paintcolor = pictureBox29.BackColor;
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox28.BackColor;
            paintcolor = pictureBox28.BackColor;
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox27.BackColor;
            paintcolor = pictureBox27.BackColor;
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox26.BackColor;
            paintcolor = pictureBox26.BackColor;
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            pictureBox56.BackColor = pictureBox24.BackColor;
            paintcolor = pictureBox24.BackColor;
        }

        private void pictureBox56_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void pictureBox59_Click(object sender, EventArgs e)
        {
            
        }

        // Tool select

        public void Reset_buttons()
        {
            btnUnderline.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonStar;
            button1.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonSelectNormal;
            button3.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonRubber;
            button2.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonFill;
            button5.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonPicker;
            button4.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonZoom;
            button11.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonPen;
            button10.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonBrush;
            button9.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonSprayer;
            button8.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonText;
            button7.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonLine;
            button6.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonSquareLine;
            button15.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonTriangle;
            button14.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonDeformedTriangle;
            button13.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonCircle;
            button12.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonCircledTriangle;
        }


        private void button9_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button9.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonSprayerOver;
            canvas.Cursor = Cursors.Default;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button10.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonBrushOver;
            currItem = Item.Brush;
            canvas.Cursor = CreateCursor(Properties.Resources.WinCLassicPaintBrushCursorBrush, new Size(19, 19));
        }

        private void btnUnderline_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            btnUnderline.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonStarOver;
            canvas.Cursor = Cursors.Default;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button1.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonSelectNormalOver;
            canvas.Cursor = Cursors.Default;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button3.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonRubberOver;
            currItem = Item.Rubber;
            canvas.Cursor = CreateCursor(Properties.Resources.WinClassicPaintBrushCursorRubber, new Size(10, 10));
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button13.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonCircleOver;
            currItem = Item.Ellipse;
            canvas.Cursor = CreateCursor(Properties.Resources.WinClassicPaintBrushCursorShape, new Size(21, 21));
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button12.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonCircledTriangleOver;
            canvas.Cursor = Cursors.Default;
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button14.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonDeformedTriangleOver;
            canvas.Cursor = Cursors.Default;
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button15.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonTriangleOver;
            currItem = Item.Box;
            canvas.Cursor = CreateCursor(Properties.Resources.WinClassicPaintBrushCursorShape, new Size(21, 21));
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button7.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonLineOver;
            canvas.Cursor = Cursors.Default;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button6.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonSquareLineOver;
            canvas.Cursor = Cursors.Default;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button8.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonTextOver;
            canvas.Cursor = Cursors.Default;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button11.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonPenOver;
            currItem = Item.Pen;
            canvas.Cursor = CreateCursor(Properties.Resources.WinClassicPaintBrushCursorPen2, new Size(30, 30));
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button4.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonZoomOver;
            canvas.Cursor = Cursors.Default;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button2.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonFillOver;
            canvas.Cursor = Cursors.Default;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Reset_buttons();
            button5.BackgroundImage = Properties.Resources.WinClassicPaintBrushButtonPickerOver;
            currItem = Item.ColorPicker;
            canvas.Cursor = CreateCursor(Properties.Resources.WinClassicPaintBrushCursorColorpicker2, new Size(28, 28));
        }

        public static Cursor CreateCursor(Bitmap bm, Size size)
        {
            bm = new Bitmap(bm, size);
            return new Cursor(bm.GetHicon());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Cursor = CreateCursor(Properties.Resources.WinClassicCursorNormal, new Size(11, 19));
        }

        // Random shit I cant get rid of


        private void WinClassicPaintBrush_Load(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // -----------------------------------------------
    }
}
