using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sidi.HandsFree;

using System.Threading;
using InTheHand.Net.Sockets;
using System.Runtime.InteropServices;

namespace CarProject {

    class bluetoothServices {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void start_bluetooth()
        {
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
            d.Dial("1", devices[/*choiceDevice - 1*/0].DeviceName).Wait(); /* Apply parameter */
            Thread.Sleep(TimeSpan.FromSeconds(30));
        }

        public class Device {
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

