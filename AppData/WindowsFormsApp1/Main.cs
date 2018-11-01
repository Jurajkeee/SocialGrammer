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
            
                account_name.Text = info.accounts_data.accounts[id].login;
                 Logger.LogMessage(account_id.ToString());
        }
        private void CloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HideApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            LoginWindow.Visible = false;
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
            ConcurentsSubscribing.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            Label2.Text = "Accounts";
            Accounts.Visible = true;
            Tasks.Visible = false;
            Stats.Visible = false;
            Settings.Visible = false;

            accountLoginPass.Visible = false;
            ConcurentsSubscribing.Visible = false;
            accountLoginPass.Visible = false;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
            Label2.Text = "Tasks";
            Accounts.Visible =false;
            Tasks.Visible = true;
            Stats.Visible = false;
            Settings.Visible = false;
            ConcurentsSubscribing.Visible = false;
            accountLoginPass.Visible = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
           
            Label2.Text = "Stats";
            Accounts.Visible = false;
            Tasks.Visible = false;
            Stats.Visible = true;
            Settings.Visible = false;
            ConcurentsSubscribing.Visible = false;
            accountLoginPass.Visible = false;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            
            Label2.Text = "Settings";
            Accounts.Visible = false;
            Tasks.Visible = false;
            Stats.Visible = false;
            Settings.Visible = true;
            ConcurentsSubscribing.Visible = false;
            accountLoginPass.Visible = false;
        }

        
        private void ConfirmAddingAccount_Click(object sender, EventArgs e)
        {
            Account account = new Account();       
            account.login = loginTextBox1.Text;
            account.password = passwordTextBox.Text;
            account.status = "logging in";
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
            SubcribingPanel.Visible = true;
            LikingPanel.Visible = false;
        }

        private void TechnicalTasksButton_Click(object sender, EventArgs e)
        {
            UpdateTasksButtons(TechnicalTasksButton);
            SubcribingPanel.Visible = false;
            LikingPanel.Visible = false;
        }

        private void LikingTasksButton_Click(object sender, EventArgs e)
        {
            UpdateTasksButtons(LikingTasksButton);
            SubcribingPanel.Visible = false;
            LikingPanel.Visible = true;
        }

        private void Likecomentstask_Click(object sender, EventArgs e)
        {

        }

        private void hashtagssubsliking_Click(object sender, EventArgs e)
        {

        }

        private void likefollowers_Click(object sender, EventArgs e)
        {

        }

        private void concurentsliking_Click(object sender, EventArgs e)
        {

        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            //CreateTask
            ConcurentsSubscribing.Visible = false;

        }

        private void createConcurentsSubscribing_Click(object sender, EventArgs e)
        {
            ConcurentsSubscribing.Visible = true;
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
                    account_id = info.accounts_data.accounts.Length-1;
                    UpdateAccountInfo(account_id);
                }

            }
            catch (Exception)
            {
                account_id = info.accounts_data.accounts.Length-1;
                UpdateAccountInfo(account_id);
                Logger.LogError("Out of borders");
            }
        }

        

        private void AccountRight_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (account_id < info.accounts_data.accounts.Length)
                {
                    UpdateAccountInfo(++account_id);                   
                }
                //else {
                //    account_id = 0;
                //    UpdateAccountInfo(0);
                //}
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

