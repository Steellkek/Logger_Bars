using System;

namespace Logger // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Log = new LocalFileLogger<string>(@"C:\Users\alyam\RiderProjects\Logger\Logger\bin\Debug\net6.0\text.txt");
            
        }
        
        public interface ILogger
        {
            public void LogInfo(string message);
            public void LogWarning(string message);
            public void LogError(string message, Exception ex);

        }
        
        public class LocalFileLogger<T>:ILogger
        {
            private string Way;

            public LocalFileLogger(string way)
            {
                Way = way;
                
            }

            public void LogInfo(string message)
            {
                throw new NotImplementedException();
            }

            public void LogWarning(string message)
            {
                throw new NotImplementedException();
            }

            public void LogError(string message, Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}