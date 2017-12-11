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
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

using Sidi.HandsFree;
using System.Threading;
using InTheHand.Net.Sockets;

namespace CarProject
{
    public partial class Form1 : Form
    {
        Capture capture = null;
        int currentRead;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1() {
            InitializeComponent();
            
            //start_bluetooth();

            /*
             * Load Camera mod
             */

            DsDevice[] SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            for (int i = 0; i < SystemCamereas.Length; i++) {
                var data = SystemCamereas[i];
                this.ListCamera.Items.Add(new objectCameraList(data.Name, i, data.ClassID));
            }
            if (this.ListCamera.Items.Count > 0) {
                this.ListCamera.SelectedIndex = 0;
            }
        }

        private int start_bluetooth() {
            /*
             * Bluetooth discover
             */
            List<Device> devices = new List<Device>();
            InTheHand.Net.Sockets.BluetoothClient bc = new InTheHand.Net.Sockets.BluetoothClient();
            InTheHand.Net.Sockets.BluetoothDeviceInfo[] array = bc.DiscoverDevices();
            int count = array.Length;
            for (int i = 0; i < count; i++)
            {
                Device device = new Device(array[i]);
                devices.Add(device);
                Console.Write("" + (i + 1) + ": " + device.ToString() + "\n");
            }
            Console.Write("Please enter the device numbers\n");
            var choiceDevice = Convert.ToInt32(Console.ReadLine());

            /* ***************************** */

            var d = new SimpleDialer();
            d.Dial("1", devices[choiceDevice - 1].DeviceName).Wait(); /* Apply parameter */
            Thread.Sleep(TimeSpan.FromSeconds(30));
            return 0;
        }

        private void ListCamera_SelectedIndexChanged(object sender, EventArgs e) {
            var cameraList = this.ListCamera;
            var cameraImage = this.cameraViewer;

            if (cameraList.SelectedItem == null) return;
            var b = (objectCameraList)cameraList.SelectedItem;
            if (b.isActive == false) {
                CameraCapture(b.id, cameraImage.Size.Width, cameraImage.Size.Height);
            }
        }

        public void CameraCapture(int id, int widhtView, int heightView)
        {
            if (capture != null)
                capture.Stop();
            capture = new Capture(id);
            Application.Idle += new EventHandler(delegate (object sender, EventArgs e) {
                this.cameraViewer.Image = capture.QueryFrame().ToImage<Bgr, Byte>().Resize(widhtView, heightView, Inter.Linear).ToBitmap();
            });
        }

        class objectCameraList
        {
            String name;
            Guid guid;
            public bool isActive = false;
            public int id { get; }

            public objectCameraList(String name, int id, Guid guid) {
                this.name = name;
                this.id = id;
                this.guid = guid;
            }

            public override string ToString() {
                return name;
            }
        }

        public class Device
        {
            public string DeviceName { get; set; }
            public bool Authenticated { get; set; }
            public bool Connected { get; set; }
            public ushort Nap { get; set; }
            public uint Sap { get; set; }
            public DateTime LastSeen { get; set; }
            public DateTime LastUsed { get; set; }
            public bool Remembered { get; set; }

            public Device(InTheHand.Net.Sockets.BluetoothDeviceInfo device_info)
            {
                this.Authenticated = device_info.Authenticated;
                this.Connected = device_info.Connected;
                this.DeviceName = device_info.DeviceName;
                this.LastSeen = device_info.LastSeen;
                this.LastUsed = device_info.LastUsed;
                this.Nap = device_info.DeviceAddress.Nap;
                this.Sap = device_info.DeviceAddress.Sap;
                this.Remembered = device_info.Remembered;
            }

            public override string ToString()
            {
                return this.DeviceName;
            }
        }
    }
}
