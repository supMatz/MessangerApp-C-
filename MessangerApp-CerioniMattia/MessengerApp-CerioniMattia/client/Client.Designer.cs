﻿using System;

namespace client
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(65, 18);
            this.txtIP.Margin = new System.Windows.Forms.Padding(2);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(369, 20);
            this.txtIP.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(364, 250);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(68, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(65, 43);
            this.tbInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInfo.Size = new System.Drawing.Size(369, 170);
            this.tbInfo.TabIndex = 3;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(65, 223);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(2);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(369, 20);
            this.txtMessage.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 226);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Message:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(292, 250);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(68, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(466, 290);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP/IP Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
    }
}

