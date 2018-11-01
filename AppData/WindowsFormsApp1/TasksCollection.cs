using System;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public class TasksCollection
    {
        [XmlArray("Tasks")]
        [XmlArrayItem("Task", typeof(Task))]
        public Task[] tasks = new Task[0];
        public void AddAccount(Task task)
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
                Logger.LogMessage("Account added");

                

            }
            catch (Exception e)
            {
                Logger.LogError("Failed to add Task ::" + e);
            }
        }
    }
}