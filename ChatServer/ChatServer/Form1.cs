using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    delegate void SetTextDelegate(string s);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //IP & Port numbers
        TcpListener chatServer = new TcpListener(IPAddress.Parse("1.123.000.000"), 5555);//Input IP & Port
        public static ArrayList clientSocketArray = new ArrayList();

        //BtnServer Start/Stop
        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //Server Start
                if (ServerState.Tag.ToString() == "Stop")
                {
                    chatServer.Start();
                    Thread waitThread = new Thread(new ThreadStart(AcceptClient)); // Wait Client 
                    waitThread.Start(); // Thread Start

                    ServerState.Text = "서버 시작 됨";
                    ServerState.Tag = "Start";
                    BtnStart.Text = "서버 종료";
                }
                else
                {//Server End
                    chatServer.Stop();
                    foreach (Socket socket in Form1.clientSocketArray)
                    {
                        socket.Close();// All Socket Close
                    }
                    clientSocketArray.Clear();

                    ServerState.Text = "서버 중지 됨";
                    ServerState.Tag = "Stop";
                    BtnStart.Text = "서버 시작";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("서버를 시작할 수 없습니다. :" + ex.Message);
            }
        }

        private void AcceptClient()
        {
            Socket socketClient = null;
            while (true)
            {
                try
                {
                    socketClient = chatServer.AcceptSocket(); // Accept client

                    ClientHandler clientHandler = new ClientHandler();
                    clientHandler.ClientHandler_Setup(this, socketClient, this.ServerTextBox);
                    Thread thd_ChatProcess = new Thread(new ThreadStart(clientHandler.Chat_Process)); // 각각의 클라이언트를 대응하는 스레드
                    thd_ChatProcess.Start();
                }
                catch (System.Exception)
                {
                    Form1.clientSocketArray.Remove(socketClient);
                    break;
                }
            }
        }

        // Write Text in ServerTextBox
        public void SetText(string text)
        {
            if (this.ServerTextBox.InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetText); // Delegate
                this.Invoke(d, new object[] { text }); 
                // Call SetText() in UI
            }
            else
            {
                this.ServerTextBox.AppendText(text); // Write ServerTextBox
            }
        }
        //Form Closed
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            chatServer.Stop();
        }

        public class ClientHandler
        {
            private TextBox txtChatMsg;
            private Socket socketClient;
            private NetworkStream netStream;
            private StreamReader strReader;
            private Form1 form1;

            public void ClientHandler_Setup(Form1 form1, Socket socketClient, TextBox ServerTextBox)
            {
                this.txtChatMsg = ServerTextBox;
                this.socketClient = socketClient; 
                this.netStream = new NetworkStream(socketClient);
                Form1.clientSocketArray.Add(socketClient); // Add socket to Array
                this.strReader = new StreamReader(netStream);
                this.form1 = form1;
            }

            public void Chat_Process()
            {
                while (true)
                {
                    try
                    {
                        // receive String
                        string lstMessage = strReader.ReadLine();
                        if (lstMessage != null && lstMessage != "")
                        {
                            form1.SetText(lstMessage + "\r\n");
                            byte[] byteSend_Data = Encoding.UTF8.GetBytes(lstMessage + "\r\n"); //UTF8로 한글 사용 가능
                            lock (Form1.clientSocketArray)
                            {
                                foreach (Socket socket in Form1.clientSocketArray)
                                {
                                    if (socketClient.Connected)
                                    {
                                        NetworkStream stream = new NetworkStream(socket);
                                        stream.Write(byteSend_Data, 0, byteSend_Data.Length);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Form1.clientSocketArray.Remove(socketClient);
                        break;
                    }
                    
                }
            }
        }
    }
}