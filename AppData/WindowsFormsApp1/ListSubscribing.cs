namespace WindowsFormsApp1
{

    public class ListSubscribing : Task
    {
        public int i = 300;
        [System.Xml.Serialization.XmlElement("task_name_Test")]
        private string taskNameLocal = "23123";
        [System.Xml.Serialization.XmlElement("task_description_Test")]
        private string taskDescriptionLocal = "Hello MF2";
    }
}