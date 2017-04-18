using System;
using System.Collections.Generic;
using System.IO;

namespace ChatBot
{
    class CommandHandler
    {
        internal static IDictionary<string, string> readCommands()
        {
            IDictionary<string, string> commands = new Dictionary<string, string>();
            try
            {
                StreamReader input = new StreamReader("Commands.dat");
                do
                {
                    string line = input.ReadLine();
                    string[] split = line.Split(':');
                    commands.Add(split[0], split[1]);
                } while (input.Peek() != -1);
                input.Close();
            }
            catch(Exception e)
            {
                //I'll log this one day I promise
                Console.Write(e.Message);
            }
            return commands;
        }

        internal static void writeCommands(Dictionary<string, string> commands)
        {
            try
            {
                StreamWriter output = new StreamWriter("Commands.dat",false);
                foreach(string key in commands.Keys)
                {
                    output.WriteLine(key + ":" + commands[key]);
                    output.Flush();
                }
                output.Close();
            }
            catch(Exception e)
            {
                //I'll log this one day I promise
                Console.Write(e.Message);
            }
        }
    }
}
