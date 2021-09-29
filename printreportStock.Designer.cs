namespace Sarasi_HMS
{
    partial class printreportStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(printreportStock));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.buniPanelTopStock = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.stockdetails = new System.Windows.Forms.Button();
            this.eeDataSet = new Sarasi_HMS.eeDataSet();
            this.stockAuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockAuditTableAdapter = new Sarasi_HMS.eeDataSetTableAdapters.StockAuditTableAdapter();
            this.StockAudit1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StockAudit1TableAdapter = new Sarasi_HMS.eeDataSetTableAdapters.StockAudit1TableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buniPanelTopStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockAuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockAudit1BindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.buniPanelTopStock.Size = new System.Drawing.Size(958, 37);
            this.buniPanelTopStock.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(907, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(51, 37);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.StockAudit1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sarasi_HMS.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(29, 96);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(917, 515);
            this.reportViewer1.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.stockAuditBindingSource;
            this.comboBox1.DisplayMember = "date";
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(516, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(217, 37);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.ValueMember = "date";
            // 
            // stockdetails
            // 
            this.stockdetails.Location = new System.Drawing.Point(739, 53);
            this.stockdetails.Name = "stockdetails";
            this.stockdetails.Size = new System.Drawing.Size(139, 37);
            this.stockdetails.TabIndex = 6;
            this.stockdetails.Text = "Details";
            this.stockdetails.UseVisualStyleBackColor = true;
            this.stockdetails.Click += new System.EventHandler(this.stockdetails_Click);
            // 
            // eeDataSet
            // 
            this.eeDataSet.DataSetName = "eeDataSet";
            this.eeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stockAuditBindingSource
            // 
            this.stockAuditBindingSource.DataMember = "StockAudit";
            this.stockAuditBindingSource.DataSource = this.eeDataSet;
            // 
            // stockAuditTableAdapter
            // 
            this.stockAuditTableAdapter.ClearBeforeFill = true;
            // 
            // StockAudit1BindingSource
            // 
            this.StockAudit1BindingSource.DataMember = "StockAudit1";
            this.StockAudit1BindingSource.DataSource = this.eeDataSet;
            // 
            // StockAudit1TableAdapter
            // 
            this.StockAudit1TableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(362, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Stock Date";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "Details";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // printreportStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 646);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stockdetails);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.buniPanelTopStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "printreportStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "printreportStock";
            this.Load += new System.EventHandler(this.printreportStock_Load);
            this.buniPanelTopStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockAuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockAudit1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel buniPanelTopStock;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button stockdetails;
        private eeDataSet eeDataSet;
        private System.Windows.Forms.BindingSource stockAuditBindingSource;
        private eeDataSetTableAdapters.StockAuditTableAdapter stockAuditTableAdapter;
        private System.Windows.Forms.BindingSource StockAudit1BindingSource;
        private eeDataSetTableAdapters.StockAudit1TableAdapter StockAudit1TableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}