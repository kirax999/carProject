using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DirectShowLib;

namespace CarProject
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();

            DsDevice[] SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            for (int i = 0; i < SystemCamereas.Length; i++) {
                var data = SystemCamereas[i];
                this.ListCamera.Items.Add(new objectCameraList(data.Name, i, data.ClassID));
            }
            if (this.ListCamera.Items.Count > 0) {
                this.ListCamera.SelectedIndex = 0;
            }
        }

        private void ListCamera_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.ListCamera.SelectedItem == null) return;
            var b = (objectCameraList)this.ListCamera.SelectedItem;
        }

        class objectCameraList
        {
            String name;
            Guid guid;
            int id;

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
    }
}
