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
            this.cameraViewer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cameraViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // ListCamera
            // 
            this.ListCamera.FormattingEnabled = true;
            this.ListCamera.Location = new System.Drawing.Point(0, 222);
            this.ListCamera.Name = "ListCamera";
            this.ListCamera.Size = new System.Drawing.Size(400, 21);
            this.ListCamera.TabIndex = 0;
            this.ListCamera.SelectedIndexChanged += new System.EventHandler(this.ListCamera_SelectedIndexChanged);
            // 
            // cameraViewer
            // 
            this.cameraViewer.Location = new System.Drawing.Point(0, 0);
            this.cameraViewer.MinimumSize = new System.Drawing.Size(400, 216);
            this.cameraViewer.Name = "cameraViewer";
            this.cameraViewer.Size = new System.Drawing.Size(400, 216);
            this.cameraViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.cameraViewer.TabIndex = 1;
            this.cameraViewer.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.cameraViewer);
            this.Controls.Add(this.ListCamera);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cameraViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ListCamera;
        private System.Windows.Forms.PictureBox cameraViewer;
    }
}

