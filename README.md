# ChatClient-Server
C#.Net을 사용하여 Client와 Server를 활용한 Tcp/IP 채팅 프로그램을 만들었습니다.

![TestCase](https://github.com/keesung98/ChatClient-Server/assets/70887592/acd4f4f8-1f52-4e8c-912a-1d11267e955a)

---

## Server

```cpp
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
```
Thread를 생성하고 작동시킵니다.
Thread가 작동할 시 AcceptClient를 작동시켜 접속하는 Client를 기다립니다.

---

```cpp
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
```
AcceptClient에서는 While문을 돌며 Client가 접속하길 기다립니다.
Client가 접속 시 Client의 Thread와 Server의 Thread를 연결하며 Chat_Process 동작을 수행하게 됩니다.

---

```cpp
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
```

Chat_Process에서는 메시지를 입력받고 출력하게 됩니다. 
입력받은 메시지를 UTF8로 Encoding시켜 데이터에 저장하고 저장된 데이터를 채팅창에 띄우게 됩니다.

---

## Client

Client도 Server와 마찬가지로 동작하게 됩니다.
