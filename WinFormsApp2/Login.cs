using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace WinFormsApp2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            String accountJson = File.ReadAllText(jsonLocation);
            if (accountJson != "")
                accountList = JsonConvert.DeserializeObject<List<Account>>(accountJson);
            //.DeserializeObjecta<List<Account>>(accountJson);
        }
        public string jsonLocation = ("Accounts.json");
        public RegState regEnum = RegState.None;
        public string nickname = "";
        public string password = "";
        List<Account> accountList = new List<Account>();
        public void EnableLayout()
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            ConfirmButton.Visible = true;
            label1.Text = "";
            label2.Visible = true;
            label3.Visible = true;
            RegisterButton.Visible = false;
            LoginButton.Visible = false;
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            ConfirmButton.Text = "Login";
            EnableLayout();
            regEnum = RegState.Login;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            ConfirmButton.Text = "Register";
            EnableLayout();
            regEnum = RegState.Register;


        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            switch (regEnum)
            {
                case RegState.Login:
                    foreach (Account account in accountList)
                    {
                        if (account.name.ToLower() == textBox1.Text.ToLower() && account.password == textBox2.Text)
                        {
                            password = account.password;
                            nickname = account.name;
                            Form1 calc = new Form1(nickname);
                            this.Hide();
                            calc.ShowDialog();
                            this.Close();
                            break;
                        }

                    }
                    label1.Text = "Incorrect information.";
                    break;



                case RegState.Register:
                    short i = 0;

                    foreach (Account account in accountList)
                    {
                        i++;
                        if (account.name == textBox1.Text)
                        {
                            label1.Text = "Nickname already used!";
                            break;
                        }
                    }
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        accountList.Add(new Account(textBox1.Text, textBox2.Text, i));
                        string jsonSerialize = JsonConvert.SerializeObject(accountList, Newtonsoft.Json.Formatting.Indented);
                        File.WriteAllText(jsonLocation, jsonSerialize);
                        label1.Text = "Registration successful, now you can log in.";
                        ConfirmButton.Text = "Login";
                        regEnum = RegState.Login;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        break;
                    }
                    label1.Text = "You did not fill some of the input fields.";
                    break;
            }
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfirmButton.Text = "Register";
            EnableLayout();
            regEnum = RegState.Register;

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfirmButton.Text = "Login";
            EnableLayout();
            regEnum = RegState.Login;
        }
    }
    public class Account
    {
        public Account (string Name, string Password, short Id)
        {
            name = Name;
            password = Password;
            id = Id;

        }
        public short id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }
    public enum  RegState
    {
None, Register, Login        
    }
}
