using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Traffic_Light_Simulator_2020__MIS_
{
    public partial class Kreuzung : UserControl
    {
        Graphics gGrass;
        Graphics gLines;
        RectangleF[] rfGrass;
        readonly Pen whitePen = new Pen(Color.White);
        readonly Pen whiteDashes = new Pen(Color.White);

        public Kreuzung()
        {
            InitializeComponent();
        }

        private void KreuzungSkizze_Paint(object sender, PaintEventArgs e)
        {
            gGrass = KreuzungSkizze.CreateGraphics();
            gLines = KreuzungSkizze.CreateGraphics();

            rfGrass = new RectangleF[3];
            rfGrass[0] = new RectangleF(0, 0, 860, 250);
            rfGrass[1] = new RectangleF(1060, 0, 900, 250);
            rfGrass[2] = new RectangleF(0, 630, 1920, 200);

            gGrass.FillRectangle(Brushes.ForestGreen, rfGrass[0]);
            gGrass.FillRectangle(Brushes.ForestGreen, rfGrass[1]);
            gGrass.FillRectangle(Brushes.ForestGreen, rfGrass[2]);

            whitePen.Width = 10.0F;
            //Hauptstraße
            gLines.DrawLine(whitePen, 0, 260, 865, 260);
            gLines.DrawLine(whitePen, 1055, 260, 1920, 260);
            gLines.DrawLine(whitePen, 0, 620, 1920, 620);
            gLines.DrawLine(whitePen, 0, 380, 750, 380);
            gLines.DrawLine(whitePen, 1060, 380, 1920, 380);
            gLines.DrawLine(whitePen, 1065, 385, 1065, 500);
            gLines.DrawLine(whitePen, 1065, 500, 1185, 380);
            gLines.DrawLine(whitePen, 1065, 440, 1125, 380);
            gLines.DrawLine(whitePen, 755, 375, 755, 500);
            gLines.DrawLine(whitePen, 430, 500, 1060, 500);
            gLines.DrawLine(whitePen, 865, 495, 865, 620);  //Haltelinie Gerade
            gLines.DrawLine(whitePen, 1090, 260, 1090, 375);

            //Nebenstraße
            gLines.DrawLine(whitePen, 870, 0, 870, 265);
            gLines.DrawLine(whitePen, 1050, 0, 1050, 265);
            gLines.DrawLine(whitePen, 870, 185, 965, 185);


            //Pfeile
            //Pfeil Links
            PointF[] pfeilLinks = new PointF[4];
            pfeilLinks[0] = new PointF(480, 470);
            pfeilLinks[1] = new PointF(630, 470);
            pfeilLinks[2] = new PointF(650, 450);
            pfeilLinks[3] = new PointF(650, 410);
            PointF[] pfeilLinksSpitze = new PointF[3];
            pfeilLinksSpitze[0] = new PointF(630, 430);
            pfeilLinksSpitze[1] = new PointF(650, 410);
            pfeilLinksSpitze[2] = new PointF(670, 430);
            gLines.DrawLines(whitePen, pfeilLinks);
            gLines.DrawLines(whitePen, pfeilLinksSpitze);

            //Pfeil gerade aus.
            gLines.DrawLine(whitePen, 590, 560, 760, 560);
            PointF[] pfeilGeradeSpitze = new PointF[3];
            pfeilGeradeSpitze[0] = new PointF(740, 540);
            pfeilGeradeSpitze[1] = new PointF(760, 560);
            pfeilGeradeSpitze[2] = new PointF(740, 580);
            gLines.DrawLines(whitePen, pfeilGeradeSpitze);

            //PfeilGeradeRechts
            PointF[] pfeilrechts = new PointF[4];
            pfeilrechts[0] = new PointF(1400, 320);
            pfeilrechts[1] = new PointF(1270, 320);
            pfeilrechts[2] = new PointF(1255, 305);
            pfeilrechts[3] = new PointF(1255, 280);
            gLines.DrawLines(whitePen, pfeilrechts);
            //PfeilGeradeRechtsSpitze
            PointF[] pfeilGeradeRechtsSpitze = new PointF[3];
            pfeilGeradeRechtsSpitze[0] = new PointF(1235, 300);
            pfeilGeradeRechtsSpitze[1] = new PointF(1255, 280);
            pfeilGeradeRechtsSpitze[2] = new PointF(1275, 300);
            gLines.DrawLines(whitePen, pfeilGeradeRechtsSpitze);
            //PfeilRechtsGerade
            gLines.DrawLine(whitePen, 1270, 320, 1185, 320);
            PointF[] pfeilRechtsGeradeSpitze = new PointF[3];
            pfeilRechtsGeradeSpitze[0] = new PointF(1205, 300);
            pfeilRechtsGeradeSpitze[1] = new PointF(1185, 320);
            pfeilRechtsGeradeSpitze[2] = new PointF(1205, 340);
            gLines.DrawLines(whitePen, pfeilRechtsGeradeSpitze);

            //gestrichelte Linien
            float[] dashValues = { 3, 2 };
            whiteDashes.DashPattern = dashValues;
            whiteDashes.Width = 10.0F;
            //Hauptstraße
            gLines.DrawLine(whiteDashes, new Point(0, 500), new Point(430, 500));
            gLines.DrawLine(whiteDashes, new Point(870, 485), new Point(1060, 485));
            gLines.DrawLine(whiteDashes, new Point(770, 380), new Point(1060, 380));
            gLines.DrawLine(whiteDashes, new Point(1040, 500), new Point(1920, 500));
            //Nebenstraße
            gLines.DrawLine(whiteDashes, new Point(960, 0), new Point(960, 180));
        }
    }
}



//RectangleF[] grass;
//grass = new RectangleF[2];
//grass[0] = new RectangleF(0, 0, 200, 150);