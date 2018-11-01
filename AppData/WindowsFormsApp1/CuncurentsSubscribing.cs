using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public class CuncurentsSubscribing : Task
    {
        [XmlArray("Aim Accounts")]
        [XmlArrayItem("Account", typeof(string))]
        public string[] aim_accounts;
        [System.Xml.Serialization.XmlElement("Subscribe On private Accounts")]
        public bool subscribe_on_private_accounts;
        [System.Xml.Serialization.XmlElement("Dont subscribe on accounts without bio")]
        public bool dont_subscribe_on_accounts_without_bio;
        [System.Xml.Serialization.XmlElement("Use FIlters")]
        public bool filters;
        [System.Xml.Serialization.XmlElement("HaveAnAvatar")]
        public bool have_an_avatar;
        [System.Xml.Serialization.XmlElement("Have More Than Ten Publications")]
        public bool have_more_ten_publications;
        [System.Xml.Serialization.XmlElement("Min Followers")]
        public int min_followers;
        [System.Xml.Serialization.XmlElement("Max Followers")]
        public int max_followers;
        [System.Xml.Serialization.XmlElement("Min Followed")]
        public int min_followed;
        [System.Xml.Serialization.XmlElement("Max Followed")]
        public int max_followed;
        [System.Xml.Serialization.XmlElement("Delay Between Actions")]
        public int delay_between_actions;
        [System.Xml.Serialization.XmlElement("Smart Mode")]
        public bool smart_mode;

        public CuncurentsSubscribing(string account_login,string[] aim_accounts, bool subscribe_on_private_accounts,
        bool dont_subscribe_on_accounts_without_bio, bool filters, bool have_an_avatar, bool have_more_ten_publications,
        int min_followers, int max_followers, int min_followed, int max_followed, int delay_between_actions, bool smart_mode)
        {
            this.account_login = account_login;
            this.aim_accounts = aim_accounts;
            this.subscribe_on_private_accounts = subscribe_on_private_accounts;
            this.dont_subscribe_on_accounts_without_bio = dont_subscribe_on_accounts_without_bio;
            this.filters = filters;
            this.have_an_avatar = have_an_avatar;
            this.have_more_ten_publications = have_more_ten_publications;
            this.min_followers = min_followers;
            this.max_followers = max_followers;
            this.min_followed = min_followed;
            this.max_followed = max_followed;
            this.delay_between_actions = delay_between_actions;
            this.smart_mode = smart_mode;

        }

    }
}