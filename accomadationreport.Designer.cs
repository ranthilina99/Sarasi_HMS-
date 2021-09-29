namespace Sarasi_HMS
{
    partial class accomadationreport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.eeDataSet = new Sarasi_HMS.eeDataSet();
            this.BillPayment11BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BillPayment11TableAdapter = new Sarasi_HMS.eeDataSetTableAdapters.BillPayment11TableAdapter();
            this.billPayment1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.billPayment1TableAdapter = new Sarasi_HMS.eeDataSetTableAdapters.BillPayment1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.eeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillPayment11BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billPayment1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource6.Name = "DataSet1";
            reportDataSource6.Value = this.BillPayment11BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sarasi_HMS.Accreprtlist.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(50, 90);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(702, 304);
            this.reportViewer1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.billPayment1BindingSource;
            this.comboBox1.DisplayMember = "Guestid";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(348, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(189, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "Guestid";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(578, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(63, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // eeDataSet
            // 
            this.eeDataSet.DataSetName = "eeDataSet";
            this.eeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BillPayment11BindingSource
            // 
            this.BillPayment11BindingSource.DataMember = "BillPayment11";
            this.BillPayment11BindingSource.DataSource = this.eeDataSet;
            // 
            // BillPayment11TableAdapter
            // 
            this.BillPayment11TableAdapter.ClearBeforeFill = true;
            // 
            // billPayment1BindingSource
            // 
            this.billPayment1BindingSource.DataMember = "BillPayment1";
            this.billPayment1BindingSource.DataSource = this.eeDataSet;
            // 
            // billPayment1TableAdapter
            // 
            this.billPayment1TableAdapter.ClearBeforeFill = true;
            // 
            // accomadationreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "accomadationreport";
            this.Text = "accomadationreport";
            this.Load += new System.EventHandler(this.accomadationreport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillPayment11BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billPayment1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource BillPayment11BindingSource;
        private eeDataSet eeDataSet;
        private eeDataSetTableAdapters.BillPayment11TableAdapter BillPayment11TableAdapter;
        private System.Windows.Forms.BindingSource billPayment1BindingSource;
        private eeDataSetTableAdapters.BillPayment1TableAdapter billPayment1TableAdapter;
    }
}