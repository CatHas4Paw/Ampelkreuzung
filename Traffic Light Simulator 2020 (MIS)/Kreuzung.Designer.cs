namespace Traffic_Light_Simulator_2020__MIS_
{
    partial class Kreuzung
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.KreuzungSkizze = new System.Windows.Forms.Panel();
            this.pLines = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // KreuzungSkizze
            // 
            this.KreuzungSkizze.BackColor = System.Drawing.Color.Transparent;
            this.KreuzungSkizze.Location = new System.Drawing.Point(0, 0);
            this.KreuzungSkizze.Margin = new System.Windows.Forms.Padding(0);
            this.KreuzungSkizze.Name = "KreuzungSkizze";
            this.KreuzungSkizze.Size = new System.Drawing.Size(1920, 700);
            this.KreuzungSkizze.TabIndex = 0;
            this.KreuzungSkizze.Paint += new System.Windows.Forms.PaintEventHandler(this.KreuzungSkizze_Paint);
            // 
            // pLines
            // 
            this.pLines.Location = new System.Drawing.Point(0, 0);
            this.pLines.Name = "pLines";
            this.pLines.Size = new System.Drawing.Size(200, 100);
            this.pLines.TabIndex = 0;
            // 
            // Kreuzung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.KreuzungSkizze);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Kreuzung";
            this.Size = new System.Drawing.Size(1017, 618);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel KreuzungSkizze;
        private System.Windows.Forms.Panel pLines;
    }
}
