using System.Collections.Generic;
namespace myapp
{
    public interface IHistoryStorage
    {
        void LogUsage(string input, int result);
    }


}