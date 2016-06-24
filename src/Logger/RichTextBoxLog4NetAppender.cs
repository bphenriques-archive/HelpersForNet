using log4net.Appender;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace LoggerUtil.Wpf {
    public class RichTextBoxLog4NetAppender : AppenderSkeleton, IDisposable {
            public RichTextBox textBox;

            private static Brush PREFIX_BACK_COLOR = Brushes.Black;
            private static Brush PREFIX_TEXT_COLOR = Brushes.White;
            private static Brush TEXT_BACK_COLOR = Brushes.Black;

            private readonly Dictionary<string, Brush> TEXT_COLORS = new Dictionary<string, Brush>() {
                { "INFO", Brushes.Lime },
                { "DEBUG", Brushes.White },
                { "WARN", Brushes.Yellow },
                { "ERROR", Brushes.DarkOrange},
                { "FATAL", Brushes.Red }
            };

            public RichTextBoxLog4NetAppender() {
                Logger.Info("Initialized Richtexbox");
            }

            public void Dispose() { /* nothing */ }

            protected override void Append(LoggingEvent loggingEvent) {
                if (textBox != null) {
                    Application.Current.Dispatcher.Invoke(() => Log(loggingEvent));
                }
            }

            public void Log(LoggingEvent loggingEvent) {
                string prefix = new StringBuilder(loggingEvent.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss,fff")).Append(" ")
                    .Append(loggingEvent.Level).Append(" ")
                    .Append(loggingEvent.LoggerName)
                    .ToString();

                string msg = loggingEvent.RenderedMessage + Environment.NewLine;

                AppendTextAux(PREFIX_TEXT_COLOR, PREFIX_BACK_COLOR, prefix + " - ");
                AppendTextAux(TEXT_COLORS[loggingEvent.Level.ToString()], TEXT_BACK_COLOR, msg);
            }

            private void AppendTextAux(Brush textColor, Brush backColor, string text) {
                TextRange tr = new TextRange(textBox.Document.ContentEnd, textBox.Document.ContentEnd);
                tr.Text = text;
                tr.ApplyPropertyValue(TextElement.BackgroundProperty, backColor);
                tr.ApplyPropertyValue(TextElement.ForegroundProperty, textColor);            
            }
    }
}
