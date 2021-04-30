using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Traffic_Light_Simulator_2020__MIS_
{
    public partial class Simulator : Form
    {
        #region CarMove Variables
        #region integer
        private int iCar1X = -50;
        private int iCar1Y = 535;
        private int iCar2X = -50;
        private int iCar2Y = 415;
        private int iCar3X = 890;
        private int iCar3Y = -50;
        private int iCar4X = 1920;
        private int iCar4Y = 300;
        private readonly int iCarSpeedNormal = 10;
        private readonly int iCarSpeedFast = 10;
        #endregion integer
        #region Random + integer
        private int iCar3LR;
        private Random Car3LR = new Random();
        private int iCar4RG;
        private Random Car4RG = new Random();
        private int iSpurwechsel;
        private Random rSpurwechsel = new Random();
        #endregion Random + integer
        #region boolean
        private bool bCar3L = false;
        private bool bCar3R = false;
        private bool bCar4G = false;
        private bool bCar4R = false;
        private bool bLeftFertig = true;
        private bool bOutFertig = true;
        private bool bCar1_enable = false;
        private bool bCar2_enable = false;
        private bool bCar3_enable = false;
        private bool bCar4_enable = false;
        #endregion boolean
        #endregion

        #region Counter Variables
        private int iCountGeradeRechts = 0;
        private int iCountGerade = 0;
        private int iCountNeben = 0;
        private int iCountLinks = 0;
        private int iCountCar1 = 0;
        private int iCountCar2 = 0;
        private int iCountCar3 = 0;
        private int iCountCar4 = 0;
        private readonly bool bCounterEnabled = false;
        #endregion Counter Variables

        #region Steuerung Variables
        private readonly int timegreenMinHaupt = 10000;
        private int iBLF = 0;
        private int iBOF = 0;
        private long lTimer = 0;
        private bool pushLeft = false;
        private bool leftPush = false;
        private bool pushOut = false;
        private bool outPush = false;
        private bool bothTurn = false;
        private bool leftEmpty = false;
        private bool nebenEmpty = false;
        private bool bLeftFlash = false;
        private bool bOutFlash = false;
        #endregion Steuerungs Variables

        #region Stopwatches
        Stopwatch swgreenMinHaupt = new Stopwatch();
        Stopwatch swAppGeeoffnet = new Stopwatch();
        #endregion Stopwatches

        public Simulator()
        {
            //this.Location = new Point(-1920, 100);
            InitializeComponent();
            AmpelGeradeRechts.Zustand = 5;
            AmpelGerade.Zustand = 5;
            swgreenMinHaupt.Start();
            swAppGeeoffnet.Start();
            CarMove.Start();
        }

        #region Benutzereingaben
        private void cLB_Cars_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Car1
            if (cLB_Cars.GetItemChecked(0) == true)
                bCar1_enable = true;
            else
                bCar1_enable = false;
            #endregion Car1
            #region Car2
            if (cLB_Cars.GetItemChecked(1) == true)
                bCar2_enable = true;
            else
                bCar2_enable = false;
            #endregion Car2
            #region Car3
            if (cLB_Cars.GetItemChecked(2) == true)
                bCar3_enable = true;
            else
                bCar3_enable = false;
            #endregion Car3
            #region Car4
            if (cLB_Cars.GetItemChecked(3) == true)
                bCar4_enable = true;
            else
                bCar4_enable = false;
            #endregion Car4

        }
        private void Left_Click(object sender, EventArgs e)
        {
            if (AmpelLinks.Zustand == 0)
            {
                bLeftFlash = true;
                leftPush = true;
                ButtonFlash.Start();
            }
        }
        private void Out_Click(object sender, EventArgs e)
        {
            if (AmpelNebenstraße.Zustand == 0)
            {
                bOutFlash = true;
                outPush = true;
                ButtonFlash.Start();
            }
        }
        #endregion Benutzeingaben

        #region Ablaufsteuerung
        private void Steuerung_Tick(object sender, EventArgs e)
        {
            #region Textausgaben
            AppGeeoffnet.Text = "Traffic Light Simulator läuft seit: " + Convert.ToString((swAppGeeoffnet.ElapsedMilliseconds / 1000)) + "s";
            MinGreenAusgabe.Text = "Mindestgründauer: " + Convert.ToString(lTimer / -1000) + "s";

            lTimer = swgreenMinHaupt.ElapsedMilliseconds - timegreenMinHaupt;
            if (lTimer <= 0)
                MinGreenAusgabe.ForeColor = Color.White;
            else
                MinGreenAusgabe.ForeColor = Color.ForestGreen;
            #endregion Textausgaben

            #region Variablenschaltung bei Anforderung beider Kontaktschleifen
            if (outPush == true && leftPush == true && swgreenMinHaupt.ElapsedMilliseconds < timegreenMinHaupt)
            {
                bothTurn = true;
                nebenEmpty = false;
                leftEmpty = false;
                leftPush = false;
                outPush = false;
            }
            #endregion Variablenschaltung bei Anforderung beider Kontaktschleifen

            #region  GeradeRechts auf Grün
            if (AmpelGeradeRechts.Zustand == 0 && AmpelLinks.Zustand == 0 && AmpelNebenstraße.Zustand == 0)
            {
                if (pushLeft != true && pushOut != true && bothTurn != true)
                {
                    Thread GeradeRechtsAufGrünCaller = new Thread(this.thGeradeRechtsAufGrün);
                    GeradeRechtsAufGrünCaller.Start();
                }
            }
            #endregion GeradeRechts auf Grün

            #region Gerade auf Grün
            if (AmpelGerade.Zustand == 0 && AmpelNebenstraße.Zustand == 0)
            {
                if (pushLeft != true && pushOut != true && bothTurn != true)
                {
                    Thread GeradeAufGrünCaller = new Thread(this.thGeradeAufGrün);
                    //ThreadStart thGeradeAufGrün;
                    GeradeAufGrünCaller.Start();
                }
            }
            #endregion Gerade auf Grün

            #region Linksabieger Grün
            if (leftPush == true && bothTurn == false)
            {
                if (swgreenMinHaupt.ElapsedMilliseconds >= timegreenMinHaupt && AmpelLinks.Zustand == 0 && AmpelNebenstraße.Zustand == 0 && AmpelGeradeRechts.Zustand == 5)
                {
                    pushLeft = true;
                    leftPush = false;
                }
            }
            if (pushLeft == true)
            {
                Thread GeradeRechtsAufRotCaller = new Thread(this.thGeradeRechtsAufRot);
                GeradeRechtsAufRotCaller.Start();
                if (AmpelGeradeRechts.Zustand == 0)
                {
                    Thread LinksabiegerCaller = new Thread(this.thLinksabieger);
                    LinksabiegerCaller.Start();
                    pushLeft = false;
                }
            }
            #endregion Linksabieger Grün

            #region Nebenstraße auf Grün
            if (outPush == true && bothTurn == false)
            {
                if (swgreenMinHaupt.ElapsedMilliseconds >= timegreenMinHaupt && AmpelLinks.Zustand == 0 && AmpelNebenstraße.Zustand == 0 && AmpelGerade.Zustand == 5 && AmpelGeradeRechts.Zustand == 5)
                {
                    pushOut = true;
                    outPush = false;
                }
            }
            if (pushOut == true)
            {
                #region Hauptstraße auf Rot
                Thread GeradeRechtsAufRotCaller = new Thread(this.thGeradeRechtsAufRot);
                Thread GeradeAufRotCaller = new Thread(this.thGeradeAufRot);
                GeradeRechtsAufRotCaller.Start();
                GeradeAufRotCaller.Start();
                #endregion Hauptstraße auf Rot
                //Nebenstraße auf Grün umschaten
                if (AmpelGerade.Zustand == 0 && AmpelGeradeRechts.Zustand == 0)
                {
                    Thread NebenstraßeCaller = new Thread(this.thNebenstraße);
                    NebenstraßeCaller.Start();
                    pushOut = false;
                }

            }
            #endregion Nebenstraße auf Grün

            #region Anforderung beider Kontaktschleifen
            //Linksabiegen & Nebenstraße im gleichen Zyklus -> Linksabieger Grün -> Linksabieger Rot -> Nebenstraße Grün -> Nebenstraße Rot
            if (bothTurn == true && swgreenMinHaupt.ElapsedMilliseconds >= timegreenMinHaupt)
            {
                swgreenMinHaupt.Stop();
                //AmpelGerade auf Rot
                if (AmpelGerade.Zustand == 5 && AmpelGeradeRechts.Zustand == 0 && AmpelLinks.Zustand == 0 && AmpelNebenstraße.Zustand == 0 && leftEmpty == true && nebenEmpty == false)
                {
                    Thread GeradeAufRotCaller = new Thread(this.thGeradeAufRot);
                    GeradeAufRotCaller.Start();
                }
                //AmpelGeradeRechts auf Rot
                if (AmpelGerade.Zustand == 5 && AmpelGeradeRechts.Zustand == 5 && AmpelLinks.Zustand == 0 && AmpelNebenstraße.Zustand == 0 && leftEmpty == false && nebenEmpty == false)
                {
                    Thread GeradeRechtsAufRotCaller = new Thread(this.thGeradeRechtsAufRot);
                    GeradeRechtsAufRotCaller.Start();
                }
                //AmpelNebenstraße auf Grün, wenn alle Ampeln auf Rot
                if (AmpelGerade.Zustand == 0 && AmpelGeradeRechts.Zustand == 0 && AmpelLinks.Zustand == 0 && AmpelNebenstraße.Zustand == 0 && leftEmpty == true && nebenEmpty == false)
                {
                    Thread NebenstraßeCaller = new Thread(this.thNebenstraße);
                    NebenstraßeCaller.Start();
                    nebenEmpty = true;
                    bothTurn = false;
                    swgreenMinHaupt.Reset();
                }
                //AmpelLinks auf Grün, wenn AmpelGeradeRechts & AmpelNebenstraße auf Rot
                if (AmpelGerade.Zustand == 5 && AmpelGeradeRechts.Zustand == 0 && AmpelLinks.Zustand == 0 && AmpelNebenstraße.Zustand == 0 && leftEmpty == false && nebenEmpty == false)
                {
                    Thread LinksabiegerCaller = new Thread(this.thLinksabieger);
                    LinksabiegerCaller.Start();
                    leftEmpty = true;
                }
            }
            #endregion Anforderung beider Kontaktschleifen

            #region Zähler Ampel & cars
            if (bCounterEnabled == true)
            {
                textBox1.ForeColor = Color.White;
                textBox1.Text = string.Format(@"Ampel Gerade:       " + Convert.ToString(iCountGerade) + "Autos: " + Convert.ToString(iCountCar1) + Environment.NewLine +
                                              @"Ampel Links:        " + Convert.ToString(iCountLinks) + "Autos: " + Convert.ToString(iCountCar2) + Environment.NewLine +
                                              @"Ampel Nebenstraße:  " + Convert.ToString(iCountNeben) + "Autos: " + Convert.ToString(iCountCar3) + Environment.NewLine +
                                              @"Ampel GeradeRechts: " + Convert.ToString(iCountGeradeRechts) + "Autos: " + Convert.ToString(iCountCar4));
            }
            else
                textBox1.ForeColor = Color.ForestGreen;
            #endregion Zähler Ampel & Cars
        }
        #endregion Ablaufsteuerung

        #region Buttonflash
        private void ButtonFlash_Tick(object sender, EventArgs e)
        {
            #region Left Button Flash
            if (bLeftFlash == true)
            {
                if (iBLF % 2 == 0)
                    Left.BackColor = Color.LightGreen;
                else
                    Left.BackColor = Color.Ivory;
                iBLF++;

                if (AmpelLinks.Zustand != 0)
                {
                    bLeftFlash = false;
                    Left.BackColor = Color.Ivory;
                    iBLF = 0;
                }
            }
            #endregion Left Button Flash
            #region Out Button Flash
            if (bOutFlash == true)
            {
                if (iBOF % 2 == 0)
                    Out.BackColor = Color.LightGreen;
                else
                    Out.BackColor = Color.Ivory;
                iBOF++;

                if (AmpelNebenstraße.Zustand != 0)
                {
                    bOutFlash = false;
                    Out.BackColor = Color.Ivory;
                    iBOF = 0;
                }
            }
            #endregion Out Button Flash
            #region Timer Stoppen, wenn nicht benötigt
            if (bOutFlash == false && bLeftFlash == false)
                ButtonFlash.Stop();
            #endregion Timer Stoppen, wenn nicht benötigt
        }
        #endregion ButtonFlash

        #region CarMove
        private void CarMove_Tick(object sender, EventArgs e)
        {

            #region Car1 fährt gerade aus
            if (bCar1_enable == true)
            {
                #region Stop an Ampel
                if (iCar1X >= 789 && iCar1X <= 801 && AmpelGerade.Zustand != 5)
                { }
                #endregion Stop an Ampel
                #region Fahrbefehle
                else
                {
                    //Zufall für Spurwechsel nach Ampel
                    if (iCar1X <= 1100)
                        iSpurwechsel = rSpurwechsel.Next(0, 2);
                    //Spurwechsel
                    if (iCar1X == 1100 && iSpurwechsel == 1)
                    {
                        iCar1Y -= iCarSpeedNormal / 2;
                        iCar1X += iCarSpeedNormal;
                    }
                    //Gerade aus ohne Spurwechsel
                    else
                        iCar1X += iCarSpeedNormal;
                    //Gerade mit Spurwechsel
                    if (iCar1X >= 1100 && iCar1Y < 535)
                    {
                        if (iCar1Y >= 415)
                            iCar1Y -= iCarSpeedNormal - 3;
                        iCar1X += iCarSpeedFast;
                    }
                }
                //Zurücksetzen
                if (iCar1X >= 1920)
                {
                    iCar1X = -50;
                    iCar1Y = 535;
                    iCountCar1++;
                }
                this.Car1.Location = new Point(iCar1X, iCar1Y);
                #endregion Fahrbefehle
            }
            #endregion Car1
            #region Car2 biegt links ab
            if (bCar2_enable == true)
            {
                #region Stop Bei Rot & Anforderung Kontaktschleife
                if (iCar2X >= 689 && iCar2X <= 701 && AmpelLinks.Zustand != 3)
                {
                    ButtonFlash.Start();
                    if (bLeftFlash == false)
                        bLeftFlash = true;
                    if (bLeftFertig == true)
                    {
                        bLeftFertig = false;
                        //leftPush = true;
                        Left_Click(sender, e);
                    }
                }
                #endregion
                #region Fahrbefehle
                else
                {
                    //Gerade
                    if (iCar2X < 850)
                        iCar2X += iCarSpeedNormal;
                    //Kurve
                    if (iCar2X >= 850 && iCar2X <= 975)
                    {
                        iCar2X += iCarSpeedNormal / 2;
                        iCar2Y -= iCarSpeedNormal / 2;
                    }
                    //Gerade auf Nebenstraße
                    if (iCar2X >= 980)
                        iCar2Y -= iCarSpeedNormal;
                    //Rücksetzen
                    if (iCar2Y <= -50)
                    {
                        iCar2Y = 415;
                        iCar2X = -50;
                        iCountCar2++;
                    }
                }
                this.Car2.Location = new Point(iCar2X, iCar2Y);
                #endregion
            }
            #endregion Car2 biegt links ab
            #region Car3 fährt aus Nebenstraße
            if (bCar3_enable == true)
            {
                #region Stop bei Rot & Kontakschleife Anfordern
                if (iCar3Y >= 109 && iCar3Y <= 121 && AmpelNebenstraße.Zustand != 3)
                {
                    ButtonFlash.Start();
                    if (bOutFlash == false)
                        bOutFlash = true;
                    #region Anforderung der Kontaktschleife
                    if (bOutFertig == true)
                    {
                        Out_Click(sender, e);
                        bOutFertig = false;
                        //outPush = true;
                        //Zufall für Abbiegen
                        iCar3LR = Car3LR.Next(0, 100);
                    }
                    #endregion
                }
                #endregion
                #region Fahrbefehle
                else
                {
                    //Gerade bis zur Ampel
                    if (iCar3Y < 250)
                        iCar3Y += iCarSpeedNormal - 3;
                    //Rechts Abbiegen
                    if (iCar3Y >= 250 && iCar3Y < 280 && (iCar3LR % 2) == 0 && bCar3L == false)
                    {
                        iCar3X -= 2;
                        iCar3Y += 2;
                        bCar3R = true;
                    }
                    if (iCar3Y >= 280 && bCar3R == true)
                        iCar3X -= iCarSpeedNormal;
                    //Zurücksetzen nach Rechts Abbiegen
                    if (iCar3X <= -50 && bCar3R == true)
                    {
                        iCar3X = 890;
                        iCar3Y = -50;
                        bCar3R = false;
                        iCountCar3++;
                    }
                    //Links abbiegen
                    if (iCar3Y >= 250 && iCar3Y < 540 && (iCar3LR % 2) != 0 && bCar3R == false)
                    {
                        iCar3X += iCarSpeedNormal / 5;
                        iCar3Y += (iCarSpeedNormal / 5) * 3;
                        bCar3L = true;
                    }
                    if (iCar3Y >= 535 && bCar3L == true)
                        iCar3X += iCarSpeedNormal;
                    //Rücksetzen nach Links Abbiegen
                    if (iCar3X >= 1920 && bCar3L == true)
                    {
                        iCar3X = 890;
                        iCar3Y = -50;
                        bCar3L = false;
                        iCountCar3++;
                    }
                    this.Car3.Location = new Point(iCar3X, iCar3Y);
                }
                #endregion
            }
            #endregion Car3 fährt aus Nebenstraße
            #region Car4 Fährt von Rechts nach Links
            if (bCar4_enable == true)
            {
                #region Stop bei Rot & Zufall für Abbiegen
                if (iCar4X >= 1080 && iCar4X <= 1100 && AmpelGeradeRechts.Zustand != 5)
                {
                    //Zufall für Abbiegen
                    iCar4RG = Car4RG.Next(0, 100);
                }
                #endregion
                #region Fahrbefehle
                else
                {
                    #region bis zur Ampel
                    if (iCar4X > 1020)
                        iCar4X -= iCarSpeedNormal;
                    #endregion
                    #region Rechts Abbiegen
                    //Kurve
                    if (iCar4X <= 1020 && iCar4X > 980 && (iCar4RG % 2) == 0 && bCar4G == false)
                    {
                        iCar4X -= iCarSpeedNormal / 2;
                        iCar4Y -= iCarSpeedNormal / 2;
                        bCar4R = true;
                    }
                    //Gerade auf Nebenstraße
                    if (iCar4X <= 980 && bCar4R == true)
                        iCar4Y -= iCarSpeedNormal;
                    //Rücksetzen
                    if (iCar4Y <= -50 && bCar4R == true)
                    {
                        iCar4X = 1920;
                        iCar4Y = 300;
                        bCar4R = false;
                        iCountCar4++;
                    }
                    #endregion
                    #region Gerade
                    if (iCar4X <= 1020 && iCar4X > 980 && (iCar4RG % 2) != 0 && bCar4R == false)
                    {
                        iCar4X -= iCarSpeedNormal;
                        bCar4G = true;
                    }
                    if (iCar4X <= 980 && bCar4G == true)
                        iCar4X -= iCarSpeedNormal;
                    //Rücksetzen
                    if (iCar4X <= -50 && bCar4G == true)
                    {
                        iCar4X = 1920;
                        iCar4Y = 300;
                        bCar4G = false;
                        iCountCar4++;
                    }
                    #endregion
                }
                this.Car4.Location = new Point(iCar4X, iCar4Y);
                #endregion
            }
            #endregion Car4 fährt von rechts nach links
        }
        #endregion CarMove

        #region Threadmethoden
        void thNebenstraße()
        {
            if (AmpelNebenstraße.Zustand == 0)
            {
                iCountNeben++;
                AmpelNebenstraße.Zustand = 1;
                AmpelNebenstraße.swgo.Start();
            }
            if (AmpelNebenstraße.Zustand == 2)
            {
                iCountNeben++;
                AmpelNebenstraße.Zustand = 3;
                AmpelNebenstraße.swgreen.Start();
            }
        }
        void thLinksabieger()
        {
            if (AmpelLinks.Zustand == 0)
            {
                iCountLinks++;
                AmpelLinks.Zustand = 1;
                AmpelLinks.swgo.Start();
            }
            if (AmpelLinks.Zustand == 2)
            {
                iCountLinks++;
                AmpelLinks.Zustand = 3;
                AmpelLinks.swgreen.Start();
            }
        }
        void thGeradeRechtsAufRot()
        {
            if (AmpelGeradeRechts.Zustand == 5)
            {
                AmpelGeradeRechts.Zustand = 3;
                AmpelGeradeRechts.greenHaupt = true;
            }
        }
        void thGeradeRechtsAufGrün()
        {
            if (AmpelGeradeRechts.Zustand == 0)
            {
                iCountGeradeRechts++;
                AmpelGeradeRechts.Zustand = 4;
                bLeftFertig = true;
                bOutFertig = true;
                AmpelGeradeRechts.swgo.Start();
                swgreenMinHaupt.Restart();
            }
        }
        void thGeradeAufRot()
        {
            if (AmpelGerade.Zustand == 5)
            {
                AmpelGerade.Zustand = 3;
                AmpelGerade.greenHaupt = true;
            }
        }
        void thGeradeAufGrün()
        {
            if (AmpelGerade.Zustand == 0)
            {
                iCountGerade++;
                bLeftFertig = true;
                bOutFertig = true;
                AmpelGerade.Zustand = 4;
                AmpelGerade.swgo.Start();
            }
        }
        #endregion
    }
}
