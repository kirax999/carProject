namespace CarProject
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
            this.ListCamera = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ListCamera
            // 
            this.ListCamera.FormattingEnabled = true;
            this.ListCamera.Location = new System.Drawing.Point(0, 0);
            this.ListCamera.Name = "ListCamera";
            this.ListCamera.Size = new System.Drawing.Size(558, 21);
            this.ListCamera.TabIndex = 0;
            this.ListCamera.SelectedIndexChanged += new System.EventHandler(this.ListCamera_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 368);
            this.Controls.Add(this.ListCamera);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ListCamera;
    }
}

