namespace sdChat
{
    partial class FormChat
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
            this.textBox_Chat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.text_IP = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_Mensagem = new System.Windows.Forms.TextBox();
            this.button_Enviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Chat
            // 
            this.textBox_Chat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Chat.Location = new System.Drawing.Point(10, 12);
            this.textBox_Chat.Multiline = true;
            this.textBox_Chat.Name = "textBox_Chat";
            this.textBox_Chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Chat.Size = new System.Drawing.Size(762, 393);
            this.textBox_Chat.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Destino:";
            // 
            // text_IP
            // 
            this.text_IP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.text_IP.Location = new System.Drawing.Point(84, 419);
            this.text_IP.Mask = "000.000.000.000";
            this.text_IP.Name = "text_IP";
            this.text_IP.Size = new System.Drawing.Size(100, 20);
            this.text_IP.TabIndex = 2;
            this.text_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 455);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mensagem:";
            // 
            // text_Mensagem
            // 
            this.text_Mensagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Mensagem.Location = new System.Drawing.Point(84, 452);
            this.text_Mensagem.Name = "text_Mensagem";
            this.text_Mensagem.Size = new System.Drawing.Size(586, 20);
            this.text_Mensagem.TabIndex = 4;
            // 
            // button_Enviar
            // 
            this.button_Enviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Enviar.Location = new System.Drawing.Point(676, 450);
            this.button_Enviar.Name = "button_Enviar";
            this.button_Enviar.Size = new System.Drawing.Size(96, 23);
            this.button_Enviar.TabIndex = 5;
            this.button_Enviar.Text = "enviar";
            this.button_Enviar.UseVisualStyleBackColor = true;
            this.button_Enviar.Click += new System.EventHandler(this.button_Enviar_Click);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 488);
            this.Controls.Add(this.button_Enviar);
            this.Controls.Add(this.text_Mensagem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_IP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Chat);
            this.Name = "FormChat";
            this.Text = "Chat - Sistemas Distribuídos";
            this.Load += new System.EventHandler(this.FormChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Chat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox text_IP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_Mensagem;
        private System.Windows.Forms.Button button_Enviar;
    }
}

