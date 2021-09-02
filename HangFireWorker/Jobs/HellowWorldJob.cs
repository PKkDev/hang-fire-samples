using HangFire.JobInterfaces;
using System;

namespace HangFireWorker.Jobs
{
    public class HellowWorldJob : IHellowWorldJob
    {
        public HellowWorldJob() { }

        public void WriteLine()
        {
            Console.WriteLine("helloy default");
        }

        public void WriteLine(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new Exception("пустая строка для отображения");

            Console.WriteLine(text);
        }
    }
}
