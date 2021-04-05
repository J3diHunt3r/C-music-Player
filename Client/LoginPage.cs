using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class LoginPage : Form
    {
        private static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public LoginPage()
        {
            InitializeComponent();
        }

        //manages 2 different sections otherwise it runs username again when just wanting to access the password
        bool usernameSection = true;
        bool passwordSection = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (passwordSection == true)
            {
                Connect();
                string passwordResponse = PasswordLogin(PasswordTB.Text);
                if (passwordResponse.Equals("Passed"))
                {
                    //moving client to the music player
                    MessageBox.Show("Open Media file");
                    MediaPlayer mp = new MediaPlayer();
                    mp.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Invalid password");
                }
            }

            if (usernameSection == true)
            {
                Connect();
                string userResponse = UsernameLogin(UsernameTB.Text);

                if (userResponse.Equals("Enter a password"))
                {
                    PasswordTB.Visible = true;
                    PasswordLB.Visible = true;
                    // changing the button name from Continue to Login
                    LoginBtn.Text = "Login";
                    passwordSection = true;
                    usernameSection = false;
                }
                else
                {
                    MessageBox.Show("Invalid username");
                }
            }
        }
        //username login to continue to password login
        private static string UsernameLogin(string username)
        {
            // Entering username
            byte[] buffer = Encoding.ASCII.GetBytes(username);
            clientSocket.Send(buffer);

            //receiving response for username
            byte[] recBuffer = new byte[1024];
            int rec = clientSocket.Receive(recBuffer);
            byte[] data = new byte[rec];
            Array.Copy(recBuffer, data, rec);
            //MessageBox.Show("Response from server: " + Encoding.ASCII.GetString(data));
            return Encoding.ASCII.GetString(data);
        }

        //password to login and access music player
        private static string PasswordLogin(string password)
        {
            // Entering password
            byte[] buffer = Encoding.ASCII.GetBytes(password);
            clientSocket.Send(buffer);

            //receiving response for password
            byte[] recBuffer = new byte[1024];
            int rec = clientSocket.Receive(recBuffer);
            byte[] data = new byte[rec];
            Array.Copy(recBuffer, data, rec);
            //MessageBox.Show("Response from server: " + Encoding.ASCII.GetString(data));
            return Encoding.ASCII.GetString(data);
        }

        //Client has to insert a username and the receive a password from the server end that the client then has to insert in order to gain access to send and receive messages
        private static void Connect()
        {
            int attempts = 0;

            while (!clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    clientSocket.Connect(IPAddress.Loopback, 100);

                }
                catch (SocketException)
                {
                    MessageBox.Show("Connection attempt" + attempts.ToString());
                }

            }
            //MessageBox.Show("Connection Successful");
        }
    }
}
