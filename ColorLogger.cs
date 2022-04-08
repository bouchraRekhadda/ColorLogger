using System.Reflection;
using Microsoft.Build.Framework;
using Microsoft.Build.Logging;

namespace ColorLogger
{
    public class ColorLogger : INodeLogger
    {
        #region Private Members
        private ConsoleLogger logger;
        private void BuildStartedHandler(object sender, BuildStartedEventArgs e)
        {
            logger.BuildStartedHandler(sender, e);
        }
        private void BuildFinishedHandler(object sender, BuildFinishedEventArgs e)
        {
            logger.BuildFinishedHandler(sender, e);
        }
        private void ProjectStartedHandler(object sender, ProjectStartedEventArgs e)
        {
            logger.ProjectStartedHandler(sender, e);
        }
        private void ProjectFinishedHandler(object sender, ProjectFinishedEventArgs e)
        {
            logger.ProjectFinishedHandler(sender, e);
        }
        private void TargetStartedHandler(object sender, TargetStartedEventArgs e)
        {
            logger.TargetStartedHandler(sender, e);
        }
        private void TargetFinishedHandler(object sender, TargetFinishedEventArgs e)
        {
            logger.TargetFinishedHandler(sender, e);
        }
        private void MessageHandler(object sender, BuildMessageEventArgs e)
        {
                logger.MessageHandler(sender, e);
        }
        private void WarningHandler(object sender, BuildWarningEventArgs e)
        {
            logger.WarningHandler(sender, e);
        }
        private void ErrorHandler(object sender, BuildErrorEventArgs e)
        {
            logger.ErrorHandler(sender, e);
        }
        private void CustomEventHandler(object sender, CustomBuildEventArgs e)
        {
            logger.CustomEventHandler(sender, e);
        }
        #endregion
        public string Parameters { get; set; }
        public LoggerVerbosity Verbosity { get; set; }
        public void Initialize(IEventSource eventSource)
        {
            eventSource.BuildStarted += BuildStartedHandler;
            eventSource.BuildFinished += BuildFinishedHandler;
            eventSource.ProjectStarted += ProjectStartedHandler;
            eventSource.ProjectFinished += ProjectFinishedHandler;
            eventSource.TargetStarted += TargetStartedHandler;
            eventSource.TargetFinished += TargetFinishedHandler;
            eventSource.MessageRaised += MessageHandler;
            eventSource.WarningRaised += WarningHandler;
            eventSource.ErrorRaised += ErrorHandler;
            eventSource.CustomEventRaised += CustomEventHandler;
        }
        public void Shutdown()
        {
            logger.Shutdown();
        }
        public void Initialize(IEventSource eventSource, int nodeCount)
        {
            if (logger != null)
                return;
            logger = new ConsoleLogger
            {
                SkipProjectStartedText = true,
                Parameters = Parameters,
                Verbosity = Verbosity,
            };
            logger.GetType().GetField("_numberOfProcessors", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(logger, nodeCount);
            Initialize(eventSource);
        }
    }
}