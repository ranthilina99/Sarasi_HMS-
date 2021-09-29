namespace Sarasi_HMS
{
    partial class newOrderToPrepare
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnServed = new System.Windows.Forms.Button();
            this.lblorderContent = new System.Windows.Forms.Label();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(110, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "new Order";
            // 
            // btnServed
            // 
            this.btnServed.BackColor = System.Drawing.Color.Transparent;
            this.btnServed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnServed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServed.ForeColor = System.Drawing.Color.Gold;
            this.btnServed.Location = new System.Drawing.Point(0, 192);
            this.btnServed.Name = "btnServed";
            this.btnServed.Size = new System.Drawing.Size(335, 43);
            this.btnServed.TabIndex = 2;
            this.btnServed.Text = "Served";
            this.btnServed.UseVisualStyleBackColor = false;
            this.btnServed.Click += new System.EventHandler(this.btnServed_Click);
            // 
            // lblorderContent
            // 
            this.lblorderContent.AutoSize = true;
            this.lblorderContent.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblorderContent.ForeColor = System.Drawing.Color.White;
            this.lblorderContent.Location = new System.Drawing.Point(3, 90);
            this.lblorderContent.Name = "lblorderContent";
            this.lblorderContent.Size = new System.Drawing.Size(146, 21);
            this.lblorderContent.TabIndex = 4;
            this.lblorderContent.Text = "items -quantity";
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblOrderId.Location = new System.Drawing.Point(20, 45);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(55, 17);
            this.lblOrderId.TabIndex = 5;
            this.lblOrderId.Text = "orderID";
            this.lblOrderId.Visible = false;
            // 
            // newOrderToPrepare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.lblorderContent);
            this.Controls.Add(this.btnServed);
            this.Controls.Add(this.label1);
            this.Name = "newOrderToPrepare";
            this.Size = new System.Drawing.Size(335, 235);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnServed;
        private System.Windows.Forms.Label lblorderContent;
        private System.Windows.Forms.Label lblOrderId;
    }
}
