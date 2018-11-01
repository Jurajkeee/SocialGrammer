using System;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("AccountsBase")]
    public class AccountsCollection
    {
        [XmlArray("Accounts")]
        [XmlArrayItem("Account", typeof(Account))]
        public Account[] accounts = new Account[0];
        public void AddAccount(Account account)
        {

            try
            {
                Account[] finalArray = new Account[accounts.Length + 1];
                for (int i = 0; i < accounts.Length; i++ ) {
                    finalArray[i] = accounts[i];
                }
                finalArray[finalArray.Length - 1] = account;
                accounts = finalArray;
                Logger.LogMessage("Account added");
                
                for(int i=0; i<accounts.Length; i++)
                {
                    Logger.LogMessage(accounts[i].login);
                }

            }
            catch (Exception e)
            {
                Logger.LogError("Failed to add Account ::" + e);
            }
        }
    }
}