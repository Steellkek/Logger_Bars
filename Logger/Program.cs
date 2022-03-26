using System;
using System.IO;

namespace Logger 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //логгер для string
            var LogString = new LocalFileLogger<string>("LogString.txt");
            LogString.LogInfo("Объект создан");
            LogString.LogWarning("Предупреждение");
            LogString.LogError("Произошла ошибка",new FormatException());
            //логгер для int
            var LogInt = new LocalFileLogger<int>("LogInt.txt");
            LogInt.LogInfo("Объект создан");
            LogInt.LogWarning("Предупреждение");
            LogInt.LogError("Произошла ошибка",new FormatException());
            //логгер для array
            var LogArray = new LocalFileLogger<Array>("LogArray.txt");
            LogArray.LogInfo("Объект создан");
            LogArray.LogWarning("Предупреждение");
            LogArray.LogError("Произошла ошибка",new FormatException());
            //логгер для собственного класса
            var LogMyType = new LocalFileLogger<MyType>("LogMyType.txt");
            LogMyType.LogInfo("Объект создан");
            LogMyType.LogWarning("Предупреждение");
            LogMyType.LogError("Произошла ошибка",new FormatException());
        }

        public interface ILogger
        {
            public void LogInfo(string message);
            public void LogWarning(string message);
            public void LogError(string message, Exception ex);

        }
        //собсетвенный класс
        public class MyType
        {
            
        }
        
        public class LocalFileLogger<T>:ILogger
        {
            //путь к файлу
            private string Way;

            public LocalFileLogger(string way)
            {
                Way = way;
            }

            public void LogInfo(string message)
            {
                using (StreamWriter fs = new StreamWriter(Way,true))
                {
                    fs.WriteLine($"[Info]: [{typeof(T).Name}] : {message}");
                }
            }

            public void LogWarning(string message)
            {
                using (StreamWriter fs = new StreamWriter(Way,true))
                {
                    fs.WriteLine($"[Warning]: [{typeof(T).Name}] : {message}");
                }
            }

            public void LogError(string message, Exception ex)
            {
                using (StreamWriter fs = new StreamWriter(Way,true))
                {
                    fs.WriteLine( $"[Error] : [{typeof(T).Name}] : {message}. {ex.Message}");
                }
            }
        }
    }
}