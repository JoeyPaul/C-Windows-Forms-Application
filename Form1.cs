namespace C__Windows_Forms_Application
{
    public partial class Form1 : Form
    {
        ChatServer server = null;
        ChatClient client = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void HostButton_Click(object sender, EventArgs e)
        {
            if (CanHostOrJoin())
            {
                try
                {
                    int port = int.Parse(MyPortTextBox.Text);
                    server = ChatServer.CreateInstance(port, ChatTextBox);
                    if (server == null ) 
                    {
                        throw new Exception("Incorrect Port Value!"); // Exits try block
                    }
                    server.SetupServer();
                }
                catch(Exception ex)
                {
                    ChatTextBox.Text += "Error: " + ex.Message + "\n";
                }
            }
        }

        private void JoinServerButton_Click(object sender, EventArgs e)
        {
            if (CanHostOrJoin())
            {
                try
                {
                    int port = int.Parse(MyPortTextBox.Text);
                    int serverPort = int.Parse(ServerPortTextBox.Text);
                    client = ChatClient.CreateInstance(port, serverPort, ServerIPTextBox.Text,
                        ChatTextBox);
                    if (client == null)
                    {
                        throw new Exception("Incorrect Port Value!");
                    }
                    client.ConnectToServer();
                }
                catch (Exception ex) 
                {
                    ChatTextBox.Text += "Error: " + ex.Message + "\n";
                }
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (client != null) 
            {
                client.SendString(TypeTextBox.Text);
            }
            else if (server!=null) 
            {
                server.SendToAll(TypeTextBox.Text, null);
            }
        }

        public bool CanHostOrJoin()
        {
            if (server == null && client == null)
                return true;
            else return false; // Has already become a client or a server.
        }
    }
}