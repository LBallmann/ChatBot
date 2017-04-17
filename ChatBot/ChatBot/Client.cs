using System.IO;
using System.Net.Sockets;

namespace ChatBot
{
    /// <summary>
    /// This class holds the TCP Client for connecting to twitch chat
    /// </summary>
    class Client
    {
        #region private_vars
        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outputStream;
        private string username;
        private string password;
        private string channel;
        #endregion

        /// <summary>
        /// This constructs the client and initializes the ip and port that we connect to.
        /// </summary>
        /// <param name="ip">The ip that we connect to</param>
        /// <param name="port">the port that we use to connect</param>
        internal Client(string ip, int port)
        {
            tcpClient = new TcpClient(ip, port);
            inputStream = new StreamReader(tcpClient.GetStream());
            outputStream = new StreamWriter(tcpClient.GetStream());
        }

        /// <summary>
        /// This logs in to the server at twitch
        /// </summary>
        /// <param name="uName">user name that is used to log in</param>
        /// <param name="pWord">password that is used to login</param>
        internal void login(string uName, string pWord)
        {
            username = uName;
            password = pWord;
            outputStream.WriteLine("PASS " + password);
            outputStream.WriteLine("NICK " + username);
            outputStream.WriteLine("USER " + username + " 8 * :" + username);
            outputStream.Flush();
        }

        /// <summary>
        /// This joins a specific room so that the chatbot can like chat
        /// </summary>
        /// <param name="room">the name of the room you want to join</param>
        internal void joinRoom(string room)
        {
            channel = room;
            outputStream.WriteLine("JOIN #" + channel);
            outputStream.Flush();
            bool joined = false;
            while (!joined)
            {
                string message = readLine(); //End of /Names list
                joined = message.Contains("End of /NAMES list");
            }
        }

        /// <summary>
        /// This sends a message to the room that you are currently connected to
        /// </summary>
        /// <param name="message">the message you would like to send to chat</param>
        internal void sendMessage(string message)
        {
            string temp = ":" + username + "!" + username + "@" + username + ".tmi.twitch.tv PRIVMSG #"
                + channel + " :" + message;
            outputStream.WriteLine(temp);
            outputStream.Flush();
        }

        /// <summary>
        /// This method reads chat
        /// </summary>
        /// <returns>the return is a single line read from chat</returns>
        internal string readLine()
        {
            return inputStream.ReadLine();
        }

        /// <summary>
        /// This method will process the messages that come in and start doing the appropriate action
        /// </summary>
        /// <param name="message">The incoming message</param>
        internal void processChat(string message)
        {
            if (message.Contains("!hi"))
            {
                sendMessage("Hello Hello");
            }
            else if (message.Contains("!echo"))
            {
                sendMessage(message.Substring("!echo ".Length));
            }
        }
    }
}
