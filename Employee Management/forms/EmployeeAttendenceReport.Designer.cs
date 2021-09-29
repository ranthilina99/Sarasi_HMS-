namespace Sarasi_HMS
{
    partial class EmployeeAttendenceReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeAttendenceReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btngetallvalues = new System.Windows.Forms.Button();
            this.llblemp = new System.Windows.Forms.Label();
            this.cmbatt = new System.Windows.Forms.ComboBox();
            this.dataform = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.buniPanelTopStock = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.panelBottomStock = new System.Windows.Forms.Panel();
            this.lbldate = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.labelBottom = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gunaDragControl2 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.lblsearch = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.empattdatagrid = new Guna.UI.WinForms.GunaDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgfirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dglastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgintime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgouttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brnfind = new System.Windows.Forms.Button();
            this.datato = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnback = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnddelete = new System.Windows.Forms.Button();
            this.employeeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.buniPanelTopStock.SuspendLayout();
            this.panelBottomStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empattdatagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtsearch
            // 
            this.txtsearch.BackColor = System.Drawing.Color.Gray;
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.ForeColor = System.Drawing.Color.White;
            this.txtsearch.Location = new System.Drawing.Point(599, 165);
            this.txtsearch.Multiline = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(415, 40);
            this.txtsearch.TabIndex = 83;
            // 
            // btngetallvalues
            // 
            this.btngetallvalues.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btngetallvalues.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngetallvalues.ForeColor = System.Drawing.Color.White;
            this.btngetallvalues.Location = new System.Drawing.Point(326, 107);
            this.btngetallvalues.Name = "btngetallvalues";
            this.btngetallvalues.Size = new System.Drawing.Size(152, 51);
            this.btngetallvalues.TabIndex = 81;
            this.btngetallvalues.Text = "All Details";
            this.btngetallvalues.UseVisualStyleBackColor = false;
            this.btngetallvalues.Click += new System.EventHandler(this.btngetallvalues_Click);
            // 
            // llblemp
            // 
            this.llblemp.AutoSize = true;
            this.llblemp.BackColor = System.Drawing.Color.Transparent;
            this.llblemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblemp.Location = new System.Drawing.Point(45, 119);
            this.llblemp.Name = "llblemp";
            this.llblemp.Size = new System.Drawing.Size(109, 25);
            this.llblemp.TabIndex = 80;
            this.llblemp.Text = "Employees";
            // 
            // cmbatt
            // 
            this.cmbatt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbatt.FormattingEnabled = true;
            this.cmbatt.Items.AddRange(new object[] {
            "All Employee",
            "Driver",
            "Cleaner",
            "Reception",
            "Head Chef",
            "Manager"});
            this.cmbatt.Location = new System.Drawing.Point(155, 110);
            this.cmbatt.Name = "cmbatt";
            this.cmbatt.Size = new System.Drawing.Size(165, 37);
            this.cmbatt.TabIndex = 79;
            // 
            // dataform
            // 
            this.dataform.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataform.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataform.Location = new System.Drawing.Point(583, 110);
            this.dataform.Name = "dataform";
            this.dataform.Size = new System.Drawing.Size(200, 38);
            this.dataform.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(528, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 77;
            this.label1.Text = "From";
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this.buniPanelTopStock;
            // 
            // buniPanelTopStock
            // 
            this.buniPanelTopStock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buniPanelTopStock.BackgroundImage")));
            this.buniPanelTopStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buniPanelTopStock.Controls.Add(this.gunaControlBox1);
            this.buniPanelTopStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.buniPanelTopStock.GradientBottomLeft = System.Drawing.Color.SaddleBrown;
            this.buniPanelTopStock.GradientBottomRight = System.Drawing.Color.White;
            this.buniPanelTopStock.GradientTopLeft = System.Drawing.Color.Gold;
            this.buniPanelTopStock.GradientTopRight = System.Drawing.Color.White;
            this.buniPanelTopStock.Location = new System.Drawing.Point(0, 0);
            this.buniPanelTopStock.Name = "buniPanelTopStock";
            this.buniPanelTopStock.Quality = 10;
            this.buniPanelTopStock.Size = new System.Drawing.Size(1246, 37);
            this.buniPanelTopStock.TabIndex = 68;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.BackColor = System.Drawing.Color.Red;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(1189, 3);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.Red;
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox1.TabIndex = 0;
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
            this.panelBottomStock.Location = new System.Drawing.Point(0, 724);
            this.panelBottomStock.Name = "panelBottomStock";
            this.panelBottomStock.Size = new System.Drawing.Size(1246, 48);
            this.panelBottomStock.TabIndex = 82;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.BackColor = System.Drawing.Color.Transparent;
            this.lbldate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbldate.Location = new System.Drawing.Point(1085, 23);
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
            this.lbltime.Location = new System.Drawing.Point(1114, 6);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(72, 17);
            this.lbltime.TabIndex = 60;
            this.lbltime.Text = "12:00 P.M";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(914, 10);
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
            this.lblDateTime.Location = new System.Drawing.Point(1006, 16);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(61, 23);
            this.lblDateTime.TabIndex = 6;
            this.lblDateTime.Text = "Time";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(844, 10);
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
            this.labelBottom.Location = new System.Drawing.Point(408, 16);
            this.labelBottom.Name = "labelBottom";
            this.labelBottom.Size = new System.Drawing.Size(387, 23);
            this.labelBottom.TabIndex = 0;
            this.labelBottom.Text = "2020@CodeSpace All rights reserved ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gunaDragControl2
            // 
            this.gunaDragControl2.TargetControl = this.buniPanelTopStock;
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.BackColor = System.Drawing.Color.Transparent;
            this.lblsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsearch.Location = new System.Drawing.Point(508, 169);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(75, 25);
            this.lblsearch.TabIndex = 84;
            this.lblsearch.Text = "Search";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1020, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 52);
            this.button1.TabIndex = 85;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // empattdatagrid
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(205)))), ((int)(((byte)(189)))));
            this.empattdatagrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.empattdatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.empattdatagrid.BackgroundColor = System.Drawing.Color.White;
            this.empattdatagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.empattdatagrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.empattdatagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.empattdatagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.empattdatagrid.ColumnHeadersHeight = 50;
            this.empattdatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.empid,
            this.dgfirstname,
            this.dglastname,
            this.dgdate,
            this.dgintime,
            this.dgouttime,
            this.dgstatus});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(221)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(143)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.empattdatagrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.empattdatagrid.EnableHeadersVisualStyles = false;
            this.empattdatagrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(203)))), ((int)(((byte)(186)))));
            this.empattdatagrid.Location = new System.Drawing.Point(49, 211);
            this.empattdatagrid.Name = "empattdatagrid";
            this.empattdatagrid.ReadOnly = true;
            this.empattdatagrid.RowHeadersVisible = false;
            this.empattdatagrid.RowHeadersWidth = 51;
            this.empattdatagrid.RowTemplate.Height = 24;
            this.empattdatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.empattdatagrid.Size = new System.Drawing.Size(1137, 440);
            this.empattdatagrid.TabIndex = 72;
            this.empattdatagrid.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.DeepOrange;
            this.empattdatagrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(205)))), ((int)(((byte)(189)))));
            this.empattdatagrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.empattdatagrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.empattdatagrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.empattdatagrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.empattdatagrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.empattdatagrid.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(203)))), ((int)(((byte)(186)))));
            this.empattdatagrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.empattdatagrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.empattdatagrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.empattdatagrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.empattdatagrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.empattdatagrid.ThemeStyle.HeaderStyle.Height = 50;
            this.empattdatagrid.ThemeStyle.ReadOnly = true;
            this.empattdatagrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(221)))), ((int)(((byte)(211)))));
            this.empattdatagrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.empattdatagrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.empattdatagrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.empattdatagrid.ThemeStyle.RowsStyle.Height = 24;
            this.empattdatagrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(143)))), ((int)(((byte)(107)))));
            this.empattdatagrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "AttendenceID";
            this.Column1.HeaderText = "AttendenceID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // empid
            // 
            this.empid.DataPropertyName = "EmpID";
            this.empid.HeaderText = "Employee ID";
            this.empid.MinimumWidth = 6;
            this.empid.Name = "empid";
            this.empid.ReadOnly = true;
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
            this.dgintime.DataPropertyName = "INtime";
            this.dgintime.HeaderText = "IN TIme";
            this.dgintime.MinimumWidth = 6;
            this.dgintime.Name = "dgintime";
            this.dgintime.ReadOnly = true;
            // 
            // dgouttime
            // 
            this.dgouttime.DataPropertyName = "OutTime";
            this.dgouttime.HeaderText = "OUT Time";
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
            // Brnfind
            // 
            this.Brnfind.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Brnfind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Brnfind.ForeColor = System.Drawing.Color.White;
            this.Brnfind.Location = new System.Drawing.Point(1020, 106);
            this.Brnfind.Name = "Brnfind";
            this.Brnfind.Size = new System.Drawing.Size(145, 52);
            this.Brnfind.TabIndex = 71;
            this.Brnfind.Text = "Find";
            this.Brnfind.UseVisualStyleBackColor = false;
            this.Brnfind.Click += new System.EventHandler(this.Brnfind_Click);
            // 
            // datato
            // 
            this.datato.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datato.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datato.Location = new System.Drawing.Point(833, 110);
            this.datato.Name = "datato";
            this.datato.Size = new System.Drawing.Size(181, 38);
            this.datato.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(794, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 25);
            this.label2.TabIndex = 69;
            this.label2.Text = "To";
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Black;
            this.btnback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.Color.White;
            this.btnback.Location = new System.Drawing.Point(54, 657);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(180, 58);
            this.btnback.TabIndex = 76;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.Black;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.Color.White;
            this.btncancel.Location = new System.Drawing.Point(1046, 657);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(140, 58);
            this.btncancel.TabIndex = 75;
            this.btncancel.Text = "Canecl";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(487, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 36);
            this.label4.TabIndex = 74;
            this.label4.Text = "Attendence Report";
            // 
            // btnddelete
            // 
            this.btnddelete.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnddelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnddelete.ForeColor = System.Drawing.Color.White;
            this.btnddelete.Location = new System.Drawing.Point(865, 657);
            this.btnddelete.Name = "btnddelete";
            this.btnddelete.Size = new System.Drawing.Size(175, 58);
            this.btnddelete.TabIndex = 73;
            this.btnddelete.Text = "Print";
            this.btnddelete.UseVisualStyleBackColor = false;
            // 
            // EmployeeAttendenceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::Sarasi_HMS.Properties.Resources.green;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1246, 772);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.btngetallvalues);
            this.Controls.Add(this.llblemp);
            this.Controls.Add(this.cmbatt);
            this.Controls.Add(this.dataform);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelBottomStock);
            this.Controls.Add(this.lblsearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.empattdatagrid);
            this.Controls.Add(this.Brnfind);
            this.Controls.Add(this.datato);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnddelete);
            this.Controls.Add(this.buniPanelTopStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeAttendenceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeAttendenceReport";
            this.Load += new System.EventHandler(this.EmployeeAttendenceReport_Load);
            this.buniPanelTopStock.ResumeLayout(false);
            this.panelBottomStock.ResumeLayout(false);
            this.panelBottomStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empattdatagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btngetallvalues;
        private System.Windows.Forms.Label llblemp;
        private System.Windows.Forms.ComboBox cmbatt;
        private System.Windows.Forms.DateTimePicker dataform;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private Bunifu.Framework.UI.BunifuGradientPanel buniPanelTopStock;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private System.Windows.Forms.Panel panelBottomStock;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelBottom;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl2;
        private System.Windows.Forms.Label lblsearch;
        private System.Windows.Forms.Button button1;
        private Guna.UI.WinForms.GunaDataGridView empattdatagrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn empid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgfirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dglastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgintime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgouttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgstatus;
        private System.Windows.Forms.Button Brnfind;
        private System.Windows.Forms.DateTimePicker datato;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnddelete;
      
        private System.Windows.Forms.BindingSource employeeBindingSource1;
       
    }
}