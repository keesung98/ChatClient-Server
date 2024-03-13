namespace ChatClient
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServerIP = new System.Windows.Forms.Label();
            this.ServerIPTextBox = new System.Windows.Forms.TextBox();
            this.ServerPort = new System.Windows.Forms.Label();
            this.ServerPortTextBox = new System.Windows.Forms.TextBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.ChatMessageTextBox = new System.Windows.Forms.TextBox();
            this.TextMessage = new System.Windows.Forms.TextBox();
            this.BtnSendMessage = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ServerIP
            // 
            this.ServerIP.AutoSize = true;
            this.ServerIP.Location = new System.Drawing.Point(20, 17);
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(16, 12);
            this.ServerIP.TabIndex = 0;
            this.ServerIP.Text = "IP";
            // 
            // ServerIPTextBox
            // 
            this.ServerIPTextBox.Location = new System.Drawing.Point(42, 14);
            this.ServerIPTextBox.Name = "ServerIPTextBox";
            this.ServerIPTextBox.Size = new System.Drawing.Size(100, 21);
            this.ServerIPTextBox.TabIndex = 1;
            // 
            // ServerPort
            // 
            this.ServerPort.AutoSize = true;
            this.ServerPort.Location = new System.Drawing.Point(9, 42);
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(27, 12);
            this.ServerPort.TabIndex = 2;
            this.ServerPort.Text = "Port";
            // 
            // ServerPortTextBox
            // 
            this.ServerPortTextBox.Location = new System.Drawing.Point(42, 39);
            this.ServerPortTextBox.Name = "ServerPortTextBox";
            this.ServerPortTextBox.Size = new System.Drawing.Size(100, 21);
            this.ServerPortTextBox.TabIndex = 3;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(305, 12);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(110, 48);
            this.BtnConnect.TabIndex = 4;
            this.BtnConnect.Text = "입장";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // ChatMessageTextBox
            // 
            this.ChatMessageTextBox.Location = new System.Drawing.Point(22, 70);
            this.ChatMessageTextBox.Multiline = true;
            this.ChatMessageTextBox.Name = "ChatMessageTextBox";
            this.ChatMessageTextBox.ReadOnly = true;
            this.ChatMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatMessageTextBox.Size = new System.Drawing.Size(393, 246);
            this.ChatMessageTextBox.TabIndex = 5;
            // 
            // TextMessage
            // 
            this.TextMessage.Location = new System.Drawing.Point(22, 335);
            this.TextMessage.Name = "TextMessage";
            this.TextMessage.Size = new System.Drawing.Size(314, 21);
            this.TextMessage.TabIndex = 6;
            // 
            // BtnSendMessage
            // 
            this.BtnSendMessage.Location = new System.Drawing.Point(342, 333);
            this.BtnSendMessage.Name = "BtnSendMessage";
            this.BtnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.BtnSendMessage.TabIndex = 7;
            this.BtnSendMessage.Text = "전송";
            this.BtnSendMessage.UseVisualStyleBackColor = true;
            this.BtnSendMessage.Click += new System.EventHandler(this.BtnSendMessage_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(150, 30);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(39, 12);
            this.NameLabel.TabIndex = 8;
            this.NameLabel.Text = "Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(195, 27);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 21);
            this.NameTextBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 383);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.BtnSendMessage);
            this.Controls.Add(this.TextMessage);
            this.Controls.Add(this.ChatMessageTextBox);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.ServerPortTextBox);
            this.Controls.Add(this.ServerPort);
            this.Controls.Add(this.ServerIPTextBox);
            this.Controls.Add(this.ServerIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServerIP;
        private System.Windows.Forms.TextBox ServerIPTextBox;
        private System.Windows.Forms.Label ServerPort;
        private System.Windows.Forms.TextBox ServerPortTextBox;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox ChatMessageTextBox;
        private System.Windows.Forms.TextBox TextMessage;
        private System.Windows.Forms.Button BtnSendMessage;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
    }
}

