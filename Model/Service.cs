using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HomePLC.RemoteService;

namespace HomePLC.Model
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode= InstanceContextMode.Single)]
    public class Service
    {
        private Module fieldModule = null;

        public Service()
        {
            fieldModule = new Module(BoardType.Analog, 6, BoardType.Digital, 8);
            fieldModule.IpAddress = System.Net.IPAddress.Parse("192.168.1.8");
            fieldModule.Port = 1000;
        }

        public Service(Module module)
        {
            fieldModule = module;
        }

        public IList<string> GetAllData()
        {
            IList<string> result = new List<string>();

            if (fieldModule != null)
            {
                if (fieldModule.Connected)
                {
                    switch (fieldModule.InputBoard)
                    {
                        case BoardType.Analog:
                            for (int i = 0; i <= fieldModule.InputAnalogPinCount; i++)
                            {
                                result.Add(i.ToString() + " : " + fieldModule.InputAnalogPin[i].ToString());
                            }
                            break;
                        case BoardType.Digital:
                            for (int i = 0; i <= fieldModule.InputDigitalPinCount; i++)
                            {
                                result.Add(i.ToString() + " : " + fieldModule.InputDigitalPin[i].ToString());
                            }
                            break;
                    }
                }
                else
                {
                    try
                    {
                        fieldModule.Connect();
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            return result;
        }
    }
}
