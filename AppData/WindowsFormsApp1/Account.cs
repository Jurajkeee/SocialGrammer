using System;

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
    }
}