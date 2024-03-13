using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    delegate void SetTextDelegate(string s);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient tcpClient=null;

        //Chating Server
        ChatHandler chatHandler = new ChatHandler();

        //Server Join Button Click
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (BtnConnect.Text=="입장")
            {
                try
                {
                    //Join Server IP & Port
                    string IP=ServerIPTextBox.Text;
                    int Port = int.Parse(ServerPortTextBox.Text);

                    tcpClient = new TcpClient();
                    tcpClient.Connect(IPAddress.Parse(IP),Port);

                    chatHandler.Setup(this, tcpClient.GetStream(), this.ChatMessageTextBox);
                    Thread chatThread= new Thread(new ThreadStart(chatHandler.ChatProcess));
                    chatThread.Start(); //Thread Start

                    Message_Send("<"+NameTextBox.Text+"> 님이 접속하셨습니다.",true);
                    BtnConnect.Text = "나가기";
                }
                catch(System.Exception Ex) 
                {
                    MessageBox.Show("Server 오류 발생 또는 Start되지 않았거나\n\n"+Ex.Message,"Client");
                }
            }
            else
            {
                Message_Send("<" + NameTextBox.Text + "> 님께서 접속을 종료하셨습니다.", false);
                BtnConnect.Text = "입장";
                //Close Chatsocket
                chatHandler.ChatClose();
                tcpClient.Close();
            }
        }

        private void Message_Send(string message,Boolean Msg)
        {
            if (tcpClient.Connected)
            {
                try
                {
                    if (tcpClient.Connected)
                    {
                        //Read data and Encoding
                        string dataToSend = message + "\r\n";
                        byte[] data = Encoding.UTF8.GetBytes(dataToSend);   //UTF8로 한글 사용 가능
                        tcpClient.GetStream().Write(data, 0, data.Length);
                    }
                }
                catch (Exception Ex)
                {
                    if (Msg == true)
                    {
                        MessageBox.Show("서버가 Start되지 않았거나\n\n" + Ex.Message, "Client");
                        BtnConnect.Text = "입장";
                        chatHandler.ChatClose();
                        tcpClient.Close();
                    }
                }
            }
        }

        //Send Message Button
        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            //if in Server
            if(BtnConnect.Text=="나가기")
            {
                Message_Send("<" + NameTextBox.Text + "> " + TextMessage.Text, true);
            }
            TextMessage.Text = "";
        }

        //Delegate SetText Join UI
        public void SetText(string text)
        {
            if(this.ChatMessageTextBox.InvokeRequired)
            {
                SetTextDelegate d=new SetTextDelegate(SetText); //Delegate
                this.Invoke(d,new object[] {text});
                //Write Text in UI
            }
            else
            {
                this.ChatMessageTextBox.AppendText(text);
            }
        }
    }

    public class ChatHandler
    {
        private TextBox ChatMessageTextBox;
        private NetworkStream netStream;
        private StreamReader strReader;
        private Form1 form1;

        public void Setup(Form1 form1,NetworkStream netStream,TextBox ChatMessageBox)
        {
            this.ChatMessageTextBox = ChatMessageBox;
            this.netStream = netStream;
            this.form1 = form1;
            this.strReader = new StreamReader(netStream);

        }

        //Chat Close
        public void ChatClose() 
        { 
            netStream.Close();
            strReader.Close();
        }

        public void ChatProcess() 
        {
            while(true) 
            {
                try
                {
                    //receive Message
                    string message=strReader.ReadLine();
                    if (message!=null && message!="")
                    {
                        form1.SetText(message + "\r\n");
                    }
                }
                catch(System.Exception) { break; }
            }
        }
    }
}