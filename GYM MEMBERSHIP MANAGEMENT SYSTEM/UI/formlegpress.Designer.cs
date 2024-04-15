namespace GYM_MEMBERSHIP_MANAGEMENT_SYSTEM.UI
{
    partial class formlegpress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formlegpress));
            this.bntbackleg = new System.Windows.Forms.Label();
            this.modaleffecttimer = new System.Windows.Forms.Timer(this.components);
            this.bntlegpress = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // bntbackleg
            // 
            this.bntbackleg.AutoSize = true;
            this.bntbackleg.Location = new System.Drawing.Point(377, 145);
            this.bntbackleg.Name = "bntbackleg";
            this.bntbackleg.Size = new System.Drawing.Size(46, 13);
            this.bntbackleg.TabIndex = 0;
            this.bntbackleg.Text = "legpress";
            // 
            // modaleffecttimer
            // 
            this.modaleffecttimer.Enabled = true;
            this.modaleffecttimer.Interval = 1;
            this.modaleffecttimer.Tick += new System.EventHandler(this.modaleffecttimer_Tick);
            // 
            // bntlegpress
            // 
            this.bntlegpress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bntlegpress.BackgroundImage")));
            this.bntlegpress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntlegpress.CheckedState.Parent = this.bntlegpress;
            this.bntlegpress.CustomImages.Parent = this.bntlegpress;
            this.bntlegpress.FillColor = System.Drawing.Color.Transparent;
            this.bntlegpress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bntlegpress.ForeColor = System.Drawing.Color.White;
            this.bntlegpress.HoverState.Parent = this.bntlegpress;
            this.bntlegpress.Location = new System.Drawing.Point(340, 204);
            this.bntlegpress.Name = "bntlegpress";
            this.bntlegpress.ShadowDecoration.Parent = this.bntlegpress;
            this.bntlegpress.Size = new System.Drawing.Size(128, 48);
            this.bntlegpress.TabIndex = 29;
            this.bntlegpress.Click += new System.EventHandler(this.bntlegpress_Click);
            // 
            // formlegpress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 457);
            this.Controls.Add(this.bntlegpress);
            this.Controls.Add(this.bntbackleg);
            this.Name = "formlegpress";
            this.Opacity = 0D;
            this.Text = "formlegpress";
            this.Load += new System.EventHandler(this.formlegpress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bntbackleg;
        private System.Windows.Forms.Timer modaleffecttimer;
        private Guna.UI2.WinForms.Guna2Button bntlegpress;
    }
}