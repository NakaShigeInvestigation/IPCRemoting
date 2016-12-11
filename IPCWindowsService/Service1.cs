using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using RemoteObjectAssembly;

namespace IPCWindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // プロセス通信用サーバ構築
            // チャネルクラス作成
            IpcServerChannel isc = new IpcServerChannel("RemoteObject");

            // リモートオブジェクト登録
            ChannelServices.RegisterChannel(isc, true);

            //// イベント登録
            RemoteObject _msg = new RemoteObject();

            // メッセージを受け取ったら実行する関数を登録する
            //_msg._onMsg += new processListShare.CallEventHandler(onMsg);
            RemotingServices.Marshal(_msg, "msg", typeof(RemoteObject));
        }

        protected override void OnStop()
        {
        }
    }
}
