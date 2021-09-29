namespace Sarasi_HMS
{
    partial class AttendenceEmp
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendenceEmp));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgempid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgfirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dglastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgintime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgouttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottomStock = new System.Windows.Forms.Panel();
            this.lbldate = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.labelBottom = new System.Windows.Forms.Label();
            this.employeeGridView = new System.Windows.Forms.DataGridView();
            this.dgattendenceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnreport = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnddelete = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtouttime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txttime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.attemploayye = new System.Windows.Forms.Label();
            this.combocategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtlname = new System.Windows.Forms.TextBox();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.buniPanelTopStock = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.panelBottomStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeGridView)).BeginInit();
            this.buniPanelTopStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // dgempid
            // 
            this.dgempid.DataPropertyName = "EmpID";
            this.dgempid.HeaderText = "EmpId";
            this.dgempid.MinimumWidth = 6;
            this.dgempid.Name = "dgempid";
            this.dgempid.ReadOnly = true;
            this.dgempid.Visible = false;
            // 
            // dgfirstname
            // 
            this.dgfirstname.DataPropertyName = "FirstName";
            this.dgfirstname.HeaderText = "First Name";
            this.dgfirstname.MinimumWidth = 6;
            this.dgfirstname.Name = "dgfirstname";
            this.dgfirstname.ReadOnly = true;
            // 
            // dglastname
            // 
            this.dglastname.DataPropertyName = "LastName";
            this.dglastname.HeaderText = "Last Name";
            this.dglastname.MinimumWidth = 6;
            this.dglastname.Name = "dglastname";
            this.dglastname.ReadOnly = true;
            // 
            // dgdate
            // 
            this.dgdate.DataPropertyName = "Date";
            this.dgdate.HeaderText = "Date";
            this.dgdate.MinimumWidth = 6;
            this.dgdate.Name = "dgdate";
            this.dgdate.ReadOnly = true;
            // 
            // dgintime
            // 
            this.dgintime.DataPropertyName = "InTime";
            this.dgintime.HeaderText = "InTime";
            this.dgintime.MinimumWidth = 6;
            this.dgintime.Name = "dgintime";
            this.dgintime.ReadOnly = true;
            // 
            // dgouttime
            // 
            this.dgouttime.DataPropertyName = "OutTime";
            this.dgouttime.HeaderText = "OutTime";
            this.dgouttime.MinimumWidth = 6;
            this.dgouttime.Name = "dgouttime";
            this.dgouttime.ReadOnly = true;
            // 
            // dgstatus
            // 
            this.dgstatus.DataPropertyName = "Status";
            this.dgstatus.HeaderText = "Status";
            this.dgstatus.MinimumWidth = 6;
            this.dgstatus.Name = "dgstatus";
            this.dgstatus.ReadOnly = true;
            // 
            // panelBottomStock
            // 
            this.panelBottomStock.BackColor = System.Drawing.Color.Black;
            this.panelBottomStock.Controls.Add(this.lbldate);
            this.panelBottomStock.Controls.Add(this.lbltime);
            this.panelBottomStock.Controls.Add(this.pictureBox4);
            this.panelBottomStock.Controls.Add(this.lblDateTime);
            this.panelBottomStock.Controls.Add(this.pictureBox3);
            this.panelBottomStock.Controls.Add(this.labelBottom);
            this.panelBottomStock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomStock.Location = new System.Drawing.Point(0, 688);
            this.panelBottomStock.Name = "panelBottomStock";
            this.panelBottomStock.Size = new System.Drawing.Size(1110, 48);
            this.panelBottomStock.TabIndex = 84;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.BackColor = System.Drawing.Color.Transparent;
            this.lbldate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbldate.Location = new System.Drawing.Point(876, 23);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(80, 17);
            this.lbldate.TabIndex = 60;
            this.lbldate.Text = "2020/04/25";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.BackColor = System.Drawing.Color.Transparent;
            this.lbltime.ForeColor = System.Drawing.Color.White;
            this.lbltime.Location = new System.Drawing.Point(893, 6);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(72, 17);
            this.lbltime.TabIndex = 60;
            this.lbltime.Text = "12:00 P.M";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(693, 10);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 35);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(785, 16);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(61, 23);
            this.lblDateTime.TabIndex = 6;
            this.lblDateTime.Text = "Time";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(623, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // labelBottom
            // 
            this.labelBottom.AutoSize = true;
            this.labelBottom.BackColor = System.Drawing.Color.Transparent;
            this.labelBottom.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBottom.ForeColor = System.Drawing.Color.White;
            this.labelBottom.Location = new System.Drawing.Point(187, 16);
            this.labelBottom.Name = "labelBottom";
            this.labelBottom.Size = new System.Drawing.Size(387, 23);
            this.labelBottom.TabIndex = 0;
            this.labelBottom.Text = "2020@CodeSpace All rights reserved ";
            // 
            // employeeGridView
            // 
            this.employeeGridView.AllowUserToAddRows = false;
            this.employeeGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.employeeGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.employeeGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.employeeGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employeeGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.employeeGridView.ColumnHeadersHeight = 40;
            this.employeeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgattendenceID,
            this.dgempid,
            this.dgfirstname,
            this.dglastname,
            this.dgdate,
            this.dgintime,
            this.dgouttime,
            this.dgstatus});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.employeeGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.employeeGridView.Location = new System.Drawing.Point(55, 389);
            this.employeeGridView.Name = "employeeGridView";
            this.employeeGridView.ReadOnly = true;
            this.employeeGridView.RowHeadersWidth = 51;
            this.employeeGridView.RowTemplate.Height = 24;
            this.employeeGridView.Size = new System.Drawing.Size(1042, 238);
            this.employeeGridView.TabIndex = 83;
            this.employeeGridView.DoubleClick += new System.EventHandler(this.employeeGridView_DoubleClick);
            // 
            // dgattendenceID
            // 
            this.dgattendenceID.DataPropertyName = "AttendenceID";
            this.dgattendenceID.HeaderText = "AttendenceID";
            this.dgattendenceID.MinimumWidth = 6;
            this.dgattendenceID.Name = "dgattendenceID";
            this.dgattendenceID.ReadOnly = true;
            this.dgattendenceID.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(801, 208);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(244, 30);
            this.dateTimePicker1.TabIndex = 82;
            // 
            // btnreport
            // 
            this.btnreport.BackColor = System.Drawing.Color.Black;
            this.btnreport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnreport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnreport.Location = new System.Drawing.Point(464, 633);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(182, 55);
            this.btnreport.TabIndex = 81;
            this.btnreport.Text = "Attendence Report";
            this.btnreport.UseVisualStyleBackColor = false;
            this.btnreport.Click += new System.EventHandler(this.btnreport_Click);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Black;
            this.btnback.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnback.ForeColor = System.Drawing.Color.White;
            this.btnback.Location = new System.Drawing.Point(57, 633);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(173, 55);
            this.btnback.TabIndex = 80;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(652, 633);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 55);
            this.btnSave.TabIndex = 79;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btncancel.ForeColor = System.Drawing.Color.Transparent;
            this.btncancel.Location = new System.Drawing.Point(944, 633);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(140, 53);
            this.btncancel.TabIndex = 78;
            this.btncancel.Text = "Reset";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnddelete
            // 
            this.btnddelete.BackColor = System.Drawing.Color.Black;
            this.btnddelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnddelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnddelete.Location = new System.Drawing.Point(798, 633);
            this.btnddelete.Name = "btnddelete";
            this.btnddelete.Size = new System.Drawing.Size(137, 53);
            this.btnddelete.TabIndex = 77;
            this.btnddelete.Text = "Delete";
            this.btnddelete.UseVisualStyleBackColor = false;
            this.btnddelete.Click += new System.EventHandler(this.btnddelete_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.BackColor = System.Drawing.Color.Transparent;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(139, 336);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(57, 20);
            this.Status.TabIndex = 76;
            this.Status.Text = "Ststus";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbstatus
            // 
            this.cmbstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Items.AddRange(new object[] {
            "Present",
            "Absent"});
            this.cmbstatus.Location = new System.Drawing.Point(290, 326);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(244, 37);
            this.cmbstatus.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(139, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 67;
            this.label6.Text = "Last Name";
            // 
            // txtouttime
            // 
            this.txtouttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtouttime.Location = new System.Drawing.Point(801, 328);
            this.txtouttime.Multiline = true;
            this.txtouttime.Name = "txtouttime";
            this.txtouttime.Size = new System.Drawing.Size(244, 37);
            this.txtouttime.TabIndex = 70;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(684, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 66;
            this.label7.Text = "OUT Time";
            // 
            // txttime
            // 
            this.txttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttime.Location = new System.Drawing.Point(801, 265);
            this.txttime.Multiline = true;
            this.txttime.Name = "txttime";
            this.txttime.Size = new System.Drawing.Size(244, 37);
            this.txttime.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(684, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "IN Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(684, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Date";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(540, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 50);
            this.button1.TabIndex = 63;
            this.button1.Text = "Get emploees";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // attemploayye
            // 
            this.attemploayye.AutoSize = true;
            this.attemploayye.BackColor = System.Drawing.Color.Transparent;
            this.attemploayye.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attemploayye.Location = new System.Drawing.Point(127, 126);
            this.attemploayye.Name = "attemploayye";
            this.attemploayye.Size = new System.Drawing.Size(82, 20);
            this.attemploayye.TabIndex = 62;
            this.attemploayye.Text = "Employee";
            // 
            // combocategory
            // 
            this.combocategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combocategory.FormattingEnabled = true;
            this.combocategory.Location = new System.Drawing.Point(290, 116);
            this.combocategory.Name = "combocategory";
            this.combocategory.Size = new System.Drawing.Size(244, 37);
            this.combocategory.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(355, 38);
            this.label4.TabIndex = 73;
            this.label4.Text = "Employee Attendence";
            // 
            // txtfname
            // 
            this.txtfname.Enabled = false;
            this.txtfname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfname.Location = new System.Drawing.Point(290, 208);
            this.txtfname.Multiline = true;
            this.txtfname.Name = "txtfname";
            this.txtfname.Size = new System.Drawing.Size(244, 37);
            this.txtfname.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(139, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 68;
            this.label5.Text = "First Name";
            // 
            // txtlname
            // 
            this.txtlname.Enabled = false;
            this.txtlname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlname.Location = new System.Drawing.Point(290, 269);
            this.txtlname.Multiline = true;
            this.txtlname.Name = "txtlname";
            this.txtlname.Size = new System.Drawing.Size(244, 37);
            this.txtlname.TabIndex = 71;
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this.buniPanelTopStock;
            // 
            // buniPanelTopStock
            // 
            this.buniPanelTopStock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buniPanelTopStock.BackgroundImage")));
            this.buniPanelTopStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buniPanelTopStock.Controls.Add(this.btnClose);
            this.buniPanelTopStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.buniPanelTopStock.GradientBottomLeft = System.Drawing.Color.SaddleBrown;
            this.buniPanelTopStock.GradientBottomRight = System.Drawing.Color.White;
            this.buniPanelTopStock.GradientTopLeft = System.Drawing.Color.Gold;
            this.buniPanelTopStock.GradientTopRight = System.Drawing.Color.White;
            this.buniPanelTopStock.Location = new System.Drawing.Point(0, 0);
            this.buniPanelTopStock.Name = "buniPanelTopStock";
            this.buniPanelTopStock.Quality = 10;
            this.buniPanelTopStock.Size = new System.Drawing.Size(1110, 37);
            this.buniPanelTopStock.TabIndex = 61;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(1059, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(51, 37);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            // 
            // AttendenceEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::Sarasi_HMS.Properties.Resources.green;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1131, 676);
            this.Controls.Add(this.panelBottomStock);
            this.Controls.Add(this.employeeGridView);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnreport);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnddelete);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.cmbstatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtouttime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txttime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.attemploayye);
            this.Controls.Add(this.combocategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtfname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtlname);
            this.Controls.Add(this.buniPanelTopStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AttendenceEmp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttendenceEmp";
            this.Load += new System.EventHandler(this.AttendenceEmp_Load);
            this.panelBottomStock.ResumeLayout(false);
            this.panelBottomStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeGridView)).EndInit();
            this.buniPanelTopStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dgempid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgfirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dglastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgintime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgouttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgstatus;
        private System.Windows.Forms.Panel panelBottomStock;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelBottom;
        private System.Windows.Forms.DataGridView employeeGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgattendenceID;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnreport;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnddelete;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtouttime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txttime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label attemploayye;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private System.Windows.Forms.ComboBox combocategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtfname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtlname;
        private Bunifu.Framework.UI.BunifuGradientPanel buniPanelTopStock;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
    }
}