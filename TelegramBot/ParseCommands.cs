using System.Collections.Generic;

namespace TelegramBot
{
    internal class ParseCommands
    {
        private static Dictionary<string,string> commands = new Dictionary<string, string>();

        static ParseCommands() =>
            commands.Add(Constants.Commands.CommandHelp, Constants.Answers.CommandHelpAnswer);

        public static string Parse(string message) => 
            commands.ContainsKey(message) ? commands[message] : Constants.Error.CommandNotFound;

    }
}
