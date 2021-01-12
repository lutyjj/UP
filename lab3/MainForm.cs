using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class MainForm : Form
    {
        BluetoothDeviceInfo[] devices;
        BluetoothDeviceInfo connectedDevice;
        BluetoothClient client = new BluetoothClient();
        BluetoothRadio radio = BluetoothRadio.PrimaryRadio;

        public MainForm()
        {
            InitializeComponent();
            UIInit();
            cbxDevices.SelectedIndexChanged += OnDeviceChanged;
        }

        private void UIInit()
        {
            btnPair.Enabled = false;
            btnSend.Enabled = false;
            lblAdapter.Text = "Local adapter: " + radio.LocalAddress.ToString();
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            btnScan.Enabled = false;
            btnScan.Text = "Scanning...";
            cbxDevices.Enabled = false;
            await Task.Run(() => Scan());
            foreach (BluetoothDeviceInfo d in devices)
            {
                cbxDevices.Items.Add(d.DeviceName);
            }
            btnScan.Enabled = true;
            btnScan.Text = "Scan";
            cbxDevices.Enabled = true;
        }

        private void Scan()
        {
            devices = client.DiscoverDevicesInRange();
        }

        private void OnDeviceChanged(object sender, EventArgs e)
        {
            if (devices != null) {
                connectedDevice = devices[cbxDevices.SelectedIndex];
                UIChangeStatus(connectedDevice.Authenticated);
            }
        }

        private void UIChangeStatus(bool authenticated)
        {
            lblStatus.Text = authenticated ? "Status: Paired" : "Status: Unpaired";
            var mac = connectedDevice.DeviceAddress.ToString();
            mac = Regex.Replace(mac, ".{2}", "$0:");
            lblMac.Text = $"MAC: {mac.Remove(mac.Length - 1)}";
            btnPair.Enabled = !authenticated;
            btnSend.Enabled = authenticated;
        }

        private void btnPair_Click(object sender, EventArgs e)
        {
            if (connectedDevice != null)
            {
                if (!connectedDevice.Authenticated && !BluetoothSecurity.PairRequest(connectedDevice.DeviceAddress, "000000"))
                {
                    MessageBox.Show("Request failed");
                    UIChangeStatus(false);
                }
                else
                {
                    UIChangeStatus(true);
                }
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                progressBarSend.Value = 0;
                progressBarSend.Maximum = dialog.FileNames.Length;
                await Task.Run(() => ProcessFiles(dialog.FileNames));
            }
        }

        private void ProcessFiles(string[] files)
        {
            foreach (string file in files)
            {
                Send(file);
                progressBarSend.Invoke((MethodInvoker)delegate
                {
                    progressBarSend.Value++;
                });
            }
        }

        private void Send(string filePath)
        {
            txtLog.Invoke((MethodInvoker)delegate
            {
                txtLog.Text += $"Sending: {filePath}" + Environment.NewLine;
            });
            var uri = new Uri("obex://" + connectedDevice.DeviceAddress + "/" + filePath);
            var request = new ObexWebRequest(uri);
            request.ReadFile(filePath);
            var response = (ObexWebResponse)request.GetResponse();
            response.Close();

            txtLog.Invoke((MethodInvoker)delegate
            {
                txtLog.Text += $"Response: {response.StatusCode}" + Environment.NewLine;
            });
        }
    }
}
