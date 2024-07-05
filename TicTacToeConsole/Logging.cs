using System;
using System.IO;
using System.Text;

// Logging class to record data to a .txt file
namespace TicTacToeConsole
{
    public class Logging
    {

        private StringBuilder logBuffer;
        private string basePath = Directory.GetCurrentDirectory().Split(new string[] { "\\bin" }, StringSplitOptions.None)[0];

        public Logging()
        {
            logBuffer = new StringBuilder();
            logBuffer.Clear();
        }

        public void Log(string message)
        {
            logBuffer.Append(DateTime.Now + " - " + message).AppendLine();
            File.AppendAllText(basePath + "\\log.txt", logBuffer.ToString());
            logBuffer.Clear();
        }

        public void Clear()
        {
            logBuffer.Clear(); 
        }
    }
}
