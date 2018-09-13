using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    internal class ParseCommands
    {
        public static string Parse(string command)
        {
            string[] commands = new string[] { "/help", "/command1" };
            string[] answers = new string[] { "Список команд: /help", "Hello" };

            for (int i = 0; i < commands.Length; ++i)
                if (command.Contains(commands[i]))
                    return answers[i];

            return "Команда не распознана";
        }
    }
}
