namespace Sarasi_HMS
{
    partial class restreport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(restreport));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.buniPanelTop = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.OrderreportId = new System.Windows.Forms.Label();
            this.Details = new System.Windows.Forms.Button();
            this.eeDataSet = new Sarasi_HMS.eeDataSet();
            this.DataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataTable2TableAdapter = new Sarasi_HMS.eeDataSetTableAdapters.DataTable2TableAdapter();
            this.buniPanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buniPanelTop
            // 
            this.buniPanelTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buniPanelTop.BackgroundImage")));
            this.buniPanelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buniPanelTop.Controls.Add(this.btnClose);
            this.buniPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.buniPanelTop.GradientBottomLeft = System.Drawing.Color.SaddleBrown;
            this.buniPanelTop.GradientBottomRight = System.Drawing.Color.White;
            this.buniPanelTop.GradientTopLeft = System.Drawing.Color.Gold;
            this.buniPanelTop.GradientTopRight = System.Drawing.Color.White;
            this.buniPanelTop.Location = new System.Drawing.Point(0, 0);
            this.buniPanelTop.Name = "buniPanelTop";
            this.buniPanelTop.Quality = 10;
            this.buniPanelTop.Size = new System.Drawing.Size(981, 37);
            this.buniPanelTop.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(930, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(51, 37);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTable2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sarasi_HMS.Stockreport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(26, 110);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(923, 473);
            this.reportViewer1.TabIndex = 4;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(464, 48);
            this.txtOrderID.Multiline = true;
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(287, 46);
            this.txtOrderID.TabIndex = 5;
            // 
            // OrderreportId
            // 
            this.OrderreportId.AutoSize = true;
            this.OrderreportId.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderreportId.Location = new System.Drawing.Point(359, 55);
            this.OrderreportId.Name = "OrderreportId";
            this.OrderreportId.Size = new System.Drawing.Size(99, 29);
            this.OrderreportId.TabIndex = 6;
            this.OrderreportId.Text = "OrderID";
            // 
            // Details
            // 
            this.Details.Location = new System.Drawing.Point(777, 48);
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(138, 46);
            this.Details.TabIndex = 7;
            this.Details.Text = "Get Details";
            this.Details.UseVisualStyleBackColor = true;
            this.Details.Click += new System.EventHandler(this.Details_Click);
            // 
            // eeDataSet
            // 
            this.eeDataSet.DataSetName = "eeDataSet";
            this.eeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable2BindingSource
            // 
            this.DataTable2BindingSource.DataMember = "DataTable2";
            this.DataTable2BindingSource.DataSource = this.eeDataSet;
            // 
            // DataTable2TableAdapter
            // 
            this.DataTable2TableAdapter.ClearBeforeFill = true;
            // 
            // restreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 645);
            this.Controls.Add(this.Details);
            this.Controls.Add(this.OrderreportId);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.buniPanelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "restreport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "restreport";
            this.Load += new System.EventHandler(this.restreport_Load);
            this.buniPanelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel buniPanelTop;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label OrderreportId;
        private System.Windows.Forms.Button Details;
        private System.Windows.Forms.BindingSource DataTable2BindingSource;
        private eeDataSet eeDataSet;
        private eeDataSetTableAdapters.DataTable2TableAdapter DataTable2TableAdapter;
    }
}