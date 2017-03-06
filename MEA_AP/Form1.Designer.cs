namespace MEA_AP
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lb_message = new System.Windows.Forms.Label();
            this.lb_time = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lb_version = new System.Windows.Forms.Label();
            this.proBar_get_image = new System.Windows.Forms.ProgressBar();
            this.customGrpBox1 = new MEA_AP.CustomGrpBox();
            this.btnClose_Device = new System.Windows.Forms.Button();
            this.btnOpen_Device = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxComPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.customGrpBox2 = new MEA_AP.CustomGrpBox();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.pb_png = new System.Windows.Forms.PictureBox();
            this.customGrpBox3 = new MEA_AP.CustomGrpBox();
            this.tb_delete_number = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_enroll_number = new System.Windows.Forms.TextBox();
            this.lb_template_count = new System.Windows.Forms.Label();
            this.btnGetImage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lb_filename = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pb_showFile = new System.Windows.Forms.PictureBox();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.customGrpBox1.SuspendLayout();
            this.customGrpBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_png)).BeginInit();
            this.customGrpBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_showFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_message
            // 
            this.lb_message.BackColor = System.Drawing.Color.White;
            this.lb_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_message.Location = new System.Drawing.Point(8, 97);
            this.lb_message.Name = "lb_message";
            this.lb_message.Size = new System.Drawing.Size(465, 134);
            this.lb_message.TabIndex = 1;
            this.lb_message.Text = "Welcome to use fingerprint tool";
            this.lb_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_time.Location = new System.Drawing.Point(479, 356);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(90, 18);
            this.lb_time.TabIndex = 26;
            this.lb_time.Text = "Time : 0  ms";
            this.lb_time.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 25);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(706, 537);
            this.tabControl1.TabIndex = 27;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.lb_version);
            this.tabPage1.Controls.Add(this.proBar_get_image);
            this.tabPage1.Controls.Add(this.customGrpBox1);
            this.tabPage1.Controls.Add(this.lb_time);
            this.tabPage1.Controls.Add(this.customGrpBox2);
            this.tabPage1.Controls.Add(this.customGrpBox3);
            this.tabPage1.Controls.Add(this.lb_message);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(698, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // lb_version
            // 
            this.lb_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_version.Location = new System.Drawing.Point(483, 461);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(203, 41);
            this.lb_version.TabIndex = 27;
            this.lb_version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // proBar_get_image
            // 
            this.proBar_get_image.Location = new System.Drawing.Point(8, 208);
            this.proBar_get_image.MarqueeAnimationSpeed = 1;
            this.proBar_get_image.Maximum = 28246;
            this.proBar_get_image.Name = "proBar_get_image";
            this.proBar_get_image.Size = new System.Drawing.Size(464, 23);
            this.proBar_get_image.TabIndex = 25;
            this.proBar_get_image.Visible = false;
            // 
            // customGrpBox1
            // 
            this.customGrpBox1.BorderColor = System.Drawing.Color.Black;
            this.customGrpBox1.Controls.Add(this.btnClose_Device);
            this.customGrpBox1.Controls.Add(this.btnOpen_Device);
            this.customGrpBox1.Controls.Add(this.label1);
            this.customGrpBox1.Controls.Add(this.comboBoxBaudRate);
            this.customGrpBox1.Controls.Add(this.comboBoxComPort);
            this.customGrpBox1.Controls.Add(this.label2);
            this.customGrpBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customGrpBox1.Location = new System.Drawing.Point(6, 7);
            this.customGrpBox1.Name = "customGrpBox1";
            this.customGrpBox1.Size = new System.Drawing.Size(680, 76);
            this.customGrpBox1.TabIndex = 11;
            this.customGrpBox1.TabStop = false;
            this.customGrpBox1.Text = "Communication Message";
            // 
            // btnClose_Device
            // 
            this.btnClose_Device.Enabled = false;
            this.btnClose_Device.Font = new System.Drawing.Font("PMingLiU", 13F);
            this.btnClose_Device.Location = new System.Drawing.Point(553, 30);
            this.btnClose_Device.Name = "btnClose_Device";
            this.btnClose_Device.Size = new System.Drawing.Size(110, 35);
            this.btnClose_Device.TabIndex = 4;
            this.btnClose_Device.Text = "Close Device";
            this.btnClose_Device.UseVisualStyleBackColor = true;
            this.btnClose_Device.Click += new System.EventHandler(this.btnClose_Device_Click);
            // 
            // btnOpen_Device
            // 
            this.btnOpen_Device.Font = new System.Drawing.Font("PMingLiU", 13F);
            this.btnOpen_Device.Location = new System.Drawing.Point(428, 30);
            this.btnOpen_Device.Name = "btnOpen_Device";
            this.btnOpen_Device.Size = new System.Drawing.Size(110, 35);
            this.btnOpen_Device.TabIndex = 1;
            this.btnOpen_Device.Text = "Open Device";
            this.btnOpen_Device.UseVisualStyleBackColor = true;
            this.btnOpen_Device.Click += new System.EventHandler(this.btnOpen_Device_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comport";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "115200"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(284, 35);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(85, 26);
            this.comboBoxBaudRate.TabIndex = 3;
            // 
            // comboBoxComPort
            // 
            this.comboBoxComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxComPort.FormattingEnabled = true;
            this.comboBoxComPort.Location = new System.Drawing.Point(89, 35);
            this.comboBoxComPort.Name = "comboBoxComPort";
            this.comboBoxComPort.Size = new System.Drawing.Size(85, 26);
            this.comboBoxComPort.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baudrate";
            // 
            // customGrpBox2
            // 
            this.customGrpBox2.BorderColor = System.Drawing.Color.Black;
            this.customGrpBox2.Controls.Add(this.btnOpenImage);
            this.customGrpBox2.Controls.Add(this.btnSaveImage);
            this.customGrpBox2.Controls.Add(this.pb_png);
            this.customGrpBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customGrpBox2.Location = new System.Drawing.Point(476, 88);
            this.customGrpBox2.Name = "customGrpBox2";
            this.customGrpBox2.Size = new System.Drawing.Size(210, 249);
            this.customGrpBox2.TabIndex = 12;
            this.customGrpBox2.TabStop = false;
            this.customGrpBox2.Text = "Fingerprint Image";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Enabled = false;
            this.btnOpenImage.Location = new System.Drawing.Point(112, 213);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(81, 27);
            this.btnOpenImage.TabIndex = 8;
            this.btnOpenImage.Text = "Open";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Enabled = false;
            this.btnSaveImage.Location = new System.Drawing.Point(16, 213);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(81, 27);
            this.btnSaveImage.TabIndex = 7;
            this.btnSaveImage.Text = "Save";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // pb_png
            // 
            this.pb_png.BackColor = System.Drawing.SystemColors.Control;
            this.pb_png.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_png.Location = new System.Drawing.Point(17, 30);
            this.pb_png.Name = "pb_png";
            this.pb_png.Size = new System.Drawing.Size(176, 176);
            this.pb_png.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_png.TabIndex = 6;
            this.pb_png.TabStop = false;
            // 
            // customGrpBox3
            // 
            this.customGrpBox3.BorderColor = System.Drawing.Color.Black;
            this.customGrpBox3.Controls.Add(this.tb_delete_number);
            this.customGrpBox3.Controls.Add(this.label8);
            this.customGrpBox3.Controls.Add(this.label7);
            this.customGrpBox3.Controls.Add(this.btnCancel);
            this.customGrpBox3.Controls.Add(this.label6);
            this.customGrpBox3.Controls.Add(this.label5);
            this.customGrpBox3.Controls.Add(this.tb_enroll_number);
            this.customGrpBox3.Controls.Add(this.lb_template_count);
            this.customGrpBox3.Controls.Add(this.btnGetImage);
            this.customGrpBox3.Controls.Add(this.label4);
            this.customGrpBox3.Controls.Add(this.btnEnroll);
            this.customGrpBox3.Controls.Add(this.btnDelete);
            this.customGrpBox3.Controls.Add(this.btnVerify);
            this.customGrpBox3.Controls.Add(this.label3);
            this.customGrpBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customGrpBox3.Location = new System.Drawing.Point(7, 237);
            this.customGrpBox3.Name = "customGrpBox3";
            this.customGrpBox3.Size = new System.Drawing.Size(466, 265);
            this.customGrpBox3.TabIndex = 14;
            this.customGrpBox3.TabStop = false;
            this.customGrpBox3.Text = "Main Function";
            // 
            // tb_delete_number
            // 
            this.tb_delete_number.BackColor = System.Drawing.Color.White;
            this.tb_delete_number.Enabled = false;
            this.tb_delete_number.Location = new System.Drawing.Point(249, 100);
            this.tb_delete_number.MaxLength = 2;
            this.tb_delete_number.Name = "tb_delete_number";
            this.tb_delete_number.Size = new System.Drawing.Size(66, 24);
            this.tb_delete_number.TabIndex = 24;
            this.tb_delete_number.Text = "0";
            this.tb_delete_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_delete_number.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tb_delete_number_MouseDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 18);
            this.label7.TabIndex = 22;
            this.label7.Text = "Delete template number";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("PMingLiU", 13F);
            this.btnCancel.Location = new System.Drawing.Point(17, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(226, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = ":";
            // 
            // tb_enroll_number
            // 
            this.tb_enroll_number.BackColor = System.Drawing.Color.White;
            this.tb_enroll_number.Enabled = false;
            this.tb_enroll_number.Location = new System.Drawing.Point(249, 66);
            this.tb_enroll_number.MaxLength = 2;
            this.tb_enroll_number.Name = "tb_enroll_number";
            this.tb_enroll_number.ShortcutsEnabled = false;
            this.tb_enroll_number.Size = new System.Drawing.Size(66, 24);
            this.tb_enroll_number.TabIndex = 16;
            this.tb_enroll_number.Text = "0";
            this.tb_enroll_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_enroll_number.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tb_enroll_number_MouseDown);
            // 
            // lb_template_count
            // 
            this.lb_template_count.AutoSize = true;
            this.lb_template_count.Location = new System.Drawing.Point(273, 35);
            this.lb_template_count.Name = "lb_template_count";
            this.lb_template_count.Size = new System.Drawing.Size(16, 18);
            this.lb_template_count.TabIndex = 18;
            this.lb_template_count.Text = "0";
            // 
            // btnGetImage
            // 
            this.btnGetImage.Enabled = false;
            this.btnGetImage.Font = new System.Drawing.Font("PMingLiU", 13F);
            this.btnGetImage.Location = new System.Drawing.Point(17, 152);
            this.btnGetImage.Name = "btnGetImage";
            this.btnGetImage.Size = new System.Drawing.Size(120, 40);
            this.btnGetImage.TabIndex = 2;
            this.btnGetImage.Text = "Get Image";
            this.btnGetImage.UseVisualStyleBackColor = true;
            this.btnGetImage.Click += new System.EventHandler(this.btnGetImage_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Exist template count";
            // 
            // btnEnroll
            // 
            this.btnEnroll.Enabled = false;
            this.btnEnroll.Font = new System.Drawing.Font("PMingLiU", 13F);
            this.btnEnroll.Location = new System.Drawing.Point(170, 152);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(120, 40);
            this.btnEnroll.TabIndex = 3;
            this.btnEnroll.Text = "Enroll";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("PMingLiU", 13F);
            this.btnDelete.Location = new System.Drawing.Point(170, 209);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Enabled = false;
            this.btnVerify.Font = new System.Drawing.Font("PMingLiU", 13F);
            this.btnVerify.Location = new System.Drawing.Point(326, 152);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(120, 40);
            this.btnVerify.TabIndex = 4;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Enroll template number";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lb_filename);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.pb_showFile);
            this.tabPage2.Controls.Add(this.btnChooseFile);
            this.tabPage2.Controls.Add(this.listView);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(698, 504);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Gallery";
            // 
            // lb_filename
            // 
            this.lb_filename.Location = new System.Drawing.Point(302, 416);
            this.lb_filename.Name = "lb_filename";
            this.lb_filename.Size = new System.Drawing.Size(371, 32);
            this.lb_filename.TabIndex = 4;
            this.lb_filename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(143, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "Choice image to show it";
            // 
            // pb_showFile
            // 
            this.pb_showFile.Location = new System.Drawing.Point(357, 129);
            this.pb_showFile.Name = "pb_showFile";
            this.pb_showFile.Size = new System.Drawing.Size(264, 266);
            this.pb_showFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_showFile.TabIndex = 2;
            this.pb_showFile.TabStop = false;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFile.Location = new System.Drawing.Point(20, 17);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(106, 40);
            this.btnChooseFile.TabIndex = 1;
            this.btnChooseFile.Text = "Choose";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.Color.White;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(6, 78);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(250, 425);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            this.columnHeader1.Width = 250;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(552, 63);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(0, 0);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(370, 63);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(0, 0);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(162, 63);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(0, 0);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 557);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Module test tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.customGrpBox1.ResumeLayout(false);
            this.customGrpBox1.PerformLayout();
            this.customGrpBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_png)).EndInit();
            this.customGrpBox3.ResumeLayout(false);
            this.customGrpBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_showFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpen_Device;
        private System.Windows.Forms.Button btnClose_Device;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.ComboBox comboBoxComPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_message;
        private System.Windows.Forms.Button btnGetImage;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox pb_png;
        private CustomGrpBox customGrpBox1;
        private CustomGrpBox customGrpBox2;
        private CustomGrpBox customGrpBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_enroll_number;
        private System.Windows.Forms.Label lb_template_count;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tb_delete_number;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.PictureBox pb_showFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_filename;
        private System.Windows.Forms.ProgressBar proBar_get_image;
        private System.Windows.Forms.Label lb_version;
    }
}

