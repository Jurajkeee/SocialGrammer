using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
        [Serializable]
       public class Account
       {
            [System.Xml.Serialization.XmlElement("login")]
            public string login;
            [System.Xml.Serialization.XmlElement("password")]
            public string password;
            [System.Xml.Serialization.XmlElement("status")]
            public string status;
            [XmlArray("Tasks")]
            [XmlArrayItem("Task", typeof(Task))]
            public List<Task> tasks = new List<Task> { };
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }
        public void DeleteTask(Task task)
        {
            tasks.Remove(task);
        }
       }
}