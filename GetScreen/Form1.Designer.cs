namespace GetScreen
{
    partial class Form1
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
            this.btn_FullScreen = new System.Windows.Forms.Button();
            this.btn_PrintScreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_FullScreen
            // 
            this.btn_FullScreen.Location = new System.Drawing.Point(12, 12);
            this.btn_FullScreen.Name = "btn_FullScreen";
            this.btn_FullScreen.Size = new System.Drawing.Size(87, 23);
            this.btn_FullScreen.TabIndex = 4;
            this.btn_FullScreen.Text = "Full Screen";
            this.btn_FullScreen.UseVisualStyleBackColor = true;
            this.btn_FullScreen.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_PrintScreen
            // 
            this.btn_PrintScreen.Location = new System.Drawing.Point(12, 41);
            this.btn_PrintScreen.Name = "btn_PrintScreen";
            this.btn_PrintScreen.Size = new System.Drawing.Size(87, 23);
            this.btn_PrintScreen.TabIndex = 5;
            this.btn_PrintScreen.Text = "Print Screen";
            this.btn_PrintScreen.UseVisualStyleBackColor = true;
            this.btn_PrintScreen.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(116, 87);
            this.Controls.Add(this.btn_PrintScreen);
            this.Controls.Add(this.btn_FullScreen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_FullScreen;
        private System.Windows.Forms.Button btn_PrintScreen;
    }
}

