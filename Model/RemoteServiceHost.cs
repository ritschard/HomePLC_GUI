using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel;

namespace HomePLC.Model
{
    public class RemoteServiceHost
    {
        private bool serviceStarted = false;
        private WebServiceHost remoteServiceHost = null;
        private Uri serviceBaseAddress = null;
        private string serviceHostname = "localhost";
        private int servicePort = 2202;

        private Module module = null;

        public RemoteServiceHost()
        {
            
        }

        public RemoteServiceHost(Module mdl)
        {
            module = mdl;
        }

        public void Start()
        {
            serviceBaseAddress = new Uri("http://" + serviceHostname + ":" + servicePort.ToString() + "/HomePLCRemoteService");

            if (!serviceStarted)
            {
                Service serv = new Service(module);
                remoteServiceHost = new WebServiceHost(serv, serviceBaseAddress);
                

                ServiceEndpoint restSEP = remoteServiceHost.AddServiceEndpoint(typeof(Service), new WebHttpBinding(), serviceBaseAddress);
                restSEP.Behaviors.Add(new WebHttpBehavior() { AutomaticFormatSelectionEnabled = true, HelpEnabled = true });
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

        public Module Module 
        {
            get 
            {
                return module;
            }
            set
            {
                module = value;
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

        public WebServiceHost Host
        {
            get
            {
                return remoteServiceHost;
            }
        }

    }
}
