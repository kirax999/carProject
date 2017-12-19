using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sidi.HandsFree;

using System.Threading;
using InTheHand.Net.Sockets;
using System.Runtime.InteropServices;

namespace CarProject
{
    public partial class Form1 : Form
    {
        
        public Form1() {
            InitializeComponent();

            var carBlue = new bluetoothServices();

            System.Threading.Thread blueThread = new Thread(new ThreadStart(() => carBlue.start_bluetooth()));
            blueThread.Start();
            new CameraReadAndChoice(this.ListCamera, this.cameraViewer);
        }
    }
}
