using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels;
using RemoteObjectAssembly;

namespace IPCRemotingClientSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!m_Once)
            {
                RegisterChannel();
                m_Once = true;
            }

            // オブジェクト作成
            var _msg = (RemoteObject)Activator.GetObject(typeof(RemoteObject), "ipc://RemoteObject/msg");
            
            _msg.State++;

            MessageBox.Show(_msg.State.ToString());
        }

        private void RegisterChannel()
        {
            // IPCチャネル作成
            IpcClientChannel icc = new IpcClientChannel();

            // リモートオブジェクト登録
            ChannelServices.RegisterChannel(icc, true);
        }

        private bool m_Once = false;
    }
}
