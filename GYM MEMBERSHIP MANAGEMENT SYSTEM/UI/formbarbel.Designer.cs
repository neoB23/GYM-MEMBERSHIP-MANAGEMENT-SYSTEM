namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UI
{
    partial class formbarbel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formbarbel));
            this.label1 = new System.Windows.Forms.Label();
            this.bntbackbarbel = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(495, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "barbel";
            // 
            // bntbackbarbel
            // 
            this.bntbackbarbel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bntbackbarbel.BackgroundImage")));
            this.bntbackbarbel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntbackbarbel.CheckedState.Parent = this.bntbackbarbel;
            this.bntbackbarbel.CustomImages.Parent = this.bntbackbarbel;
            this.bntbackbarbel.FillColor = System.Drawing.Color.Transparent;
            this.bntbackbarbel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bntbackbarbel.ForeColor = System.Drawing.Color.White;
            this.bntbackbarbel.HoverState.Parent = this.bntbackbarbel;
            this.bntbackbarbel.Location = new System.Drawing.Point(419, 265);
            this.bntbackbarbel.Name = "bntbackbarbel";
            this.bntbackbarbel.ShadowDecoration.Parent = this.bntbackbarbel;
            this.bntbackbarbel.Size = new System.Drawing.Size(128, 48);
            this.bntbackbarbel.TabIndex = 28;
            // 
            // formbarbel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 500);
            this.Controls.Add(this.bntbackbarbel);
            this.Controls.Add(this.label1);
            this.Name = "formbarbel";
            this.Text = "formbarbel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button bntbackbarbel;
    }
}