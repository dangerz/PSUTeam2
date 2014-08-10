namespace Team2.PSU.Wireless.Mesh.View
{
    partial class ConnectionTimer
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
            this.components = new System.ComponentModel.Container();
            this.gbTimer = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.tmrConnection = new System.Windows.Forms.Timer(this.components);
            this.gbTimer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTimer
            // 
            this.gbTimer.Controls.Add(this.lblTime);
            this.gbTimer.Location = new System.Drawing.Point(4, 4);
            this.gbTimer.Name = "gbTimer";
            this.gbTimer.Size = new System.Drawing.Size(200, 19);
            this.gbTimer.TabIndex = 0;
            this.gbTimer.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(-1, 3);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(204, 13);
            this.lblTime.TabIndex = 0;
            // 
            // tmrConnection
            // 
            this.tmrConnection.Interval = 1000;
            this.tmrConnection.Tick += new System.EventHandler(this.tmrConnection_Tick);
            // 
            // ConnectionTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.Controls.Add(this.gbTimer);
            this.Name = "ConnectionTimer";
            this.Size = new System.Drawing.Size(210, 26);
            this.gbTimer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void ResumeLayout(bool p)
        {
            try
            {
                throw new System.NotImplementedException();
            }
            catch (System.NotImplementedException e)
            {
            }

        }

        private void SuspendLayout()
        {
            try
            {
                throw new System.NotImplementedException();
            }
            catch (System.NotImplementedException e)
            {
            }

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTimer;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer tmrConnection;

        public System.Drawing.SizeF AutoScaleDimensions { get; set; }

        public System.Windows.Forms.AutoScaleMode AutoScaleMode { get; set; }

        public System.Windows.Forms.BorderStyle BorderStyle { get; set; }
    }
}
