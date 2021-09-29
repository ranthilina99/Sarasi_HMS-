namespace Sarasi_HMS
{
    partial class Selector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Selector));
            this.btnRestaurant = new System.Windows.Forms.Button();
            this.btnEventBookings = new System.Windows.Forms.Button();
            this.btnVehicleRent = new System.Windows.Forms.Button();
            this.btnreservation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRestaurant
            // 
            this.btnRestaurant.BackColor = System.Drawing.Color.Black;
            this.btnRestaurant.FlatAppearance.BorderSize = 0;
            this.btnRestaurant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurant.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurant.ForeColor = System.Drawing.Color.White;
            this.btnRestaurant.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurant.Image")));
            this.btnRestaurant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestaurant.Location = new System.Drawing.Point(29, 15);
            this.btnRestaurant.Name = "btnRestaurant";
            this.btnRestaurant.Size = new System.Drawing.Size(350, 88);
            this.btnRestaurant.TabIndex = 19;
            this.btnRestaurant.Text = "     Restaurant ";
            this.btnRestaurant.UseVisualStyleBackColor = false;
            this.btnRestaurant.Click += new System.EventHandler(this.btnRestaurant_Click);
            // 
            // btnEventBookings
            // 
            this.btnEventBookings.BackColor = System.Drawing.Color.Black;
            this.btnEventBookings.FlatAppearance.BorderSize = 0;
            this.btnEventBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEventBookings.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEventBookings.ForeColor = System.Drawing.Color.White;
            this.btnEventBookings.Image = ((System.Drawing.Image)(resources.GetObject("btnEventBookings.Image")));
            this.btnEventBookings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEventBookings.Location = new System.Drawing.Point(29, 109);
            this.btnEventBookings.Name = "btnEventBookings";
            this.btnEventBookings.Size = new System.Drawing.Size(350, 88);
            this.btnEventBookings.TabIndex = 20;
            this.btnEventBookings.Text = "     Event Bookings";
            this.btnEventBookings.UseVisualStyleBackColor = false;
            this.btnEventBookings.Click += new System.EventHandler(this.btnEventBookings_Click);
            // 
            // btnVehicleRent
            // 
            this.btnVehicleRent.BackColor = System.Drawing.Color.Black;
            this.btnVehicleRent.FlatAppearance.BorderSize = 0;
            this.btnVehicleRent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicleRent.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicleRent.ForeColor = System.Drawing.Color.White;
            this.btnVehicleRent.Image = ((System.Drawing.Image)(resources.GetObject("btnVehicleRent.Image")));
            this.btnVehicleRent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehicleRent.Location = new System.Drawing.Point(29, 203);
            this.btnVehicleRent.Name = "btnVehicleRent";
            this.btnVehicleRent.Size = new System.Drawing.Size(350, 88);
            this.btnVehicleRent.TabIndex = 21;
            this.btnVehicleRent.Text = "   Vehicle Rent";
            this.btnVehicleRent.UseVisualStyleBackColor = false;
            this.btnVehicleRent.Click += new System.EventHandler(this.btnVehicleRent_Click);
            // 
            // btnreservation
            // 
            this.btnreservation.BackColor = System.Drawing.Color.Black;
            this.btnreservation.FlatAppearance.BorderSize = 0;
            this.btnreservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreservation.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreservation.ForeColor = System.Drawing.Color.White;
            this.btnreservation.Image = ((System.Drawing.Image)(resources.GetObject("btnreservation.Image")));
            this.btnreservation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnreservation.Location = new System.Drawing.Point(29, 302);
            this.btnreservation.Name = "btnreservation";
            this.btnreservation.Size = new System.Drawing.Size(350, 88);
            this.btnreservation.TabIndex = 22;
            this.btnreservation.Text = "   Reservations ";
            this.btnreservation.UseVisualStyleBackColor = false;
            this.btnreservation.Click += new System.EventHandler(this.btnreservation_Click);
            // 
            // Selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sarasi_HMS.Properties.Resources.green;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(418, 431);
            this.Controls.Add(this.btnreservation);
            this.Controls.Add(this.btnVehicleRent);
            this.Controls.Add(this.btnEventBookings);
            this.Controls.Add(this.btnRestaurant);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Selector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRestaurant;
        private System.Windows.Forms.Button btnEventBookings;
        private System.Windows.Forms.Button btnVehicleRent;
        private System.Windows.Forms.Button btnreservation;
    }
}