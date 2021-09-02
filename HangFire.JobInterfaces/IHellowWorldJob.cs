using Hangfire;

namespace HangFire.JobInterfaces
{
    [Queue("helloy_jobs")]
    public interface IHellowWorldJob
    {
        [Queue("write_line")]
        void WriteLine();

        [Queue("write_line_text")]
        void WriteLine(string text);
    }
}
