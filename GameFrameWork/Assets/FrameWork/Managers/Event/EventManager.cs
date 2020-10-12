using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    public class EventManager : ManagerBase, IDisposable
    {
        public SocketEvent SocketEvent
        {
            get; private set;
        }

        public CommonEvent CommonEvent
        {
            get; private set;
        }

        public EventManager()
        {
            SocketEvent = new SocketEvent();
            CommonEvent = new CommonEvent();
        }

        public void Dispose()
        {
            SocketEvent.Dispose();
            CommonEvent.Dispose();
        }
    }
}
