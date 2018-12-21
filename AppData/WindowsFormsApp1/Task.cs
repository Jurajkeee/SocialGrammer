using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    [XmlInclude(typeof(CuncurentsSubscribing))]
    [Serializable()]
    public abstract class Task
    {
        [System.Xml.Serialization.XmlElement("task_login")]
        public string taskName;
        [System.Xml.Serialization.XmlElement("task_description")]
        public string taskDescription;
    }

}