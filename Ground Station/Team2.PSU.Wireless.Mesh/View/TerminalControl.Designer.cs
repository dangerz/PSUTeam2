namespace Team2.PSU.Wireless.Mesh.View
{
    partial class TerminalControl
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
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.gbPortSettings = new System.Windows.Forms.GroupBox();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.lblComPort = new System.Windows.Forms.Label();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbLineSignals = new System.Windows.Forms.GroupBox();
            this.chkRTS = new System.Windows.Forms.CheckBox();
            this.chkCD = new System.Windows.Forms.CheckBox();
            this.chkDSR = new System.Windows.Forms.CheckBox();
            this.chkCTS = new System.Windows.Forms.CheckBox();
            this.chkDTR = new System.Windows.Forms.CheckBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkClearWithDTR = new System.Windows.Forms.CheckBox();
            this.tmrCheckComPorts = new System.Windows.Forms.Timer(this.components);
            this.grpClearBox = new System.Windows.Forms.GroupBox();
            this.chkClearOnOpen = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.rdImage = new System.Windows.Forms.RadioButton();
            this.rdTextFile = new System.Windows.Forms.RadioButton();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblSend = new System.Windows.Forms.Label();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.rtfTerminal = new System.Windows.Forms.RichTextBox();
            this.lnkLblAuditHistory = new System.Windows.Forms.LinkLabel();
            this.btnAtachFile = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.includeTimeCB = new System.Windows.Forms.CheckBox();
            this.gpsDataOnlyCB = new System.Windows.Forms.CheckBox();
            this.requestPictureBtn = new System.Windows.Forms.Button();
            this.gbPortSettings.SuspendLayout();
            this.gbLineSignals.SuspendLayout();
            this.grpClearBox.SuspendLayout();
            this.gbMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbStopBits.Location = new System.Drawing.Point(99, 194);
            this.cmbStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(119, 25);
            this.cmbStopBits.TabIndex = 9;
            // 
            // gbPortSettings
            // 
            this.gbPortSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPortSettings.Controls.Add(this.cmbPortName);
            this.gbPortSettings.Controls.Add(this.cmbBaudRate);
            this.gbPortSettings.Controls.Add(this.cmbStopBits);
            this.gbPortSettings.Controls.Add(this.cmbParity);
            this.gbPortSettings.Controls.Add(this.cmbDataBits);
            this.gbPortSettings.Controls.Add(this.lblComPort);
            this.gbPortSettings.Controls.Add(this.lblStopBits);
            this.gbPortSettings.Controls.Add(this.lblBaudRate);
            this.gbPortSettings.Controls.Add(this.lblDataBits);
            this.gbPortSettings.Controls.Add(this.label1);
            this.gbPortSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPortSettings.Location = new System.Drawing.Point(4, 4);
            this.gbPortSettings.Margin = new System.Windows.Forms.Padding(4);
            this.gbPortSettings.Name = "gbPortSettings";
            this.gbPortSettings.Padding = new System.Windows.Forms.Padding(4);
            this.gbPortSettings.Size = new System.Drawing.Size(313, 226);
            this.gbPortSettings.TabIndex = 17;
            this.gbPortSettings.TabStop = false;
            this.gbPortSettings.Text = "COM Serial Port Settings";
            // 
            // cmbPortName
            // 
            this.cmbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.cmbPortName.Location = new System.Drawing.Point(99, 27);
            this.cmbPortName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(119, 25);
            this.cmbPortName.TabIndex = 1;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownWidth = 90;
            this.cmbBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(97, 69);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(119, 25);
            this.cmbBaudRate.TabIndex = 3;
            this.cmbBaudRate.Validating += new System.ComponentModel.CancelEventHandler(this.cmbBaudRate_Validating);
            // 
            // cmbParity
            // 
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(99, 111);
            this.cmbParity.Margin = new System.Windows.Forms.Padding(4);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(119, 25);
            this.cmbParity.TabIndex = 5;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cmbDataBits.Location = new System.Drawing.Point(99, 153);
            this.cmbDataBits.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(119, 25);
            this.cmbDataBits.TabIndex = 7;
            this.cmbDataBits.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDataBits_Validating);
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComPort.Location = new System.Drawing.Point(16, 27);
            this.lblComPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(73, 17);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "COM Port:";
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStopBits.Location = new System.Drawing.Point(16, 194);
            this.lblStopBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(68, 17);
            this.lblStopBits.TabIndex = 8;
            this.lblStopBits.Text = "Stop Bits:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaudRate.Location = new System.Drawing.Point(16, 69);
            this.lblBaudRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(79, 17);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "Baud Rate:";
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataBits.Location = new System.Drawing.Point(16, 153);
            this.lblDataBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(69, 17);
            this.lblDataBits.TabIndex = 6;
            this.lblDataBits.Text = "Data Bits:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Parity:";
            // 
            // gbLineSignals
            // 
            this.gbLineSignals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbLineSignals.Controls.Add(this.chkRTS);
            this.gbLineSignals.Controls.Add(this.chkCD);
            this.gbLineSignals.Controls.Add(this.chkDSR);
            this.gbLineSignals.Controls.Add(this.chkCTS);
            this.gbLineSignals.Controls.Add(this.chkDTR);
            this.gbLineSignals.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLineSignals.Location = new System.Drawing.Point(325, 4);
            this.gbLineSignals.Margin = new System.Windows.Forms.Padding(4);
            this.gbLineSignals.Name = "gbLineSignals";
            this.gbLineSignals.Padding = new System.Windows.Forms.Padding(4);
            this.gbLineSignals.Size = new System.Drawing.Size(123, 226);
            this.gbLineSignals.TabIndex = 20;
            this.gbLineSignals.TabStop = false;
            this.gbLineSignals.Text = "&Line Signals";
            // 
            // chkRTS
            // 
            this.chkRTS.AutoSize = true;
            this.chkRTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRTS.Location = new System.Drawing.Point(13, 69);
            this.chkRTS.Margin = new System.Windows.Forms.Padding(4);
            this.chkRTS.Name = "chkRTS";
            this.chkRTS.Size = new System.Drawing.Size(58, 21);
            this.chkRTS.TabIndex = 1;
            this.chkRTS.Text = "RTS";
            this.toolTip.SetToolTip(this.chkRTS, "Pin 7 on DB9, Output, Request to Send");
            this.chkRTS.UseVisualStyleBackColor = true;
            this.chkRTS.CheckedChanged += new System.EventHandler(this.chkRTS_CheckedChanged);
            // 
            // chkCD
            // 
            this.chkCD.AutoSize = true;
            this.chkCD.Enabled = false;
            this.chkCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCD.Location = new System.Drawing.Point(12, 191);
            this.chkCD.Margin = new System.Windows.Forms.Padding(4);
            this.chkCD.Name = "chkCD";
            this.chkCD.Size = new System.Drawing.Size(49, 21);
            this.chkCD.TabIndex = 4;
            this.chkCD.Text = "CD";
            this.toolTip.SetToolTip(this.chkCD, "Pin 1 on DB9, Input, Data Carrier Detect");
            this.chkCD.UseVisualStyleBackColor = true;
            // 
            // chkDSR
            // 
            this.chkDSR.AutoSize = true;
            this.chkDSR.Enabled = false;
            this.chkDSR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDSR.Location = new System.Drawing.Point(12, 150);
            this.chkDSR.Margin = new System.Windows.Forms.Padding(4);
            this.chkDSR.Name = "chkDSR";
            this.chkDSR.Size = new System.Drawing.Size(59, 21);
            this.chkDSR.TabIndex = 3;
            this.chkDSR.Text = "DSR";
            this.toolTip.SetToolTip(this.chkDSR, "Pin 6 on DB9, Input, Data Set Ready");
            this.chkDSR.UseVisualStyleBackColor = true;
            // 
            // chkCTS
            // 
            this.chkCTS.AutoSize = true;
            this.chkCTS.Enabled = false;
            this.chkCTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCTS.Location = new System.Drawing.Point(13, 110);
            this.chkCTS.Margin = new System.Windows.Forms.Padding(4);
            this.chkCTS.Name = "chkCTS";
            this.chkCTS.Size = new System.Drawing.Size(57, 21);
            this.chkCTS.TabIndex = 2;
            this.chkCTS.Text = "CTS";
            this.toolTip.SetToolTip(this.chkCTS, "Pin 8 on DB9, Input, Clear to Send");
            this.chkCTS.UseVisualStyleBackColor = true;
            // 
            // chkDTR
            // 
            this.chkDTR.AutoSize = true;
            this.chkDTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDTR.Location = new System.Drawing.Point(13, 28);
            this.chkDTR.Margin = new System.Windows.Forms.Padding(4);
            this.chkDTR.Name = "chkDTR";
            this.chkDTR.Size = new System.Drawing.Size(59, 21);
            this.chkDTR.TabIndex = 0;
            this.chkDTR.Text = "DTR";
            this.toolTip.SetToolTip(this.chkDTR, "Pin 4 on DB9, Output, Data Terminal Ready");
            this.chkDTR.UseVisualStyleBackColor = true;
            this.chkDTR.CheckedChanged += new System.EventHandler(this.chkDTR_CheckedChanged);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenPort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnOpenPort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOpenPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenPort.Location = new System.Drawing.Point(629, 108);
            this.btnOpenPort.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(100, 28);
            this.btnOpenPort.TabIndex = 19;
            this.btnOpenPort.Text = "&Open Port";
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(715, 202);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 28);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "&Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkClearWithDTR
            // 
            this.chkClearWithDTR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkClearWithDTR.AutoSize = true;
            this.chkClearWithDTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClearWithDTR.Location = new System.Drawing.Point(4, 48);
            this.chkClearWithDTR.Margin = new System.Windows.Forms.Padding(4);
            this.chkClearWithDTR.Name = "chkClearWithDTR";
            this.chkClearWithDTR.Size = new System.Drawing.Size(124, 21);
            this.chkClearWithDTR.TabIndex = 11;
            this.chkClearWithDTR.Text = "Clear with DTR";
            this.chkClearWithDTR.UseVisualStyleBackColor = true;
            // 
            // tmrCheckComPorts
            // 
            this.tmrCheckComPorts.Enabled = true;
            this.tmrCheckComPorts.Interval = 500;
            this.tmrCheckComPorts.Tick += new System.EventHandler(this.tmrCheckComPorts_Tick);
            // 
            // grpClearBox
            // 
            this.grpClearBox.Controls.Add(this.chkClearOnOpen);
            this.grpClearBox.Controls.Add(this.chkClearWithDTR);
            this.grpClearBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpClearBox.Location = new System.Drawing.Point(603, 14);
            this.grpClearBox.Margin = new System.Windows.Forms.Padding(4);
            this.grpClearBox.Name = "grpClearBox";
            this.grpClearBox.Padding = new System.Windows.Forms.Padding(4);
            this.grpClearBox.Size = new System.Drawing.Size(139, 76);
            this.grpClearBox.TabIndex = 23;
            this.grpClearBox.TabStop = false;
            this.grpClearBox.Text = "Clear";
            // 
            // chkClearOnOpen
            // 
            this.chkClearOnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkClearOnOpen.AutoSize = true;
            this.chkClearOnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClearOnOpen.Location = new System.Drawing.Point(4, 20);
            this.chkClearOnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.chkClearOnOpen.Name = "chkClearOnOpen";
            this.chkClearOnOpen.Size = new System.Drawing.Size(122, 21);
            this.chkClearOnOpen.TabIndex = 10;
            this.chkClearOnOpen.Text = "Clear on Open";
            this.chkClearOnOpen.UseVisualStyleBackColor = true;
            // 
            // gbMode
            // 
            this.gbMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbMode.Controls.Add(this.rdImage);
            this.gbMode.Controls.Add(this.rdTextFile);
            this.gbMode.Controls.Add(this.rbText);
            this.gbMode.Controls.Add(this.rbHex);
            this.gbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMode.Location = new System.Drawing.Point(456, 4);
            this.gbMode.Margin = new System.Windows.Forms.Padding(4);
            this.gbMode.Name = "gbMode";
            this.gbMode.Padding = new System.Windows.Forms.Padding(4);
            this.gbMode.Size = new System.Drawing.Size(139, 143);
            this.gbMode.TabIndex = 18;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "Data &Mode";
            // 
            // rdImage
            // 
            this.rdImage.AutoSize = true;
            this.rdImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdImage.Location = new System.Drawing.Point(16, 108);
            this.rdImage.Margin = new System.Windows.Forms.Padding(4);
            this.rdImage.Name = "rdImage";
            this.rdImage.Size = new System.Drawing.Size(67, 21);
            this.rdImage.TabIndex = 3;
            this.rdImage.TabStop = true;
            this.rdImage.Text = "Image";
            this.rdImage.UseVisualStyleBackColor = true;
            // 
            // rdTextFile
            // 
            this.rdTextFile.AutoSize = true;
            this.rdTextFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTextFile.Location = new System.Drawing.Point(16, 81);
            this.rdTextFile.Margin = new System.Windows.Forms.Padding(4);
            this.rdTextFile.Name = "rdTextFile";
            this.rdTextFile.Size = new System.Drawing.Size(82, 21);
            this.rdTextFile.TabIndex = 2;
            this.rdTextFile.TabStop = true;
            this.rdTextFile.Text = "Text File";
            this.rdTextFile.UseVisualStyleBackColor = true;
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Checked = true;
            this.rbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbText.Location = new System.Drawing.Point(16, 27);
            this.rbText.Margin = new System.Windows.Forms.Padding(4);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(56, 21);
            this.rbText.TabIndex = 0;
            this.rbText.TabStop = true;
            this.rbText.Text = "Text";
            this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHex.Location = new System.Drawing.Point(16, 52);
            this.rbHex.Margin = new System.Windows.Forms.Padding(4);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(53, 21);
            this.rbHex.TabIndex = 1;
            this.rbHex.Text = "Hex";
            this.rbHex.CheckedChanged += new System.EventHandler(this.rbHex_CheckedChanged);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(607, 505);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 28);
            this.btnSend.TabIndex = 16;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblSend
            // 
            this.lblSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSend.AutoSize = true;
            this.lblSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSend.Location = new System.Drawing.Point(4, 478);
            this.lblSend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(89, 17);
            this.lblSend.TabIndex = 14;
            this.lblSend.Text = "Send &Data:";
            // 
            // txtSendData
            // 
            this.txtSendData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendData.Location = new System.Drawing.Point(96, 475);
            this.txtSendData.Margin = new System.Windows.Forms.Padding(4);
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(719, 22);
            this.txtSendData.TabIndex = 15;
            this.txtSendData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendData_KeyDown);
            this.txtSendData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSendData_KeyPress);
            // 
            // rtfTerminal
            // 
            this.rtfTerminal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtfTerminal.Location = new System.Drawing.Point(4, 238);
            this.rtfTerminal.Margin = new System.Windows.Forms.Padding(4);
            this.rtfTerminal.Name = "rtfTerminal";
            this.rtfTerminal.Size = new System.Drawing.Size(811, 235);
            this.rtfTerminal.TabIndex = 13;
            this.rtfTerminal.Text = "";
            // 
            // lnkLblAuditHistory
            // 
            this.lnkLblAuditHistory.AutoSize = true;
            this.lnkLblAuditHistory.Location = new System.Drawing.Point(1, 511);
            this.lnkLblAuditHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkLblAuditHistory.Name = "lnkLblAuditHistory";
            this.lnkLblAuditHistory.Size = new System.Drawing.Size(121, 17);
            this.lnkLblAuditHistory.TabIndex = 24;
            this.lnkLblAuditHistory.TabStop = true;
            this.lnkLblAuditHistory.Text = "View Audit History";
            this.lnkLblAuditHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblAuditHistory_LinkClicked);
            // 
            // btnAtachFile
            // 
            this.btnAtachFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtachFile.Location = new System.Drawing.Point(715, 505);
            this.btnAtachFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtachFile.Name = "btnAtachFile";
            this.btnAtachFile.Size = new System.Drawing.Size(100, 28);
            this.btnAtachFile.TabIndex = 25;
            this.btnAtachFile.Text = "Send File";
            this.btnAtachFile.UseVisualStyleBackColor = true;
            this.btnAtachFile.Click += new System.EventHandler(this.btnAtachFile_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(833, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 518);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(444, 505);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 28);
            this.button1.TabIndex = 27;
            this.button1.Text = "Save Log To File";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // includeTimeCB
            // 
            this.includeTimeCB.AutoSize = true;
            this.includeTimeCB.Checked = true;
            this.includeTimeCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeTimeCB.Location = new System.Drawing.Point(444, 540);
            this.includeTimeCB.Name = "includeTimeCB";
            this.includeTimeCB.Size = new System.Drawing.Size(110, 21);
            this.includeTimeCB.TabIndex = 28;
            this.includeTimeCB.Text = "Include Time";
            this.includeTimeCB.UseVisualStyleBackColor = true;
            // 
            // gpsDataOnlyCB
            // 
            this.gpsDataOnlyCB.AutoSize = true;
            this.gpsDataOnlyCB.Location = new System.Drawing.Point(444, 567);
            this.gpsDataOnlyCB.Name = "gpsDataOnlyCB";
            this.gpsDataOnlyCB.Size = new System.Drawing.Size(126, 21);
            this.gpsDataOnlyCB.TabIndex = 29;
            this.gpsDataOnlyCB.Text = "GPS Data Only";
            this.gpsDataOnlyCB.UseVisualStyleBackColor = true;
            // 
            // requestPictureBtn
            // 
            this.requestPictureBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.requestPictureBtn.Enabled = false;
            this.requestPictureBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestPictureBtn.Location = new System.Drawing.Point(607, 540);
            this.requestPictureBtn.Margin = new System.Windows.Forms.Padding(4);
            this.requestPictureBtn.Name = "requestPictureBtn";
            this.requestPictureBtn.Size = new System.Drawing.Size(208, 28);
            this.requestPictureBtn.TabIndex = 30;
            this.requestPictureBtn.Text = "Request Picture";
            this.requestPictureBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // TerminalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.requestPictureBtn);
            this.Controls.Add(this.gpsDataOnlyCB);
            this.Controls.Add(this.includeTimeCB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAtachFile);
            this.Controls.Add(this.lnkLblAuditHistory);
            this.Controls.Add(this.gbPortSettings);
            this.Controls.Add(this.gbLineSignals);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grpClearBox);
            this.Controls.Add(this.gbMode);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.rtfTerminal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TerminalControl";
            this.Size = new System.Drawing.Size(1093, 798);
            this.gbPortSettings.ResumeLayout(false);
            this.gbPortSettings.PerformLayout();
            this.gbLineSignals.ResumeLayout(false);
            this.gbLineSignals.PerformLayout();
            this.grpClearBox.ResumeLayout(false);
            this.grpClearBox.PerformLayout();
            this.gbMode.ResumeLayout(false);
            this.gbMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.GroupBox gbPortSettings;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbLineSignals;
        private System.Windows.Forms.CheckBox chkRTS;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox chkCD;
        private System.Windows.Forms.CheckBox chkDSR;
        private System.Windows.Forms.CheckBox chkCTS;
        private System.Windows.Forms.CheckBox chkDTR;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkClearWithDTR;
        private System.Windows.Forms.Timer tmrCheckComPorts;
        private System.Windows.Forms.GroupBox grpClearBox;
        private System.Windows.Forms.CheckBox chkClearOnOpen;
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.RadioButton rbHex;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.RichTextBox rtfTerminal;
        private System.Windows.Forms.LinkLabel lnkLblAuditHistory;
        private System.Windows.Forms.Button btnAtachFile;
        private System.Windows.Forms.RadioButton rdTextFile;
        private System.Windows.Forms.RadioButton rdImage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox includeTimeCB;
        private System.Windows.Forms.CheckBox gpsDataOnlyCB;
        private System.Windows.Forms.Button requestPictureBtn;

    }
}
