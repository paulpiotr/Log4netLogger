﻿using log4net;
using log4net.Repository;
using System;
using System.IO;

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
        public static ILog GetLog4netInstance(System.Type t)
        {
            try
            {
                TypeofLogger = t;
                return log4net.LogManager.GetLogger(t);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("\n{0}\n{1}\n{2}\n{3}\n", e.GetType(), e.InnerException?.GetType(), e.Message, e.StackTrace), e);
            }
            return null;
        }
        /// <summary>
        /// static Log4netLogger()
        /// </summary>
        static Log4netLogger()
        {
            try
            {
                ILoggerRepository repository = Log4netInstance.Logger.Repository;
                //ILoggerRepository repository = LogManager.GetLogger(TypeofLogger ?? System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Logger.Repository;
                FileInfo fileInfo = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\" + "log4net.config"));
                log4net.Config.XmlConfigurator.ConfigureAndWatch(repository, fileInfo);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("\n{0}\n{1}\n{2}\n{3}\n", e.GetType(), e.InnerException?.GetType(), e.Message, e.StackTrace), e);
            }
        }
    }
}
