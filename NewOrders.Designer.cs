namespace Sarasi_HMS
{
    partial class NewOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewOrders));
            this.flowOrders = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBackNewOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowOrders
            // 
            this.flowOrders.BackColor = System.Drawing.Color.Transparent;
            this.flowOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowOrders.Location = new System.Drawing.Point(0, 0);
            this.flowOrders.Name = "flowOrders";
            this.flowOrders.Size = new System.Drawing.Size(1180, 550);
            this.flowOrders.TabIndex = 26;
            // 
            // btnBackNewOrders
            // 
            this.btnBackNewOrders.BackColor = System.Drawing.Color.Black;
            this.btnBackNewOrders.FlatAppearance.BorderSize = 0;
            this.btnBackNewOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackNewOrders.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackNewOrders.ForeColor = System.Drawing.Color.White;
            this.btnBackNewOrders.Image = ((System.Drawing.Image)(resources.GetObject("btnBackNewOrders.Image")));
            this.btnBackNewOrders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackNewOrders.Location = new System.Drawing.Point(38, 556);
            this.btnBackNewOrders.Name = "btnBackNewOrders";
            this.btnBackNewOrders.Size = new System.Drawing.Size(188, 46);
            this.btnBackNewOrders.TabIndex = 27;
            this.btnBackNewOrders.Text = "    Back";
            this.btnBackNewOrders.UseVisualStyleBackColor = false;
            this.btnBackNewOrders.Click += new System.EventHandler(this.btnBackNewOrders_Click);
            // 
            // NewOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1180, 614);
            this.Controls.Add(this.btnBackNewOrders);
            this.Controls.Add(this.flowOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewOrders";
            this.Load += new System.EventHandler(this.NewOrders_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowOrders;
        private System.Windows.Forms.Button btnBackNewOrders;
    }
}