using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
/*
Carl Haricombe 30019812
You have been hired as the new programmer by the Jupiter Mining Corporation to produce a test
program for the company, this program will be fully documented and tested.
With this project you are coming up with a program to show your range of skills and abilities to
your new boss.
You have been given an example of what your boss is expecting to see
the example they have given is an advanced music player that allows the ability to sort and search
the songs stored in a binary tree (any sort and search algorithm you select will have to be
approved if it is not merge sort and binary search), the GUI should display the sorted track list and
highlight and play the searched track, it should save the track list to a csv using a 3rd party library.
The music player must load and play files and met the requirements laid out in Question 3.
If you choose not to implement this proje
*/

namespace Server
{
    class Program
    {
        private static byte[] _buff = new byte[1024];
        private static List<Socket> clientSocket = new List<Socket>();
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            Console.Title = "Server end";
            SetupServer();
            Console.ReadLine();
        }

        //setting up the server for the client to access
        private static void SetupServer()
        {
            Console.WriteLine("Server is being setup.... ");
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            serverSocket.Listen(1);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);

        }

        //Method to receive and validate username
        private static bool VerifiedUserNames(string username)
        {
            bool validUser = false;
            string[] lines = System.IO.File.ReadAllLines(@"C:\Carl C# tafe\Client\Server\Users.txt");
            foreach (string line in lines)
            {
                //accesses the first value before the comma
                if (line.Split(',')[0] == username)
                {
                    validUser = true;
                    break;
                }
            }
            return validUser;
        }

        //Method to receive passwords from the textfile
        private static bool VerifiedPasswords(string password)
        {
            bool validPassword = false;
            string[] lines = System.IO.File.ReadAllLines(@"C:\Carl C# tafe\Client\Server\Users.txt");
            foreach (string line in lines)
            {
                //accesses the first value before the comma
                string hash1 = ComputeSha256Hash(password);
                string hash2 = ComputeSha256Hash(line.Split(',')[1]);
                
                if (hash1.Equals(hash2))
                {
                    //displaying the hash code
                    Console.WriteLine($"Hash 1 : {hash1}");
                    Console.WriteLine($"Hash 2 : {hash2}");
                    validPassword = true;
                    break;
                }
            }
            return validPassword;
        }

        //allows client access if username and password is correct
        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = serverSocket.EndAccept(AR);
            clientSocket.Add(socket);
            Console.WriteLine("Client has Connected");
            socket.BeginReceive(_buff, 0, _buff.Length, SocketFlags.None, new AsyncCallback(ReceiveUsername), socket);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);

            socket.BeginReceive(_buff, 0, _buff.Length, SocketFlags.None, new AsyncCallback(ReceivePassword), socket);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        //receiving the username that the client enters and comparing to textfile
        private static void ReceiveUsername(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);
            byte[] dataBuff = new byte[received];
            Array.Copy(_buff, dataBuff, received);

            string text = Encoding.ASCII.GetString(dataBuff);
            Console.WriteLine("Username received as " + text);
            //sends a response to enter usename and password to access
            string response = string.Empty;
            if (VerifiedUserNames(text))
            {
                if (text.ToLower() == text)
                {
                    response = "Enter a password";
                }
            }
            else
            {
                response = "Invalid username entered";
            }


            byte[] data = Encoding.ASCII.GetBytes(response);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendResponse), socket);
        }
        //receiving the password that the client enters and comparing to textfile
        private static void ReceivePassword(IAsyncResult AR)
        {
            //sends a response to enter usename and password to access
            string response = string.Empty;
            Socket socket1 = (Socket)AR.AsyncState;
            int received = socket1.EndReceive(AR);
            byte[] dataBuff = new byte[received];
            Array.Copy(_buff, dataBuff, received);
            string text = Encoding.ASCII.GetString(dataBuff);

            string password = Encoding.ASCII.GetString(dataBuff);
            Console.WriteLine("Password received as " + password);
            if (VerifiedPasswords(password))
            {
                response = "Passed";
            }
            else
            {
                response = "Failed";
            }

            byte[] data = Encoding.ASCII.GetBytes(response);
            socket1.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendResponse), socket1);
        }
        //once accessed the server sends the client a response
        private static void SendResponse(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }
        //setting up a hashing code for the password
        private static string ComputeSha256Hash(string rawData)
        {
            // Creating a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array for what the password is 
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string to display
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
