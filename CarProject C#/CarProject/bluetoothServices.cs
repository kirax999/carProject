using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sidi.HandsFree;

using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CarProject {

    class bluetoothServices {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private SimpleDialer dialer = null;

        public void start_bluetooth()
        {
            //
            // Bluetooth discover
            //
            log4net.Config.BasicConfigurator.Configure();
            List<Device> devices = new List<Device>();
            InTheHand.Net.Sockets.BluetoothClient bc = new InTheHand.Net.Sockets.BluetoothClient();
            InTheHand.Net.Sockets.BluetoothDeviceInfo[] array = bc.DiscoverDevices();
            int count = array.Length;
            for (int i = 0; i < count; i++)
            {
                Device device = new Device(array[i]);
                devices.Add(device);
                Debug.Write("" + (i + 1) + ": " + device.ToString() + "\n");
            }

            // ***************************** //

            var d = new SimpleDialer();

            System.Threading.Thread myThread;
            myThread = new Thread(new ThreadStart(async () => await tryCommandAsync(d)));
            myThread.Start();
            Console.WriteLine("-*-*-*-*-" + devices[0].DeviceName + "-*-*-*-*-");
            d.Dial("Alexandre's iPhone" /*devices[0].DeviceName*/).Wait();
            // ***************************** //
        }

        private void followData() {

        }

        async Task<int> tryCommandAsync(Sidi.HandsFree.SimpleDialer d) {
            var slc = d.getServiceBase();

            while (slc == null) {
                slc = d.getServiceBase();
            }

            int i = 0;
            for (; ; )
            {
                switch (i)
                {
                    case 1:
                        Console.Write(slc.Battery);
                        break;
                    case 2:
                        await slc.Dial("+33689426948");
                        break;
                    case 3:
                        await slc.CallHangUp();
                        break;
                    default:
                        ;
                        break;
                }
                i = 0;
            }

            /*
            using (slc)
            {
                Debug.WriteLine(await slc.GetManufacturerIdentification());
                Debug.WriteLine(await slc.GetModelIdentification());
                Debug.WriteLine(await slc.GetSerialNumberIdentification());
                Debug.WriteLine(await slc.GetNetworkOperator());
                Debug.WriteLine(await slc.GetSubscriberNumber());
                Debug.WriteLine(slc.IsService);
                Debug.WriteLine(slc.IsCall);
                Debug.WriteLine(slc.CallSetup);
                Debug.WriteLine(slc.CallHeld);
                Debug.WriteLine(slc.Signal);
                Debug.WriteLine(slc.Battery);


                await slc.Dial("+33689426948");

                await slc.CallHangUp();
            }
            */
            return 0;
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

