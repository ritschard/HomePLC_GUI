using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using HomePLC.RemoteService;

namespace HomePLC.Model
{
    public class RemoteServiceHost
    {
        private bool serviceStarted = false;
        private ServiceHost remoteServiceHost = null;
        private Uri serviceBaseAddress = null;
        private string serviceHostname = "localhost";
        private int servicePort = 2202;
        
        public void Start()
        {
            serviceBaseAddress = new Uri("net.tcp://" + serviceHostname + ":" + servicePort.ToString() + "/HomePLCRemoteService");

            if (!serviceStarted)
            {
                NetTcpBinding binding = new NetTcpBinding();

                remoteServiceHost = new ServiceHost(typeof(RemoteService.Service), serviceBaseAddress);
                remoteServiceHost.AddServiceEndpoint(typeof(RemoteService.IService), binding, serviceBaseAddress);

                remoteServiceHost.Open();

                serviceStarted = true;
            }
        }

        public void Stop()
        {
            if (serviceStarted)
            {
                remoteServiceHost.Close();
                remoteServiceHost = null;
                serviceStarted = false;
            }
        }
    
        public bool IsStarted 
        { 
            get
            {
                return serviceStarted;
            } 
        }

        public string Hostname
        {
            get
            {
                return serviceHostname;
            }
            set
            {
                serviceHostname = value;
            }
        }

        public int Port
        {
            get
            {
                return servicePort;
            }
            set 
            {
                servicePort = value;
            }
        }

        public Uri HostUri
        {
            get
            {
                return serviceBaseAddress;
            }
        }

        public ServiceHost Host
        {
            get
            {
                return remoteServiceHost;
            }
        }

    }
}
