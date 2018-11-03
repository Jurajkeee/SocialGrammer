using System;
using System.IO;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    
    
    public class InfoManager
    {
        public AccountsCollection accounts_data;
        public void LoadData()
        {
            Logger.LogMessage("Loading Data");
            LoadAccountsLogins();
        }
        private void LoadAccountsLogins()
        {
            Logger.LogMessage("Loading Accounts Logins");
            accounts_data = new AccountsCollection();
            try
            {
                if (File.Exists(Environment.CurrentDirectory + "/accounts.xml"))
                {
                    DeserializeAccountsData();
                    Logger.LogMessage(accounts_data.accounts.Length.ToString());
                }
                else
                {
                    Logger.LogMessage("Account.xml doesnt exist");
                }
            }
            catch (Exception)
            {
                Logger.LogError("Failed");
            }
        }

        private void DeserializeAccountsData()
        {
            Logger.LogMessage("Deserializing XML");           
            string path = Environment.CurrentDirectory + "/accounts.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(AccountsCollection));

            StreamReader reader = new StreamReader(path);
            accounts_data = (AccountsCollection)serializer.Deserialize(reader);
            reader.Close();

        }
        private void SerializeAccountsLogins()
        {
            
            XmlSerializer serializer = new XmlSerializer(typeof(AccountsCollection));
            TextWriter writer = new StreamWriter(Environment.CurrentDirectory + "/accounts.xml");
            serializer.Serialize(writer, accounts_data);
            writer.Close();
            Logger.LogMessage("Saved");
        }
        
        public void Save()
        {
            SerializeAccountsLogins();
        }


    }
}