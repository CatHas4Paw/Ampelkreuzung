using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Traffic_Light_Simulator_2020__MIS_
{
    public partial class Ampel : UserControl
    {
        #region Variablendeklaration/Definition
        public bool greenHaupt;
        int color;
        public int Zustand { get => color; set => color = value; }

        readonly int timeYellow = 3000;
        readonly int timeGreen = 5000;
        readonly int timeRedToGreen = 1500;
        #endregion

        #region Graphics
        Graphics formGraphics;
        RectangleF redsign;
        RectangleF yellowsign;
        RectangleF greensign;
        #endregion

        #region Stopwatch
        public Stopwatch swstop { get; set; }
        public Stopwatch swgo { get; set; }
        public Stopwatch swgreen { get; set; }
        #endregion

        public Ampel()
        {
            InitializeComponent();
            swstop = new Stopwatch();
            swgo = new Stopwatch();
            swgreen = new Stopwatch();
            formGraphics = panel.CreateGraphics();
            timer1.Start();
        }

        //Ampelkreise zeichnen
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Pen black = new Pen(Color.Black);
            black.Width = 3.0F;

            redsign = new RectangleF(3, 3, 20, 20);
            yellowsign = new RectangleF(3, 26, 20, 20);
            greensign = new RectangleF(3, 49, 20, 20);

            formGraphics.DrawEllipse(black, redsign);
            formGraphics.DrawEllipse(black, yellowsign);
            formGraphics.DrawEllipse(black, greensign);
        }

        //Ablauf der Ampelphasen
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (color)
            {
                //Haupt & Nebenstraße
                case 0: //Rot
                    formGraphics.FillEllipse(Brushes.Red, redsign);
                    formGraphics.FillEllipse(Brushes.Black, yellowsign);
                    formGraphics.FillEllipse(Brushes.Black, greensign);
                    //alwaysgreen = false;
                    break;

                //Nebenstraße
                case 1: //Rot, Gelb
                    formGraphics.FillEllipse(Brushes.Red, redsign);
                    formGraphics.FillEllipse(Brushes.Yellow, yellowsign);
                    formGraphics.FillEllipse(Brushes.Black, greensign);
                    color++;
                    break;

                case 2: //Grün
                    if (swgo.ElapsedMilliseconds >= timeRedToGreen)
                    {
                        formGraphics.FillEllipse(Brushes.Black, redsign);
                        formGraphics.FillEllipse(Brushes.Black, yellowsign);
                        formGraphics.FillEllipse(Brushes.Green, greensign);
                        swgo.Reset();
                        swgreen.Start();
                        color++;
                    }
                    break;
                //Haupt & Nebenstraße
                case 3: //Gelb
                    if (swgreen.ElapsedMilliseconds >= timeGreen || greenHaupt == true)
                    {
                        formGraphics.FillEllipse(Brushes.Black, redsign);
                        formGraphics.FillEllipse(Brushes.Yellow, yellowsign);
                        formGraphics.FillEllipse(Brushes.Black, greensign);
                        swgreen.Reset();
                        swstop.Start();
                    }
                    if (swstop.ElapsedMilliseconds >= timeYellow)
                    {
                        color = 0;
                        swstop.Reset();
                    }
                    break;
                //Hauptstraße
                case 4: //Rot, Gelb
                    formGraphics.FillEllipse(Brushes.Red, redsign);
                    formGraphics.FillEllipse(Brushes.Yellow, yellowsign);
                    formGraphics.FillEllipse(Brushes.Black, greensign);
                    if (swgo.ElapsedMilliseconds >= timeRedToGreen)
                    {
                        color = 5;
                    }
                    break;
                case 5: //Grün
                    formGraphics.FillEllipse(Brushes.Black, redsign);
                    formGraphics.FillEllipse(Brushes.Black, yellowsign);
                    formGraphics.FillEllipse(Brushes.Green, greensign);
                    greenHaupt = true;
                    swgo.Reset();
                    break;
            }
        }
    }
}