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

            object?[] values = new object?[10];
            for (int i = 0; i < 10; i++)
                values[i] = null;

            var sb = new System.Text.StringBuilder();
            for (int i = 1; i < 10; i++)
                sb.AppendLine((values[i] == values[0]).ToString());
            MessageBox.Show(sb.ToString());

            return;

            InitializeLogger();

            Application.Run(new MainWindow());

            PortableLogger.Shared?.Dispose();
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
                    errors.Enqueue(new Exception("Caught exception, when tried to create readme file (Log dir)", ex));
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
                        FileStream fs = File.Open(logPath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                        logger = PortableLogger.CreateShared(fs);
                        logger.Log($"Created new file {logPath}");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    if (File.Exists(logPath))
                        try
                        {
                            File.Delete(logPath);
                            errors.Enqueue(new Exception($"Caught exception, when tried to create log file '{logPath}'. File was created, but cleanup successful", ex));
                        }
                        catch (Exception ex2)
                        {
                            errors.Enqueue(new Exception($"Caught exception, when tried to create log file '{logPath}'. File was created, but cleanup get exception" +
                                $"\r\nInner exception (first): {ex}", ex2));
                        }
                    else
                        errors.Enqueue(new Exception($"Caught exception, when tried to create log file '{logPath}'. No file created", ex));
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