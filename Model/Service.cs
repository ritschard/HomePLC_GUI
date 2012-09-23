using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NLog;


namespace HomePLC.Model
{
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
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
            logger.Debug("SERVICE CALL --------------------------");

            if (fieldModule != null)
            {
                if (fieldModule.Connected)
                {
                    switch (fieldModule.InputBoard)
                    {
                        case BoardType.Analog:
                            for (int i = 0; i < fieldModule.InputAnalogPinCount; i++)
                            {
                                result.Add(fieldModule.InputAnalogPin[i].ToString());
                            }
                            break;
                        case BoardType.Digital:
                            for (int i = 0; i < fieldModule.InputDigitalPinCount; i++)
                            {
                                result.Add(fieldModule.InputDigitalPin[i].ToString());
                            }
                            break;
                    }
                    switch (fieldModule.OutputBoard)
                    {
                        case BoardType.Analog:
                            for (int i = 0; i < fieldModule.OutputAnalogPinCount; i++)
                            {
                                result.Add(fieldModule.OutputAnalogPin[i].ToString());
                            }
                            break;
                        case BoardType.Digital:
                            for (int i = 0; i < fieldModule.OutputDigitalPinCount; i++)
                            {
                                result.Add(fieldModule.OutputDigitalPin[i].ToString());
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
                
        [WebGet(UriTemplate = "GetInput/{id}", ResponseFormat = WebMessageFormat.Json)]
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

        [WebGet(UriTemplate = "GetAnalogInputs", ResponseFormat = WebMessageFormat.Json)]
        public List<string> GetAnalogInputs()
        {
            List<string> list = new List<string>();

            if (fieldModule != null)
            {
                if (fieldModule.Connected)
                {
                    if (fieldModule.InputBoard == BoardType.Analog)
                    {
                        for (int i = 0; i < fieldModule.InputAnalogPinCount; i++)
                        {
                            list.Add(fieldModule.InputAnalogPin[i].ToString());
                        }
                    }
                }
            }

            return list;
        }

        [WebGet(UriTemplate = "GetDigitalOutputs", ResponseFormat = WebMessageFormat.Json)]
        public List<string> GetDigitalOutputs()
        {
            List<string> list = new List<string>();

            if (fieldModule != null)
            {
                if (fieldModule.Connected)
                {
                    if (fieldModule.OutputBoard == BoardType.Digital)
                    {
                        for (int i = 0; i < fieldModule.OutputDigitalPinCount; i++)
                        {
                            list.Add(fieldModule.OutputDigitalPin[i].ToString());
                        } 
                    }
                }
            }

            return list;
        }

        [WebInvoke(UriTemplate = "SetDigitalOutput/{id}/{val}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        private bool SetDigitalOutput(string id, string val)
        {
            bool result = false;
            int rid = int.Parse(id);
            bool rval = bool.Parse(val);

            logger.Debug("SERVICE CALL --------------------------");

            if (fieldModule != null)
            {
                if (fieldModule.Connected)
                {
                    if (fieldModule.OutputBoard == BoardType.Digital)
                    {
                        fieldModule.OutputDigitalPin[rid] = rval;
                        return rval;
                    }
                }
            }

            return result;
        }

        [WebGet(UriTemplate = "GetAnalogOutputs", ResponseFormat = WebMessageFormat.Json)]
        public List<string> GetAnalogOutputs()
        {
            List<string> list = new List<string>();

            if (fieldModule != null)
            {
                if (fieldModule.Connected)
                {
                    if (fieldModule.OutputBoard == BoardType.Analog)
                    {
                        for (int i = 0; i < fieldModule.OutputAnalogPinCount; i++)
                        {
                            list.Add(fieldModule.OutputAnalogPin[i].ToString());
                        }
                    }
                }
            }

            return list;
        }

        [WebInvoke(UriTemplate = "SetAnalogOutput/{id}/{val}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
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

            logger.Debug("SERVICE CALL --------------------------");

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



        [WebGet(UriTemplate = "GetLog", ResponseFormat = WebMessageFormat.Json)]
        public List<string> GetLog()
        {
            List<string> result = new List<string>();

            string logDirectory = Application.StartupPath + "\\logs\\";
            string todaysLogfile = logDirectory + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

            if (Directory.Exists(logDirectory))
            {
                if (File.Exists(todaysLogfile))
                    result.AddRange(File.ReadAllLines(todaysLogfile).ToList<string>());
            }

            return result;
        }
    }
}
