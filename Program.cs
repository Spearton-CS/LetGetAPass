using LetGetAPass.Properties;
using System.Runtime.Versioning;

namespace LetGetAPass
{
    [SupportedOSPlatform("windows")]
    internal static class Program
    {
        private const string logsDirReadmeContent =
            @"This dir used to logs (informational additional files of application about its work).
LetGetAPass have limitations for logs: up to 256, after will overwrite 0 and delete 1-9!
LetGetAPass use log-name format: (0-255).log, where first line containing Date and Time when log file created";
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            InitializeLogger();

            Application.Run(new MainWindow());
        }

        static void InitializeLogger()
        {
            const string dir = "Logs.log", readme = $"{dir}\\!readme.txt";
            string logPath;
            bool dirCreated = false, readmeCreated = false;
            Queue<Exception> errors = [];

            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                    dirCreated = true;
                }
                catch
                {
                    return;
                }
            }

            if (!File.Exists(readme))
            {
                try
                {
                    File.WriteAllText(readme, logsDirReadmeContent);
                    readmeCreated = true;
                }
                catch (Exception ex)
                {
                    errors.Enqueue(ex);
                }
            }

            PortableLogger logger = null; //Compilation pass

            for (byte i = 0; i < byte.MaxValue; i++)
            {
                logPath = $"{dir}\\{i}.log";
                try
                {
                    if (!File.Exists(logPath))
                    {
                        logger = PortableLogger.CreateShared(File.Create(logPath));
                        logger.Log($"Created new file {logPath}");
                    }
                }
                catch (Exception ex)
                {
                    errors.Enqueue(ex);
                }
            }

            if (PortableLogger.Shared is null)
            {
                byte j = 0;
                for (byte i = 0; i < 10; i++)
                    try
                    {
                        File.Delete($"{dir}\\{i}.log");
                        j++;
                    }
                    catch (Exception ex)
                    {
                        errors.Enqueue(ex);
                    }

                try
                {
                    logger = PortableLogger.CreateShared(File.Create(logPath = $"{dir}\\0.log"));
                    logger.Log($"Created file {logPath} bc overflow (>= 255 log files). {j} old logs was deleted.");
                }
                catch
                {
                    return;
                }
            }

            if (dirCreated)
                logger!.Log("Logs directory recreated");

            if (readmeCreated)
                logger!.Log("Logs directory readme recreated");

            if (errors.Count > 0)
            {
                logger!.Log("Below this log list of uncaught exception during PortableLogger initialization");
                logger.Log(errors);
            
                errors.Clear();
            }
        }
    }
}