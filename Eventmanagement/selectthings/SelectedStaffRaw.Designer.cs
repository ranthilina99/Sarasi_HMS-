namespace Sarasi_HMS.Eventmanagement.selectthings
{
    partial class SelectedStaffRaw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectedStaffRaw));
            this.lblSTSlName1 = new System.Windows.Forms.Label();
            this.lblSTSSalary1 = new System.Windows.Forms.Label();
            this.lblSTSType1 = new System.Windows.Forms.Label();
            this.lblSTSfName1 = new System.Windows.Forms.Label();
            this.lblSTSID1 = new System.Windows.Forms.Label();
            this.btndeleteSelect = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btndeleteSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSTSlName1
            // 
            this.lblSTSlName1.AutoSize = true;
            this.lblSTSlName1.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTSlName1.ForeColor = System.Drawing.Color.White;
            this.lblSTSlName1.Location = new System.Drawing.Point(130, 23);
            this.lblSTSlName1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSTSlName1.Name = "lblSTSlName1";
            this.lblSTSlName1.Size = new System.Drawing.Size(91, 28);
            this.lblSTSlName1.TabIndex = 111;
            this.lblSTSlName1.Text = "lName";
            // 
            // lblSTSSalary1
            // 
            this.lblSTSSalary1.AutoSize = true;
            this.lblSTSSalary1.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTSSalary1.ForeColor = System.Drawing.Color.White;
            this.lblSTSSalary1.Location = new System.Drawing.Point(343, 23);
            this.lblSTSSalary1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSTSSalary1.Name = "lblSTSSalary1";
            this.lblSTSSalary1.Size = new System.Drawing.Size(91, 28);
            this.lblSTSSalary1.TabIndex = 109;
            this.lblSTSSalary1.Text = "Salary";
            // 
            // lblSTSType1
            // 
            this.lblSTSType1.AutoSize = true;
            this.lblSTSType1.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTSType1.ForeColor = System.Drawing.Color.White;
            this.lblSTSType1.Location = new System.Drawing.Point(244, 23);
            this.lblSTSType1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSTSType1.Name = "lblSTSType1";
            this.lblSTSType1.Size = new System.Drawing.Size(71, 28);
            this.lblSTSType1.TabIndex = 108;
            this.lblSTSType1.Text = "Type";
            // 
            // lblSTSfName1
            // 
            this.lblSTSfName1.AutoSize = true;
            this.lblSTSfName1.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTSfName1.ForeColor = System.Drawing.Color.White;
            this.lblSTSfName1.Location = new System.Drawing.Point(13, 23);
            this.lblSTSfName1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSTSfName1.Name = "lblSTSfName1";
            this.lblSTSfName1.Size = new System.Drawing.Size(91, 28);
            this.lblSTSfName1.TabIndex = 107;
            this.lblSTSfName1.Text = "fName";
            // 
            // lblSTSID1
            // 
            this.lblSTSID1.AutoSize = true;
            this.lblSTSID1.BackColor = System.Drawing.Color.Transparent;
            this.lblSTSID1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTSID1.ForeColor = System.Drawing.Color.White;
            this.lblSTSID1.Location = new System.Drawing.Point(391, 9);
            this.lblSTSID1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSTSID1.Name = "lblSTSID1";
            this.lblSTSID1.Size = new System.Drawing.Size(43, 17);
            this.lblSTSID1.TabIndex = 106;
            this.lblSTSID1.Text = "TS ID";
            this.lblSTSID1.Visible = false;
            // 
            // btndeleteSelect
            // 
            this.btndeleteSelect.Image = ((System.Drawing.Image)(resources.GetObject("btndeleteSelect.Image")));
            this.btndeleteSelect.Location = new System.Drawing.Point(457, 9);
            this.btndeleteSelect.Name = "btndeleteSelect";
            this.btndeleteSelect.Size = new System.Drawing.Size(37, 38);
            this.btndeleteSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btndeleteSelect.TabIndex = 110;
            this.btndeleteSelect.TabStop = false;
            this.btndeleteSelect.Click += new System.EventHandler(this.btndeleteSelect_Click);
            // 
            // SelectedStaffRaw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.lblSTSlName1);
            this.Controls.Add(this.btndeleteSelect);
            this.Controls.Add(this.lblSTSSalary1);
            this.Controls.Add(this.lblSTSType1);
            this.Controls.Add(this.lblSTSfName1);
            this.Controls.Add(this.lblSTSID1);
            this.Name = "SelectedStaffRaw";
            this.Size = new System.Drawing.Size(507, 60);
            ((System.ComponentModel.ISupportInitialize)(this.btndeleteSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSTSlName1;
        private System.Windows.Forms.PictureBox btndeleteSelect;
        private System.Windows.Forms.Label lblSTSSalary1;
        private System.Windows.Forms.Label lblSTSType1;
        private System.Windows.Forms.Label lblSTSfName1;
        private System.Windows.Forms.Label lblSTSID1;
    }
}
