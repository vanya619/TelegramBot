using SimpleJSON;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading;

namespace TelegramBot
{
    class Program
    {
        private static string token = @"672506975:AAEjfREtf-tmIRGFj-RqSzvzdcSlU-D1qVo";
        private static int lastUpdate = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                GetUpdates();
                Thread.Sleep(1000);
            }
        }

        private static void GetUpdates()
        {
            using (var wbClient = new WebClient())
            {
                string response = wbClient.DownloadString("https://api.telegram.org/bot" + token + "/getUpdates?offset=" + (lastUpdate + 1).ToString());

                var messageArray = JSON.Parse(response);

                foreach (JSONNode message in messageArray["result"].AsArray)
                {
                    lastUpdate = message["update_id"].AsInt;

                    Console.WriteLine("Сообщение от пользователя с ID: {0} получено", message["message"]["from"]["id"].ToString());

                    string msg = ParseCommands.Parse(message["message"]["text"].ToString());

                    SendMessage(msg, message["message"]["chat"]["id"].AsInt); //"Я получил твое сообщение"
                }
            }
        }

        private static void SendMessage(string message, int chatID)
        {
            using (var wbClient = new WebClient())
            {
                var p = new NameValueCollection();

                p.Add("text", message);
                p.Add("chat_id", chatID.ToString());

                wbClient.UploadValues("https://api.telegram.org/bot" + token + "/sendMessage", p);
            }
        }
    }
}


