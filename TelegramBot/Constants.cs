namespace TelegramBot
{
    internal static class Constants
    {
        internal static class Commands
        {
            public static string CommandHelp => "/help";
        }

        internal static class Answers
        {
            public static string CommandHelpAnswer => "Command list: /help, /Hello";
        }

        internal static class Error
        {
            public static string CommandNotFound => "Command not found";
        }
    }
}
