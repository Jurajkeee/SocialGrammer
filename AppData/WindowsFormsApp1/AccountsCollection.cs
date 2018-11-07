using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{

        [Serializable]
        [System.Xml.Serialization.XmlRoot("AccountsBase")]
        public class AccountsCollection
        {
            [XmlArray("Accounts")]
            [XmlArrayItem("Account", typeof(Account))]
            public List<Account> accounts = new List<Account> { };
            public void AddAccount(Account account)
            {
            accounts.Add(account);
            }
        public void RemoveAccount(Account account)
        {
            accounts.Remove(account);
        }
    }
}