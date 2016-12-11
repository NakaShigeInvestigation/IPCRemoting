using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoteObjectAssembly
{
    public class RemoteObject : MarshalByRefObject
    {
        private int m_State = 0;
        public int State
        {
            get { return m_State; }
            set
            {
                m_State = value;
            }
        }

        public override object InitializeLifetimeService()
        {
            return null; // 無限！！
        }
    }
}
