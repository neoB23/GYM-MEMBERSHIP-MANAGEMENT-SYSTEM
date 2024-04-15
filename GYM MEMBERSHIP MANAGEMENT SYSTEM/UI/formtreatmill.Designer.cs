namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UI
{
    partial class formtreatmill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formtreatmill));
            this.label1 = new System.Windows.Forms.Label();
            this.bntbacktreatmill = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "treatmill";
            // 
            // bntbacktreatmill
            // 
            this.bntbacktreatmill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bntbacktreatmill.BackgroundImage")));
            this.bntbacktreatmill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntbacktreatmill.CheckedState.Parent = this.bntbacktreatmill;
            this.bntbacktreatmill.CustomImages.Parent = this.bntbacktreatmill;
            this.bntbacktreatmill.FillColor = System.Drawing.Color.Transparent;
            this.bntbacktreatmill.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bntbacktreatmill.ForeColor = System.Drawing.Color.White;
            this.bntbacktreatmill.HoverState.Parent = this.bntbacktreatmill;
            this.bntbacktreatmill.Location = new System.Drawing.Point(442, 278);
            this.bntbacktreatmill.Name = "bntbacktreatmill";
            this.bntbacktreatmill.ShadowDecoration.Parent = this.bntbacktreatmill;
            this.bntbacktreatmill.Size = new System.Drawing.Size(128, 48);
            this.bntbacktreatmill.TabIndex = 28;
            // 
            // formtreatmill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bntbacktreatmill);
            this.Controls.Add(this.label1);
            this.Name = "formtreatmill";
            this.Text = "formtreatmill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button bntbacktreatmill;
    }
}