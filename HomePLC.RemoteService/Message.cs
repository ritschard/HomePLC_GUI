using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HomePLC.RemoteService
{
    [DataContract]
    public class Message
    {
        private string pin;
        private string val;
        
        [DataMember]
        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        [DataMember]
        public string Value
        {
            get { return val; }
            set { val = value; }
        }
    }
}
