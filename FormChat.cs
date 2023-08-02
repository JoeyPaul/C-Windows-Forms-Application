using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__Windows_Forms_Application
{
    public partial class FormChat : Form
    {
        ChatServer server = null;
        ChatClient client = null;
        public FormChat()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.SendString(TypeTextBox.Text);
            }
            else if (server != null)
            {
                server.SendToAll(TypeTextBox.Text, null);
            }
        }
    }
}
