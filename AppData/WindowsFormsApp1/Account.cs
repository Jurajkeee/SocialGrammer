using System;
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
        public Task[] tasks = new Task[0];
        public void AddTask(Task task)
        {

            try
            {
                Task[] finalArray = new Task[tasks.Length + 1];
                for (int i = 0; i < tasks.Length; i++)
                {
                    finalArray[i] = tasks[i];
                }
                finalArray[finalArray.Length - 1] = task;
                tasks = finalArray;
                Logger.LogMessage("Task added");



            }
            catch (Exception e)
            {
                Logger.LogError("Failed to add Task ::" + e);
            }
        }
    }
}