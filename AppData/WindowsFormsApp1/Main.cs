using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        public  InfoManager info;
        public int account_id;

        public Main()
        {
            InitializeComponent();
            
        }

        private bool drag;
        private int mousex;
        private int mousey;

        public int firstButton, secondButton, thirdButton;
        public Button currentActive;
        

        private void Main_Load(object sender, EventArgs e)
        {
            info = new InfoManager();
            info.LoadData();
            UpdateAccountInfo(0);
            accountLoginPass.Visible = false;

            firstButton = LikingTasksButton.Location.X;
            secondButton = TechnicalTasksButton.Location.X;
            thirdButton = subscribingTasksButton.Location.X;
            
            Logger.LogMessage(firstButton.ToString() +"::"+ secondButton.ToString() + "::"+ thirdButton.ToString());
            UpdateTasksButtons(LikingTasksButton);
        }
        public void UpdateTasksButtons(Button active)
        {
            Point p = active.Location;
            active.Location = new Point(firstButton, active.Location.Y);
            if(currentActive == LikingTasksButton)
            {
                LikingTasksButton.Location = p;
            }
            else if(currentActive == TechnicalTasksButton)
            {
                TechnicalTasksButton.Location = p;
            }
            else if(currentActive == subscribingTasksButton)
            {
                subscribingTasksButton.Location = p;
            }
            currentActive = active;
        }
        public void UpdateAccountInfo(int id)
        {
            try
            {
                account_name.Text = info.accounts_data.accounts[id].login;
                ChangeStatus(info.accounts_data.accounts[id].status);
                Logger.LogMessage(account_id.ToString());
            }
            catch (Exception)
            {
                Logger.LogError("Accounts not found");
            }
        }
        public void ChangeStatus(string status)
        {
            switch (status)
            {
                case "not-active":
                    statusPicture.BackgroundImage = WindowsFormsApp1.Properties.Resources.Ellipse_2;
                    break;
                case "active":
                    statusPicture.BackgroundImage = WindowsFormsApp1.Properties.Resources.working;
                    break;
                case "error":
                    statusPicture.BackgroundImage = WindowsFormsApp1.Properties.Resources.error;
                    break;
            }
        }
        public void ChangeStatus(string status, string message)
        {
            switch (status)
            {
                case "not-active": break;
                case "active": break;
                case "error": break;
            }
            //Set Message Code
        }
        private void CloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HideApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void LogInButton_Click(object sender, EventArgs e)
        {
            LoginWindow.Visible = false;
            SoftWindow.Visible = true;
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mousey;
                this.Left = Cursor.Position.X - mousex;
            }
        }

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mousex = Cursor.Position.X - this.Left;
            mousey = Cursor.Position.Y - this.Top;
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            AccountsButton.Text = "              accounts";
            PictureBox1.Size = new Size(38, 33);
            
        }

        private void Button3_MouseHover(object sender, EventArgs e)
        {
            TasksButton.Text = "      tasks";
            PictureBox2.Size = new Size(38, 33);
        }

        private void Button4_MouseHover(object sender, EventArgs e)
        {
            StatsButton.Text = "     stats";
            PictureBox8.Size = new Size(38, 33);
        }

        private void Button5_MouseHover(object sender, EventArgs e)
        {
            SettingsButton.Text = "           settings";
            PictureBox9.Size = new Size(38, 33);
        }

        private void Button4_MouseLeave(object sender, EventArgs e)
        {
            StatsButton.Text = "   stats";
            PictureBox8.Size = new Size(29, 33);
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            AccountsButton.Text = "            accounts";
            PictureBox1.Size = new Size(29, 33);
        }

        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            TasksButton.Text = "    tasks";
            PictureBox2.Size = new Size(29, 33);
        }

        private void Button5_MouseLeave(object sender, EventArgs e)
        {
            SettingsButton.Text = "          settings";
            PictureBox9.Size = new Size(29, 33);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            LoginWindow.Visible = true;

            SoftWindow.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            Label2.Text = "Accounts";
            Accounts.Visible = true;
            Tasks.Visible = false;
            Stats.Visible = false;
            Settings.Visible = false;

            accountLoginPass.Visible = false;
            CompetitorsSubscribing.Visible = false;
            accountLoginPass.Visible = false;
            EditAccountPanel.Visible = false;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
            Label2.Text = "Tasks";
            Accounts.Visible =false;
            Tasks.Visible = true;
            Stats.Visible = false;
            Settings.Visible = false;
            CompetitorsSubscribing.Visible = false;
            accountLoginPass.Visible = false;
            EditAccountPanel.Visible = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
           
            Label2.Text = "Stats";
            Accounts.Visible = false;
            Tasks.Visible = false;
            Stats.Visible = true;
            Settings.Visible = false;
            CompetitorsSubscribing.Visible = false;
            accountLoginPass.Visible = false;
            EditAccountPanel.Visible = false;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            
            Label2.Text = "Settings";
            Accounts.Visible = false;
            Tasks.Visible = false;
            Stats.Visible = false;
            Settings.Visible = true;
            CompetitorsSubscribing.Visible = false;
            accountLoginPass.Visible = false;
            EditAccountPanel.Visible = false;
        }

        
        private void ConfirmAddingAccount_Click(object sender, EventArgs e)
        {
            Account account = new Account();       
            account.login = loginTextBox1.Text;
            account.password = passwordTextBox.Text;
            account.status = "not-active";
            LogSendMessage(account.login);
            LogSendMessage(account.password);
            info.accounts_data.AddAccount(account);
            info.Save();
            UpdateAccountInfo(account_id);
            accountLoginPass.Visible = false;
            

        }

        private void AddAccountButton_Click(object sender, EventArgs e)
        {
            accountLoginPass.Visible = true;
            accountLoginPass.BringToFront();
            loginTextBox1.Text = "";
            passwordTextBox.Text = "";
        }

        public void LogWriteClick()
        {
            StackTrace stackTrace = new StackTrace();            
            appConsole.Text += stackTrace.GetFrame(1).GetMethod().Name + System.Environment.NewLine;
            CheckLogOutOfForm();
        }
        public void LogSendMessage(string message)
        {
            appConsole.Text += "  " + message + System.Environment.NewLine;
            CheckLogOutOfForm();
        }
        private void CheckLogOutOfForm()
        {
            if (appConsole.Height + 5 > Settings.Height) appConsole.Text ="LOG: ";
        }

        private void subscribingTasksButton_Click(object sender, EventArgs e)
        {
            UpdateTasksButtons(subscribingTasksButton);
            SubscribingTasks.Visible = true;
            LikingTasks.Visible = false;
            TechnicalTasks.Visible = false;
        }

        private void TechnicalTasksButton_Click(object sender, EventArgs e)
        {
            UpdateTasksButtons(TechnicalTasksButton);
            SubscribingTasks.Visible = false;
            LikingTasks.Visible = false;
            TechnicalTasks.Visible = true;
        }

        private void LikingTasksButton_Click(object sender, EventArgs e)
        {
            UpdateTasksButtons(LikingTasksButton);
            SubscribingTasks.Visible = false;
            LikingTasks.Visible = true;
            TechnicalTasks.Visible = false;
        }

 

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            //CreateTask
            CompetitorsSubscribing.Visible = false;
            
        }

       

        

        private void CompetitiorsSubscribingListButton_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "userfollowersSubscribing";
            TaskNameInDescriptionPanel.Text = "User Followers Subscribing";
            TaskDescription.Text = "Task subscribing on followers "+ Environment.NewLine + "that follows specified accounts";
        }
        
     

        private void CreateTask_Click(object sender, EventArgs e)
        {
            OpenTaskCreationSettings(choosedTaskForCreation);
        }
        public string choosedTaskForCreation;
         public void OpenTaskCreationSettings(string task)
        {
            switch (task)
            {
                case "userfollowersSubscribing":
                    CompetitorsSubscribing.BringToFront();
                    CompetitorsSubscribing.Visible = true;
                    Logger.LogMessage("Competitors Subscribing Task");
                    break;
                case "geolocationSubscribing":
                    Logger.LogError("Not Implemented");
                    break;
                case "hashtagSubscribing":
                    Logger.LogError("Not Implemented");
                    break;
                case "listSubscribing":
                    Logger.LogError("Not Implemented");
                    break;
            }
            
        }
        private void GeoSubscribingButton_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "geolocationSubscribing";
            TaskNameInDescriptionPanel.Text = "GeoLoaction Subscribing";
            TaskDescription.Text = "Task subscribing on users " + Environment.NewLine + "that were found in specified geolocation";
        }
        private void HashtagSubscribingButton_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "";
            TaskNameInDescriptionPanel.Text = "Hashtag Followers";
            TaskDescription.Text = "Task subscribing on users" + Environment.NewLine + "that follows specified hashtags";
        }
        private void ListSubscribingButton_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "geolocationSubscribing";
            TaskNameInDescriptionPanel.Text = "List Subscribing";
            TaskDescription.Text = "Task subscribing on users " + Environment.NewLine + "in list";
        }
        //Liking Tasks
        private void GeoLocationLiking_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "";
            TaskNameInDescriptionPanel.Text = "GeoLoaction Liking";
            TaskDescription.Text = "Task liking users " + Environment.NewLine + "that were found in specified geolocation";
        }

        private void UserSubscribersLiking_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "";
            TaskNameInDescriptionPanel.Text = "User Subscribers Liking";
            TaskDescription.Text = "Task liking users " + Environment.NewLine + "that follows specified accounts";
        }

        private void HashtagLiking_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "";
            TaskNameInDescriptionPanel.Text = "Hashtag Followers Liking";
            TaskDescription.Text = "Task liking users " + Environment.NewLine + "that follows specified hashtags";
        }

        private void ListLiking_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "";
            TaskNameInDescriptionPanel.Text = "List Liking";
            TaskDescription.Text = "Task liking users " + Environment.NewLine + "in specified list";
        }

        private void FollowersLiking_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "";
            TaskNameInDescriptionPanel.Text = "Followers Liking";
            TaskDescription.Text = "Task liking " + Environment.NewLine + "your followers";
        }

        private void CommentsLiking_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "";
            TaskNameInDescriptionPanel.Text = "Comments Liking";
            TaskDescription.Text = "Task liking users " + Environment.NewLine + "comments in specified accounts";
        }
        //Technical
        private void NonFollowersUnsubscribingButton_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "";
            TaskNameInDescriptionPanel.Text = "Non Followers";
            TaskDescription.Text = "Task unsubscribes from users " + Environment.NewLine + "that haven't followed you back";
        }

        private void UnfollowFollowingButton_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "";
            TaskNameInDescriptionPanel.Text = "Following Unsubsribing";
            TaskDescription.Text = "Task unsubscribes from all users " + Environment.NewLine + "that you're following";
        }

        private void SubmitChangesAccount_Click(object sender, EventArgs e)
        {
            info.accounts_data.accounts[account_id].login = newLogin.Text;
            info.accounts_data.accounts[account_id].password = newPassword.Text;
            EditAccountPanel.Visible = false;

        }

        private void deleteAccount_Click(object sender, EventArgs e)
        {
            info.accounts_data.accounts.RemoveAt(account_id);
            EditAccountPanel.Visible = false;
            UpdateAccountInfo(account_id);
            info.Save();
        }

        private void editAccount_Click(object sender, EventArgs e)
        {
            EditAccountPanel.BringToFront();
            EditAccountPanel.Visible = true;
            UpdateAccountInfo(account_id);
            info.Save();
        }

        private void AccountLeft_Click(object sender, EventArgs e)
        {
            Logger.LogMessage(account_id.ToString());
            try
            {
                if (account_id > 0)
                {
                    UpdateAccountInfo(--account_id);
                }
                else {
                    account_id = info.accounts_data.accounts.Count-1;
                    UpdateAccountInfo(account_id);
                }

            }
            catch (Exception)
            {
                account_id = info.accounts_data.accounts.Count-1;
                UpdateAccountInfo(account_id);
                Logger.LogError("Out of borders");
            }
        }

        

        private void AccountRight_Click(object sender, EventArgs e)
        {          
            try
            {
                if (account_id < info.accounts_data.accounts.Count)
                {
                    UpdateAccountInfo(++account_id);                   
                }
                else
                {
                    account_id = 0;
                    UpdateAccountInfo(account_id);
                }
            }
            catch (Exception)
            {
                account_id = 0;
                UpdateAccountInfo(account_id);
                Logger.LogError("Out of borders");
            }

        }
    }

}

