using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        #region Variables  
        //variables
        public InfoManager info;
        public int account_id;

        private bool drag;
        private int mousex;
        private int mousey;

        public int firstButton, secondButton, thirdButton;
        public Button currentActive;

        public string choosedTaskForCreation;
        public Panel currentActiveWindow;

        public Button[] accountTasksSlots = new Button[10];
        #endregion
        #region Essential
        public Main()
        {
            InitializeComponent();
            
        }
        private void Main_Load(object sender, EventArgs e) //On Start
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

            currentActiveWindow = Accounts;

            accountTasksSlots[0] = TaskSlotButton1_1;
            accountTasksSlots[1] = TaskSlot2Button1_1;
            accountTasksSlots[2] = TaskSlot3Button1_1;
            accountTasksSlots[3] = TaskSlot4Button1_1;
            accountTasksSlots[4] = TaskSlot5Button1_1;
        }
        #endregion

        #region BackEnd Methods

        public void UpdateTasksEditionWindow()
        {
            var account = info.accounts_data.accounts[account_id];
            AccountName1_1.Text = account.login;
            for (int i = 0; i < account.tasks.Count; i++)
            {
                accountTasksSlots[i].Text = account.tasks[i].taskName;
            }
            TaskName1_1.Text = accountTasksSlots[0].Text;
            Logger.LogMessage(account.tasks[0].taskName);

        }
        public Account FindAccount(string account) //Going To Find Account By Name String Tasks Setup needs it
        {
            return info.accounts_data.accounts.Find(x => x.login.Contains(account));
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
        public void LogSendMessage(string message)
        {
            appConsole.Text += "  " + message + System.Environment.NewLine;
            CheckLogOutOfForm();
        }
        private void CheckLogOutOfForm()
        {
            if (appConsole.Height + 5 > Settings.Height) appConsole.Text ="LOG: ";
        }
        public void OpenTaskCreationSettings(string task)
        {
            switch (task)
            {
                case "userfollowersSubscribing":
                    CompetitorsSubscribing.BringToFront();
                    CompetitorsSubscribing.Visible = true;
                    UpdateComboBox(CompetitorsSubscribingAccountsComboBox);
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
        public void UpdateComboBox(ComboBox comboBox)
        {
            for (int i = 0; i < info.accounts_data.accounts.Count; i++)
            {
                comboBox.Items.Add(info.accounts_data.accounts[i].login);
            }
            
        }
        public string[] TurnStringIntoArray(string field)
        {
            var result = field.Split(' ');
            Logger.LogMessage(result.ToString());
            return result;
        }
        #endregion

        #region Close Hide Panel
        private void CloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HideApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #region Movable Panel Implementation
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
        #endregion
        #endregion
        #region LogIn in App Panel
        private void LogInButton_Click(object sender, EventArgs e)
        {
            LoginWindow.Visible = false;
            SoftWindow.Visible = true;
        }

        #endregion

        #region Visual Effects
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
        #endregion
        #region Right Menu
        private void Button6_Click(object sender, EventArgs e) //Log Out Button
        {
            LoginWindow.Open();
            TasksEdit.Visible = false;
            EditAccountPanel.Visible = false;
            accountLoginPass.Visible = false;
            CompetitorsSubscribing.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e) //Accounts Window Open
        {
            
            Label2.Text = "Accounts";
            Accounts.Open();
            TasksEdit.Visible = false;
            EditAccountPanel.Visible = false;
            accountLoginPass.Visible = false;
            CompetitorsSubscribing.Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e) //Tasks Window Open
        {
            
            Label2.Text = "Tasks";
            Tasks.Open();
            TasksEdit.Visible = false;
            EditAccountPanel.Visible = false;
            accountLoginPass.Visible = false;

            CompetitorsSubscribing.Visible = false;
        }

        private void Button4_Click(object sender, EventArgs e) //Stats Window Open
        {
           
            Label2.Text = "Stats";
            Stats.Open();
            TasksEdit.Visible = false;
            EditAccountPanel.Visible = false;
            accountLoginPass.Visible = false;
            CompetitorsSubscribing.Visible = false;
        }

        private void Button5_Click(object sender, EventArgs e) //Settings Window Open
        {
            
            Label2.Text = "Settings";
            Settings.Open();
            TasksEdit.Visible = false;
            EditAccountPanel.Visible = false;
            accountLoginPass.Visible = false;
            CompetitorsSubscribing.Visible = false;
        }

        #endregion

        #region Accounts Panel
        private void DeleteButton1_1_Click(object sender, EventArgs e)
        {

        }
        private void SubmitChangesAccount_Click(object sender, EventArgs e)
        {
            info.accounts_data.accounts[account_id].login = newLogin.Text;
            info.accounts_data.accounts[account_id].password = newPassword.Text;
            EditAccountPanel.Visible = false;
        }
        private void accountsTasksEditButton_Click(object sender, EventArgs e)
        {
            UpdateTasksEditionWindow();
            TasksEdit.Open();
            
        }
        private void statusPicture_MouseHover(object sender, EventArgs e)
        {
            StatusPopUp.Visible = true;
            statusInPopUp.Text = info.accounts_data.accounts[account_id].status;
        }
        private void statusPicture_MouseLeave(object sender, EventArgs e)
        {
            StatusPopUp.Visible = false;
            
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
            Accounts.Open();
            accountLoginPass.Visible = false;
        }

        private void AddAccountButton_Click(object sender, EventArgs e)
        {
            accountLoginPass.Open();
            loginTextBox1.Text = "";
            passwordTextBox.Text = "";
        }
        private void deleteAccount_Click(object sender, EventArgs e)
        {
            info.accounts_data.accounts.RemoveAt(account_id);
            Accounts.Open();
            UpdateAccountInfo(account_id);
            info.Save();
        }

        private void editAccount_Click(object sender, EventArgs e)
        {
            EditAccountPanel.Open();
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
        #endregion
        #region Tasks Panel
        #region UpperButtons
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
        #endregion

        #region SubscribingTasksMenu
        private void CompetitiorsSubscribingListButton_Click(object sender, EventArgs e)
        {
            choosedTaskForCreation = "userfollowersSubscribing";
            TaskNameInDescriptionPanel.Text = "User Followers Subscribing";
            TaskDescription.Text = "Task subscribing on followers "+ Environment.NewLine + "that follows specified accounts";
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
        #endregion   
        #region LikingTasksMenu
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
        #endregion
        #region TechnicalTasksMenu
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


        #endregion

        #region TaskWindow
        private void CreateTask_Click(object sender, EventArgs e)
        {
            OpenTaskCreationSettings(choosedTaskForCreation);
        }
       
        private void CompetitorsSubscribingButtonSubmit_Click(object sender, EventArgs e)
        {
            var account = CompetitorsSubscribingAccountsComboBox.SelectedItem.ToString();            
            CuncurentsSubscribing task = new CuncurentsSubscribing(TurnStringIntoArray(aimAccountsCompetitprsSubscription.ToString()),false,true,true,true,true,40,200,10,500,20,true);
            FindAccount(account).AddTask(task);
            CompetitorsSubscribing.Close();            
            info.Save();
        }
        #endregion
        #endregion
       
    }

}

