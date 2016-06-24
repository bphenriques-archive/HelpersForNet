using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using System;
using System.IO;

namespace LoggerUtil {
    public static class Logger {
        public static string LogFolder = Path.Combine(new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).LocalPath, "Logs");

        public static Level CurrentLogLevel {
            get {
                return _logger.Logger.Repository.Threshold;
            }
            set {
                _logger.Logger.Repository.Threshold = value;
                ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
            }
        }

        private static readonly ILog _logger = LogManager.GetLogger(typeof(Logger));

        static Logger() {
            XmlConfigurator.Configure();
        }

        public static T GetAppender<T>() where T : IAppender {
            foreach (ILog log in LogManager.GetCurrentLoggers()) {
                foreach (IAppender appender in log.Logger.Repository.GetAppenders()) {
                    if (appender is T) {
                        return (T)appender;
                    }
                }
            }

            return default(T);
        }

        public static void Info(string message) {
            _logger.Info(message);
        }

        public static void Debug(string message) {
            _logger.Debug(message);
        }

        public static void Error(string message) {
            _logger.Error(message);
        }

        public static void Fatal(string message) {
            _logger.Fatal(message);
        }

        public static void Warn(string message) {
            _logger.Warn(message);
        }
    }
}
