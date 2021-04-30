namespace Traffic_Light_Simulator_2020__MIS_
{
    partial class Simulator
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simulator));
            System.Diagnostics.Stopwatch stopwatch1 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch2 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch3 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch4 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch5 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch6 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch7 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch8 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch9 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch10 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch11 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch stopwatch12 = new System.Diagnostics.Stopwatch();
            this.Left = new System.Windows.Forms.Button();
            this.Out = new System.Windows.Forms.Button();
            this.Steuerung = new System.Windows.Forms.Timer(this.components);
            this.ButtonFlash = new System.Windows.Forms.Timer(this.components);
            this.MinGreenAusgabe = new System.Windows.Forms.Label();
            this.AppGeeoffnet = new System.Windows.Forms.Label();
            this.Car1 = new System.Windows.Forms.Panel();
            this.CarMove = new System.Windows.Forms.Timer(this.components);
            this.Car2 = new System.Windows.Forms.Panel();
            this.Car3 = new System.Windows.Forms.Panel();
            this.Car4 = new System.Windows.Forms.Panel();
            this.cLB_Cars = new System.Windows.Forms.CheckedListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AmpelGeradeRechts = new Traffic_Light_Simulator_2020__MIS_.Ampel();
            this.AmpelNebenstraße = new Traffic_Light_Simulator_2020__MIS_.Ampel();
            this.AmpelLinks = new Traffic_Light_Simulator_2020__MIS_.Ampel();
            this.AmpelGerade = new Traffic_Light_Simulator_2020__MIS_.Ampel();
            this.KreuzungSim = new Traffic_Light_Simulator_2020__MIS_.Kreuzung();
            this.SuspendLayout();
            // 
            // Left
            // 
            resources.ApplyResources(this.Left, "Left");
            this.Left.BackColor = System.Drawing.Color.Ivory;
            this.Left.Name = "Left";
            this.Left.UseVisualStyleBackColor = true;
            this.Left.Click += new System.EventHandler(this.Left_Click);
            // 
            // Out
            // 
            resources.ApplyResources(this.Out, "Out");
            this.Out.BackColor = System.Drawing.Color.Ivory;
            this.Out.Name = "Out";
            this.Out.UseVisualStyleBackColor = true;
            this.Out.Click += new System.EventHandler(this.Out_Click);
            // 
            // Steuerung
            // 
            this.Steuerung.Enabled = true;
            this.Steuerung.Tick += new System.EventHandler(this.Steuerung_Tick);
            // 
            // ButtonFlash
            // 
            this.ButtonFlash.Interval = 1000;
            this.ButtonFlash.Tick += new System.EventHandler(this.ButtonFlash_Tick);
            // 
            // MinGreenAusgabe
            // 
            resources.ApplyResources(this.MinGreenAusgabe, "MinGreenAusgabe");
            this.MinGreenAusgabe.BackColor = System.Drawing.Color.ForestGreen;
            this.MinGreenAusgabe.ForeColor = System.Drawing.Color.White;
            this.MinGreenAusgabe.Name = "MinGreenAusgabe";
            this.MinGreenAusgabe.Click += new System.EventHandler(this.Steuerung_Tick);
            // 
            // AppGeeoffnet
            // 
            resources.ApplyResources(this.AppGeeoffnet, "AppGeeoffnet");
            this.AppGeeoffnet.BackColor = System.Drawing.Color.ForestGreen;
            this.AppGeeoffnet.ForeColor = System.Drawing.Color.White;
            this.AppGeeoffnet.Name = "AppGeeoffnet";
            // 
            // Car1
            // 
            resources.ApplyResources(this.Car1, "Car1");
            this.Car1.BackColor = System.Drawing.Color.Yellow;
            this.Car1.Name = "Car1";
            // 
            // CarMove
            // 
            this.CarMove.Tick += new System.EventHandler(this.CarMove_Tick);
            // 
            // Car2
            // 
            resources.ApplyResources(this.Car2, "Car2");
            this.Car2.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.Car2.Name = "Car2";
            // 
            // Car3
            // 
            resources.ApplyResources(this.Car3, "Car3");
            this.Car3.BackColor = System.Drawing.Color.Lime;
            this.Car3.Name = "Car3";
            // 
            // Car4
            // 
            resources.ApplyResources(this.Car4, "Car4");
            this.Car4.BackColor = System.Drawing.Color.Aqua;
            this.Car4.Name = "Car4";
            // 
            // cLB_Cars
            // 
            resources.ApplyResources(this.cLB_Cars, "cLB_Cars");
            this.cLB_Cars.BackColor = System.Drawing.Color.LimeGreen;
            this.cLB_Cars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cLB_Cars.FormattingEnabled = true;
            this.cLB_Cars.Items.AddRange(new object[] {
            resources.GetString("cLB_Cars.Items"),
            resources.GetString("cLB_Cars.Items1"),
            resources.GetString("cLB_Cars.Items2"),
            resources.GetString("cLB_Cars.Items3")});
            this.cLB_Cars.Name = "cLB_Cars";
            this.cLB_Cars.SelectedIndexChanged += new System.EventHandler(this.cLB_Cars_SelectedIndexChanged);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BackColor = System.Drawing.Color.ForestGreen;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Name = "textBox1";
            // 
            // AmpelGeradeRechts
            // 
            resources.ApplyResources(this.AmpelGeradeRechts, "AmpelGeradeRechts");
            this.AmpelGeradeRechts.BackColor = System.Drawing.Color.Gray;
            this.AmpelGeradeRechts.Name = "AmpelGeradeRechts";
            this.AmpelGeradeRechts.swgo = stopwatch1;
            this.AmpelGeradeRechts.swgreen = stopwatch2;
            this.AmpelGeradeRechts.swstop = stopwatch3;
            this.AmpelGeradeRechts.Zustand = 0;
            // 
            // AmpelNebenstraße
            // 
            resources.ApplyResources(this.AmpelNebenstraße, "AmpelNebenstraße");
            this.AmpelNebenstraße.BackColor = System.Drawing.Color.Gray;
            this.AmpelNebenstraße.Name = "AmpelNebenstraße";
            this.AmpelNebenstraße.swgo = stopwatch4;
            this.AmpelNebenstraße.swgreen = stopwatch5;
            this.AmpelNebenstraße.swstop = stopwatch6;
            this.AmpelNebenstraße.Zustand = 0;
            // 
            // AmpelLinks
            // 
            resources.ApplyResources(this.AmpelLinks, "AmpelLinks");
            this.AmpelLinks.BackColor = System.Drawing.Color.Gray;
            this.AmpelLinks.Name = "AmpelLinks";
            this.AmpelLinks.swgo = stopwatch7;
            this.AmpelLinks.swgreen = stopwatch8;
            this.AmpelLinks.swstop = stopwatch9;
            this.AmpelLinks.Zustand = 0;
            // 
            // AmpelGerade
            // 
            resources.ApplyResources(this.AmpelGerade, "AmpelGerade");
            this.AmpelGerade.BackColor = System.Drawing.Color.Gray;
            this.AmpelGerade.Name = "AmpelGerade";
            this.AmpelGerade.swgo = stopwatch10;
            this.AmpelGerade.swgreen = stopwatch11;
            this.AmpelGerade.swstop = stopwatch12;
            this.AmpelGerade.Zustand = 0;
            // 
            // KreuzungSim
            // 
            resources.ApplyResources(this.KreuzungSim, "KreuzungSim");
            this.KreuzungSim.BackColor = System.Drawing.Color.Transparent;
            this.KreuzungSim.Name = "KreuzungSim";
            // 
            // Simulator
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cLB_Cars);
            this.Controls.Add(this.AmpelGeradeRechts);
            this.Controls.Add(this.Car4);
            this.Controls.Add(this.AmpelNebenstraße);
            this.Controls.Add(this.Out);
            this.Controls.Add(this.Car3);
            this.Controls.Add(this.Left);
            this.Controls.Add(this.AmpelLinks);
            this.Controls.Add(this.Car2);
            this.Controls.Add(this.AmpelGerade);
            this.Controls.Add(this.Car1);
            this.Controls.Add(this.AppGeeoffnet);
            this.Controls.Add(this.MinGreenAusgabe);
            this.Controls.Add(this.KreuzungSim);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Kreuzung KreuzungSim;
        private new System.Windows.Forms.Button Left;
        private System.Windows.Forms.Button Out;
        private Ampel AmpelNebenstraße;
        private Ampel AmpelLinks;
        private Ampel AmpelGerade;
        private Ampel AmpelGeradeRechts;
        private System.Windows.Forms.Timer Steuerung;
        private System.Windows.Forms.Timer ButtonFlash;
        private System.Windows.Forms.Label MinGreenAusgabe;
        private System.Windows.Forms.Label AppGeeoffnet;
        private System.Windows.Forms.Panel Car1;
        private System.Windows.Forms.Timer CarMove;
        private System.Windows.Forms.Panel Car2;
        private System.Windows.Forms.Panel Car3;
        private System.Windows.Forms.Panel Car4;
        private System.Windows.Forms.CheckedListBox cLB_Cars;
        private System.Windows.Forms.TextBox textBox1;
    }
}

