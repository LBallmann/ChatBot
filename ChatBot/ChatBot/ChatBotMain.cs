namespace ChatBot
{
    class ChatBotMain
    {
        static void Main(string[] args)
        {
            Client client = new Client("irc.twitch.tv", 6667);
            client.login(Settings.Username, Settings.Password);
            client.joinRoom(Settings.Room);
            while (true)
            {
                string message = client.readLine();
                if (message.Contains("Hi"))
                {
                    client.sendMessage("Hello Hello");
                }
            }
        }

    }
}
