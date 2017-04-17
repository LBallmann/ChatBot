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
                if(message != null)
                {
                    System.Console.WriteLine(message);
                    if (message.Equals("PING: tmi.twitch.tv"))
                    {
                        client.sendMessage("PONG :tmi.twitch.tv");
                    }
                    message = message.ToLower();
                    if (message.Contains("!hi"))
                    {
                        client.sendMessage("Hello Hello");
                    }
                }
            }
        }

    }
}
