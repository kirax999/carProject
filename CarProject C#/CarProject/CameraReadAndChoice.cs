using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DirectShowLib;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace CarProject
{
    class CameraReadAndChoice
    {
        private ComboBox ListCamera;
        private PictureBox cameraViewer;
        Capture capture = null;
        public CameraReadAndChoice(ComboBox ListCameraExterne, PictureBox cameraViewerExterne) {
            this.ListCamera = ListCameraExterne;
            this.cameraViewer = cameraViewerExterne;

            DsDevice[] SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            this.ListCamera.SelectedIndexChanged += new System.EventHandler(this.ListCamera_SelectedIndexChanged);
            this.cameraViewer.Click += new System.EventHandler(this.ListCamera_Click);

            for (int i = 0; i < SystemCamereas.Length; i++)
            {
                var data = SystemCamereas[i];
                this.ListCamera.Items.Add(new objectCameraList(data.Name, i, data.ClassID));
            }
            if (this.ListCamera.Items.Count > 0)
            {
                this.ListCamera.SelectedIndex = 0;
            }
        }
        
        public void CameraCapture(int id, int widhtView, int heightView)
        {
            if (capture != null)
                capture.Stop();
            capture = new Capture(id);

            decimal ratio = System.Convert.ToDecimal(capture.Width) / System.Convert.ToDecimal(capture.Height);
            decimal sizeW = System.Convert.ToDecimal(widhtView) / ratio;

            Application.Idle += new EventHandler(delegate (object sender, EventArgs e) {
                this.cameraViewer.Image = capture.QueryFrame().ToImage<Bgr, Byte>().Resize(System.Convert.ToInt32(sizeW), (heightView), Inter.Linear).ToBitmap();
            });
        }

        class objectCameraList {
            String name;
            Guid guid;
            public bool isActive = false;
            public int id { get; }

            public objectCameraList(String name, int id, Guid guid)
            {
                this.name = name;
                this.id = id;
                this.guid = guid;
            }

            public override string ToString()
            {
                return name;
            }
        }

        private void ListCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cameraList = this.ListCamera;
            var cameraImage = this.cameraViewer;

            if (cameraList.SelectedItem == null) return;
            var b = (objectCameraList)cameraList.SelectedItem;
            if (b.isActive == false)
            {
                CameraCapture(b.id, cameraImage.Size.Width, cameraImage.Size.Height);
            }
        }

        private void ListCamera_Click(object sender, EventArgs e)
        {
            /*
            new Form();
            throw new NotImplementedException();
            */
        }
    }
}
