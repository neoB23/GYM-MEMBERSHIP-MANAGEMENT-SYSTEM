namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UI
{
    partial class formlatputdown
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formlatputdown));
            this.label1 = new System.Windows.Forms.Label();
            this.bntbackdown = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "latputdown";
            // 
            // bntbackdown
            // 
            this.bntbackdown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bntbackdown.BackgroundImage")));
            this.bntbackdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntbackdown.CheckedState.Parent = this.bntbackdown;
            this.bntbackdown.CustomImages.Parent = this.bntbackdown;
            this.bntbackdown.FillColor = System.Drawing.Color.Transparent;
            this.bntbackdown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bntbackdown.ForeColor = System.Drawing.Color.White;
            this.bntbackdown.HoverState.Parent = this.bntbackdown;
            this.bntbackdown.Location = new System.Drawing.Point(463, 300);
            this.bntbackdown.Name = "bntbackdown";
            this.bntbackdown.ShadowDecoration.Parent = this.bntbackdown;
            this.bntbackdown.Size = new System.Drawing.Size(128, 48);
            this.bntbackdown.TabIndex = 28;
            this.bntbackdown.Click += new System.EventHandler(this.bntbackdown_Click);
            // 
            // formlatputdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bntbackdown);
            this.Controls.Add(this.label1);
            this.Name = "formlatputdown";
            this.Text = "formlatputdown";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button bntbackdown;
    }
}