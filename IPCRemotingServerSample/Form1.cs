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
using System.Runtime.Remoting;

namespace IPCRemotingServerSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // プロセス通信用サーバ構築
            // チャネルクラス作成
            IpcServerChannel isc = new IpcServerChannel("RemoteObject");

            // リモートオブジェクト登録
            ChannelServices.RegisterChannel(isc, true);

            // メッセージを受け取ったら実行する関数を登録する
            //_msg._onMsg += new processListShare.CallEventHandler(onMsg);
            RemotingServices.Marshal(m_Object, "msg", typeof(RemoteObject));
        }

        RemoteObject m_Object = new RemoteObject();

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(m_Object.State.ToString());
        }
    }
}
