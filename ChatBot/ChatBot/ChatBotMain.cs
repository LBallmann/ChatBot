namespace ChatBot
{
    class ChatBotMain
    {
        static void Main(string[] args)
        {
            #region Startup
            Client client = new Client("irc.twitch.tv", 6667);
            client.login(Settings.Username, Settings.Password);
            client.joinRoom(Settings.Room);
            #endregion

            while (true)
            {
                string message = client.readLine();
                if (message != null)
                {
                    System.Console.WriteLine(message);
                    #region PING_check
                    if (message.Equals("PING: tmi.twitch.tv"))
                    {
                        client.sendMessage("PONG :tmi.twitch.tv");
                    }
                    #endregion

                    string actualMessage = message.Substring(message.LastIndexOf(':')+1);
                    client.processChat(actualMessage);
                }
            }
        }

    }
}
