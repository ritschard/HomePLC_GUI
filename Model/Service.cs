using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;


namespace HomePLC.Model
{
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service 
    {
        private Module fieldModule = null;
                        
        public Service(Module module)
        {
            fieldModule = module;

            if (!fieldModule.Connected)
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

        [WebGet(UriTemplate = "")]
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
                            for (int i = 0; i < fieldModule.InputAnalogPinCount; i++)
                            {
                                result.Add(i.ToString() + " : " + fieldModule.InputAnalogPin[i].ToString());
                            }
                            break;
                        case BoardType.Digital:
                            for (int i = 0; i < fieldModule.InputDigitalPinCount; i++)
                            {
                                result.Add(i.ToString() + " : " + fieldModule.InputDigitalPin[i].ToString());
                            }
                            break;
                    }
                    switch (fieldModule.OutputBoard)
                    {
                        case BoardType.Analog:
                            for (int i = 0; i < fieldModule.OutputAnalogPinCount; i++)
                            {
                                result.Add(i.ToString() + " : " + fieldModule.OutputAnalogPin[i].ToString());
                            }
                            break;
                        case BoardType.Digital:
                            for (int i = 0; i < fieldModule.OutputDigitalPinCount; i++)
                            {
                                result.Add(i.ToString() + " : " + fieldModule.OutputDigitalPin[i].ToString());
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
        
        [WebInvoke(UriTemplate = "SetOutput/{id}/{val}", Method = "GET")]
        public bool SetOutput(string id, string val)
        {
            switch (fieldModule.OutputBoard)
            {
                case BoardType.Analog:
                    return SetAnalogOutput(id, val);

                case BoardType.Digital:
                    return SetDigitalOutput(id, val);
            }

            return false;
        }

        [WebGet(UriTemplate = "GetInput/{id}")]
        public string GetInput(string id)
        {
            int rid = int.Parse(id);

            if (fieldModule != null)
            {
                if (fieldModule.Connected)
                {
                    switch (fieldModule.InputBoard)
                    {
                        case BoardType.Analog:
                            return fieldModule.InputAnalogPin[rid].ToString();

                        case BoardType.Digital:
                            return fieldModule.InputDigitalPin[rid].ToString();
                    }
                }
            }
            return null;
        }

        [WebGet(UriTemplate = "GetOutput/{id}")]
        public string GetOutput(string id)
        {
            int rid = int.Parse(id);

            if (fieldModule != null)
            {
                if (fieldModule.Connected)
                {
                    switch (fieldModule.OutputBoard)
                    {
                        case BoardType.Analog:
                            return fieldModule.OutputAnalogPin[rid].ToString();

                        case BoardType.Digital:
                            return fieldModule.OutputDigitalPin[rid].ToString();
                    }
                }
            }
            return null;
        }

        private bool SetDigitalOutput(string id, string val)
        {
            bool result = false;

            int rid = int.Parse(id);
            bool rval = bool.Parse(val);

            if (fieldModule != null)
            {
                if (fieldModule.Connected)
                {
                    if (fieldModule.OutputBoard == BoardType.Digital)
                    {
                        fieldModule.OutputDigitalPin[rid] = rval;
                        return true;
                    }
                }
            }

            return result;
        }

        private bool SetAnalogOutput(string id, string val)
        {
            bool result = false;

            int rid;
            byte rval;
            try
            {
                rid = int.Parse(id);
                rval = byte.Parse(val);
            }
            catch (Exception)
            {
                return false;
            }

            if (fieldModule != null)
            {
                if (fieldModule.Connected)
                {
                    if (fieldModule.OutputBoard == BoardType.Analog)
                    {
                        fieldModule.OutputAnalogPin[rid] = rval;
                        return true;
                    }
                }
            }

            return result;
        }
    }
}
