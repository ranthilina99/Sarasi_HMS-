namespace Sarasi_HMS.Eventmanagement.selectthings
{
    partial class ButtonEDTeams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonEDTeams));
            this.lblDTeamBtnName = new System.Windows.Forms.Label();
            this.lblDTBtnID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDTeamBtnName
            // 
            this.lblDTeamBtnName.AutoSize = true;
            this.lblDTeamBtnName.Font = new System.Drawing.Font("Century", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDTeamBtnName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDTeamBtnName.Location = new System.Drawing.Point(62, 33);
            this.lblDTeamBtnName.Name = "lblDTeamBtnName";
            this.lblDTeamBtnName.Size = new System.Drawing.Size(186, 44);
            this.lblDTeamBtnName.TabIndex = 11;
            this.lblDTeamBtnName.Text = "DTName";
            // 
            // lblDTBtnID
            // 
            this.lblDTBtnID.AutoSize = true;
            this.lblDTBtnID.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDTBtnID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDTBtnID.Location = new System.Drawing.Point(186, 10);
            this.lblDTBtnID.Name = "lblDTBtnID";
            this.lblDTBtnID.Size = new System.Drawing.Size(67, 17);
            this.lblDTBtnID.TabIndex = 10;
            this.lblDTBtnID.Text = "DTeamID";
            this.lblDTBtnID.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 56);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // ButtonEDTeams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lblDTeamBtnName);
            this.Controls.Add(this.lblDTBtnID);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ButtonEDTeams";
            this.Size = new System.Drawing.Size(261, 92);
            this.Click += new System.EventHandler(this.ButtonEDTeams_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDTeamBtnName;
        private System.Windows.Forms.Label lblDTBtnID;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
