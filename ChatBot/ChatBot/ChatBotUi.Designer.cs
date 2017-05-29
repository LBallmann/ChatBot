namespace ChatBot
{
    partial class ChatBotUi
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
            this.Followers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Followers
            // 
            this.Followers.AutoSize = true;
            this.Followers.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Followers.Location = new System.Drawing.Point(13, 13);
            this.Followers.Name = "Followers";
            this.Followers.Size = new System.Drawing.Size(0, 19);
            this.Followers.TabIndex = 0;
            // 
            // ChatBotUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 457);
            this.Controls.Add(this.Followers);
            this.Name = "ChatBotUi";
            this.Text = "ChatBotUi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Followers;
    }
}