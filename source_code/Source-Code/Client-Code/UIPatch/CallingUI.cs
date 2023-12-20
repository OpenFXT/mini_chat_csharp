using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Code.UIPatch
{
    public partial class CallingUI : Form
    {
        public CallingUI()
        {
            InitializeComponent();
        }

        public Socket callSocket;
        public string thisIp;
        public string guestIp;
        public string name;
        public int port;
        public bool closed = false;

        public bool calling = true;

        private void CallingUI_Load(object sender, EventArgs e)
        {
            lbl_Title.Text = "Calling with " + name + "...";
            Thread voice = new Thread(() =>
            {
                var waveIn = new WaveInEvent();
                waveIn.WaveFormat = new WaveFormat(44100, 1);
                waveIn.DataAvailable += (sender, args) =>
                {
                    try { callSocket.SendTo(args.Buffer, SocketFlags.None, new IPEndPoint(IPAddress.Parse(guestIp), port)); }
                    catch
                    {
                        if (!closed)
                        {
                            this.Invoke(() =>
                            {
                                this.Close();
                            });
                        }
                    }
                };
                waveIn.StartRecording();
                while (calling) { }
                try { callSocket.SendTo(new Byte[] { }, new IPEndPoint(IPAddress.Parse(guestIp), port)); }
                catch
                {
                    if (!closed)
                    {
                        this.Invoke(() =>
                        {
                            this.Close();
                        });
                    }
                }
                waveIn.StopRecording();
            });
            voice.Start();
            Thread hear = new Thread(() =>
            {
                var waveOut = new WaveOutEvent();
                var waveFormat = new WaveFormat(44100, 16, 1);
                var waveProvider = new BufferedWaveProvider(waveFormat);
                waveOut.Init(waveProvider);

                while (true)
                {
                    EndPoint clientEp = new IPEndPoint(IPAddress.Any, port);
                    byte[] buffer = new byte[10000];
                    int data = 0;
                    try { data = callSocket.ReceiveFrom(buffer, SocketFlags.None, ref clientEp); } catch {
                        if (data == 0 && !closed)
                        {
                            this.Invoke(() =>
                            {
                                this.Close();
                            });
                            break;
                        }
                    }

                    waveProvider.AddSamples(buffer, 0, data);
                    waveOut.Play();

                    if (data == 0 && !closed)
                    {
                        this.Invoke(() =>
                        {
                            this.Close();
                        });
                        break;
                    }
                }
            });
            hear.Start();
        }

        private void btn_Destroy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CallingUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            closed = true;
            callSocket.Close();
            Thread.Sleep(2000);
            calling = false;
            AudioFileReader reader = new AudioFileReader(@"./App-Data/notice.mp3");
            WaveOut player = new WaveOut();
            player.Init(reader);
            player.Play();
        }
    }
}
