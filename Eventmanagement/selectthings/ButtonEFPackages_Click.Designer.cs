namespace Sarasi_HMS.Eventmanagement.selectthings
{
    partial class ButtonEFPackages_Click
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonEFPackages_Click));
            this.lblPackageBtnName = new System.Windows.Forms.Label();
            this.lblPackageBtnID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPackageBtnName
            // 
            this.lblPackageBtnName.AutoSize = true;
            this.lblPackageBtnName.Font = new System.Drawing.Font("Century", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageBtnName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPackageBtnName.Location = new System.Drawing.Point(79, 27);
            this.lblPackageBtnName.Name = "lblPackageBtnName";
            this.lblPackageBtnName.Size = new System.Drawing.Size(155, 44);
            this.lblPackageBtnName.TabIndex = 8;
            this.lblPackageBtnName.Text = "PName";
            // 
            // lblPackageBtnID
            // 
            this.lblPackageBtnID.AutoSize = true;
            this.lblPackageBtnID.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPackageBtnID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPackageBtnID.Location = new System.Drawing.Point(172, 5);
            this.lblPackageBtnID.Name = "lblPackageBtnID";
            this.lblPackageBtnID.Size = new System.Drawing.Size(76, 17);
            this.lblPackageBtnID.TabIndex = 7;
            this.lblPackageBtnID.Text = "PackageID";
            this.lblPackageBtnID.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 56);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // ButtonEFPackages_Click
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lblPackageBtnName);
            this.Controls.Add(this.lblPackageBtnID);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ButtonEFPackages_Click";
            this.Size = new System.Drawing.Size(261, 92);
            this.Click += new System.EventHandler(this.ButtonEFPackages_Click_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPackageBtnName;
        private System.Windows.Forms.Label lblPackageBtnID;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
