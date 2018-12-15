using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    [XmlInclude(typeof(CuncurentsSubscribing))]
    [Serializable()]
    public abstract class Task
    {
        [System.Xml.Serialization.XmlElement("account_login")]
        public string account_login;
    }

}