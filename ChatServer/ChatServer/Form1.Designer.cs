namespace ChatServer
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
            this.ServerTextBox = new System.Windows.Forms.TextBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.ServerState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Location = new System.Drawing.Point(26, 12);
            this.ServerTextBox.Multiline = true;
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.ReadOnly = true;
            this.ServerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ServerTextBox.Size = new System.Drawing.Size(322, 365);
            this.ServerTextBox.TabIndex = 0;
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(218, 393);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(130, 45);
            this.BtnStart.TabIndex = 1;
            this.BtnStart.Text = "서버 시작";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // ServerState
            // 
            this.ServerState.AutoSize = true;
            this.ServerState.Font = new System.Drawing.Font("굴림", 15F);
            this.ServerState.Location = new System.Drawing.Point(37, 402);
            this.ServerState.Name = "ServerState";
            this.ServerState.Size = new System.Drawing.Size(138, 20);
            this.ServerState.TabIndex = 2;
            this.ServerState.Tag = "Stop";
            this.ServerState.Text = "Server 중지 됨";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 450);
            this.Controls.Add(this.ServerState);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.ServerTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerTextBox;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label ServerState;
    }
}

