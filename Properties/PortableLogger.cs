using System.Collections;
using System.Collections.Concurrent;

namespace LetGetAPass.Properties
{
    /// <summary>Provides simple log feature. BigEndianUnicode (UTF-16), can be shared, </summary>
    public class PortableLogger : IDisposable
    {
        private readonly Stream output;
        private readonly Thread worker;
        private readonly ConcurrentBag<object?> work = [];

        public PortableLogger(Stream output)
        {
            this.output = output;
            worker = new(WorkerLogic)
            {
                Priority = ThreadPriority.BelowNormal,
                Name = $"PortableLogger for {output.GetType().Name}"
            };
            worker.Start();
        }

        private void WorkerLogic()
        {
            const string dtFormat = "dd.hh:mm.ss",
                logSeparator = "===========================================";

            StreamWriter logger = new(output, System.Text.Encoding.BigEndianUnicode, -1, true);
            var work = this.work;

            logger.WriteLine($"{Thread.CurrentThread.Name} initialized at {DateTime.Now:yyyy.MM.dd hh.mm:ss}");
            logger.WriteLine(logSeparator);
            logger.Flush();

            while (!work.IsEmpty || !disposed)
            {
                while (work.TryTake(out var line))
                {
                    if (line is null)
                        logger.WriteLine($"{DateTime.Now.ToString(dtFormat)}: null");
                    if (line is IEnumerable lines && lines is not IEnumerable<char>)
                    {
                        logger.WriteLine(DateTime.Now.ToString(dtFormat));
                        foreach (var realLine in lines)
                        {
                            logger.WriteLine(realLine);
                            logger.WriteLine();
                        }
                    }
                    else
                        logger.WriteLine($"{DateTime.Now.ToString(dtFormat)}: {line}");
                    logger.WriteLine();
                    logger.WriteLine(logSeparator);
                    logger.WriteLine();
                }
                logger.Flush();
                Thread.Sleep(100);
            }
        }

        private static volatile PortableLogger? shared = null;
        /// <summary>Shared logger. Use CreateShared if its null</summary>
        public static PortableLogger? Shared => shared;
        public static PortableLogger CreateShared(Stream output)
        {
            shared?.Dispose();
            return shared = new(output);
        }

        public void Log(object? log)
        {
            ObjectDisposedException.ThrowIf(disposed, this);
            work.Add(log);
        }

        private volatile bool disposed = false;
        public bool Disposed => disposed;
        /// <summary>Cleanup for unmanaged resources and IO-operations. When used to dispose Shared logger - removes it from that field.</summary>
        public void Dispose()
        {
            if (Disposed)
                return;
            if (this == shared)
                shared = null;
            disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}