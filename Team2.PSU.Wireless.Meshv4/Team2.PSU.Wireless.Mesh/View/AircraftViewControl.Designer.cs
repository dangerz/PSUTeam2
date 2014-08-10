namespace Team2.PSU.Wireless.Mesh.View
{
    partial class AircraftViewControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowsermapView = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowsermapView
            // 
            this.webBrowsermapView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowsermapView.Location = new System.Drawing.Point(0, 0);
            this.webBrowsermapView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webBrowsermapView.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowsermapView.Name = "webBrowsermapView";
            this.webBrowsermapView.ScrollBarsEnabled = false;
            this.webBrowsermapView.Size = new System.Drawing.Size(917, 779);
            this.webBrowsermapView.TabIndex = 0;
            this.webBrowsermapView.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // AircraftViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webBrowsermapView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AircraftViewControl";
            this.Size = new System.Drawing.Size(917, 779);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowsermapView;
    }
}
