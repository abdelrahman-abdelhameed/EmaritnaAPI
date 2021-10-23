using System;


namespace Emaritna.Bll.Logger
{
    public interface ILoggerService<T> where T : class
    {
        void LogErrorData(string error);
    }
}