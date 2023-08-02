using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace C__Windows_Forms_Application
{
    public class ChatClient : ChatBase
    {
        public Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public ClientSocket clientSocket = new ClientSocket();

        public int serverPort;
        public string serverIP = "";

        // Creator Static Function
        public static ChatClient CreateInstance(int port, int serverPort, string serverIP, TextBox chatTextBox)
        {
            ChatClient? chatClient = null;
            if (port > 0 && port < 65535 && serverPort > 0 && serverPort < 65535
                && serverIP.Length > 0 && chatTextBox != null) 
            { 
                chatClient = new ChatClient();
                chatClient.port = port;
                chatClient.serverPort = serverPort;
                chatClient.serverIP = serverIP;
                chatClient.chatTextBox = chatTextBox;
                chatClient.clientSocket.socket = chatClient.socket;
            }
            return chatClient;
        }

        public void ConnectToServer()
        {
            int attempts = 0;
            while(!socket.Connected) 
            { 
                if (attempts > 5) { return; }
                try
                {
                    attempts++;
                    SetChat("Connection Attempt: " + attempts);
                    socket.Connect(serverIP, serverPort);
                }
                catch(Exception ex)
                {
                    AddToChat("Error: " + ex.Message + "\n");
                }
                AddToChat("Connected!");

                // Start the thread to receive data from the server.
                clientSocket.socket.BeginReceive(clientSocket.buffer, 0, ClientSocket.BUFFER_SIZE,
                                                SocketFlags.None, ReceiveCallback, clientSocket);
            }
        }

        // Every time data is receieved from the server, this function reads the data. 
        public void ReceiveCallback(IAsyncResult AR)
        {
            ClientSocket currentClientSocket = (ClientSocket)AR.AsyncState;

            int received;
            try
            {
                received = currentClientSocket.socket.EndReceive(AR);
            }
            catch(SocketException ex) 
            {
                AddToChat("Error: " + ex.Message);
                AddToChat("Disconnecting...");
                currentClientSocket.socket.Close();
                return;
            }

            byte[] recBuff = new byte[received];
            Array.Copy(currentClientSocket.buffer, recBuff, received);
            string text = Encoding.ASCII.GetString(recBuff);

            // The data at this point is likely a chat message. 
            // Send to chat unless it is not a chat message.
            AddToChat(text);

            // Start thread again to receive more data.
            currentClientSocket.socket.BeginReceive(currentClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE,
                                                SocketFlags.None, ReceiveCallback, currentClientSocket);

        }

        public void SendString(string text)
        {
            // Send data to the server.
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        public void Close()
        {
            socket.Close();
        }
    }
}
