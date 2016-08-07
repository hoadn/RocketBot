#region using directives

using System;
using System.Text;
using PoGo.RocketBot.Window.Models;
using PoGo.RocketBot.Logic.Logging;
using PoGo.RocketBot.Logic.State;
using System.Drawing;

#endregion

namespace PoGo.RocketBot.Window
{
    /// <summary>
    /// The ConsoleLogger is a simple logger which writes all logs to the Console.
    /// </summary>
    internal class ConsoleLogger : ILogger
    {
        private readonly LogLevel _maxLogLevel;
        private ISession _session;

        /// <summary>
        /// To create a ConsoleLogger, we must define a maximum log level.
        /// All levels above won't be logged.
        /// </summary>
        /// <param name="maxLogLevel"></param>
        internal ConsoleLogger(LogLevel maxLogLevel)
        {
            _maxLogLevel = maxLogLevel;
        }

        public void SetSession(ISession session)
        {
            _session = session;
            LoggingStrings.SetStrings(_session);
        }

        /// <summary>
        /// Log a specific message by LogLevel. Won't log if the LogLevel is greater than the maxLogLevel set.
        /// </summary>
        /// <param name="message">The message to log. The current time will be prepended.</param>
        /// <param name="level">Optional. Default <see cref="LogLevel.Info" />.</param>
        /// <param name="color">Optional. Default is auotmatic</param>
        public void Write(string message, LogLevel level = LogLevel.Info, ConsoleColor color = ConsoleColor.Black)
        {
            // Remember to change to a font that supports your language, otherwise it'll still show as ???.
            Console.OutputEncoding = Encoding.UTF8;
            if (level > _maxLogLevel)
                return;

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (level)
            {
                case LogLevel.Error:
                    MainForm.ColoredConsoleWrite(Color.Red, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Error}) {message}");
                    break;
                case LogLevel.Warning:
                    MainForm.ColoredConsoleWrite(Color.Goldenrod, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Attention}) {message}");
                    break;
                case LogLevel.Info:
                    MainForm.ColoredConsoleWrite(Color.DarkCyan, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Info}) {message}");
                    break;
                case LogLevel.Pokestop:
                    MainForm.ColoredConsoleWrite(Color.Cyan, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Pokestop}) {message}");
                    break;
                case LogLevel.Farming:
                    MainForm.ColoredConsoleWrite(Color.Magenta, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Farming}) {message}");
                    break;
                case LogLevel.Sniper:
                    MainForm.ColoredConsoleWrite(Color.White, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Sniper}) {message}");
                    break;
                case LogLevel.Recycling:
                    MainForm.ColoredConsoleWrite(Color.DarkMagenta, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Recycling}) {message}");
                    break;
                case LogLevel.Caught:
                    MainForm.ColoredConsoleWrite(Color.Green, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Pkmn}) {message}");
                    break;
                case LogLevel.Transfer:
                    MainForm.ColoredConsoleWrite(Color.DarkGreen, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Transferred}) {message}");
                    break;
                case LogLevel.Evolve:
                    MainForm.ColoredConsoleWrite(Color.Yellow, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Evolved}) {message}");
                    break;
                case LogLevel.Berry:
                    MainForm.ColoredConsoleWrite(Color.DarkGoldenrod, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Berry}) {message}");
                    break;
                case LogLevel.Egg:
                    MainForm.ColoredConsoleWrite(Color.DarkGoldenrod, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Egg}) {message}");
                    break;
                case LogLevel.Debug:
                    MainForm.ColoredConsoleWrite(Color.Gray, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Debug}) {message}");
                    break;
                case LogLevel.Update:
                    MainForm.ColoredConsoleWrite(Color.White, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Update}) {message}");
                    break;
                case LogLevel.New:
                    MainForm.ColoredConsoleWrite(Color.Green, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.New}) {message}");
                    break;
                default:
                    MainForm.ColoredConsoleWrite(Color.White, $"[{DateTime.Now.ToString("HH:mm:ss")}] ({LoggingStrings.Error}) {message}");
                    break;
            }
        }
    }
}
