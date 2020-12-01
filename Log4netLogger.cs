using System;
using System.IO;
using log4net;
using log4net.Repository;

/// <summary>
/// namespace Log4netLogger
/// </summary>
namespace Log4netLogger
{
    /// <summary>
    /// public static class Log4netLogger
    /// </summary>
    public static class Log4netLogger
    {
        /// <summary>
        /// public static System.Type TypeofLogger { get; set; }
        /// </summary>
        public static System.Type TypeofLogger { get; set; }
        /// <summary>
        /// public static ILog Log4netInstance { get; } = LogManager.GetLogger(TypeofLogger ?? System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// </summary>
        public static ILog Log4netInstance { get; } = LogManager.GetLogger(TypeofLogger ?? System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// public static ILog GetLog4netInstance(System.Type t)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static ILog GetLog4netInstance(Type t)
        {
            TypeofLogger = t;
            return LogManager.GetLogger(t);
        }
        /// <summary>
        /// static Log4netLogger()
        /// </summary>
        static Log4netLogger()
        {
            ILoggerRepository repository = Log4netInstance.Logger.Repository;
            var fileInfo = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\" + "log4net.config"));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(repository, fileInfo);
        }
    }
}
