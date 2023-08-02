namespace C__Windows_Forms_Application
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
            label1 = new Label();
            ChatTextBox = new TextBox();
            label2 = new Label();
            TypeTextBox = new TextBox();
            SendButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft New Tai Lue", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(106, 47);
            label1.TabIndex = 0;
            label1.Text = "Chat ";
            // 
            // ChatTextBox
            // 
            ChatTextBox.Location = new Point(19, 66);
            ChatTextBox.Multiline = true;
            ChatTextBox.Name = "ChatTextBox";
            ChatTextBox.ScrollBars = ScrollBars.Vertical;
            ChatTextBox.Size = new Size(485, 280);
            ChatTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 355);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 2;
            label2.Text = "Chat";
            // 
            // TypeTextBox
            // 
            TypeTextBox.Location = new Point(50, 352);
            TypeTextBox.Name = "TypeTextBox";
            TypeTextBox.Size = new Size(366, 23);
            TypeTextBox.TabIndex = 3;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(422, 352);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(75, 23);
            SendButton.TabIndex = 4;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // FormChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 398);
            Controls.Add(SendButton);
            Controls.Add(TypeTextBox);
            Controls.Add(label2);
            Controls.Add(ChatTextBox);
            Controls.Add(label1);
            Name = "FormChat";
            Text = "FormChat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ChatTextBox;
        private Label label2;
        private TextBox TypeTextBox;
        private Button SendButton;
    }
}