
namespace Logic
{
    public interface ILogger
    {

        void Trace(string message);
        void Debug(string message);
        void Error(string message);
        void Fatal(string message);
        void Info(string message);
        void Warn(string message);

    }
}
