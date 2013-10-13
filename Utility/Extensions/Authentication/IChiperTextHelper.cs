using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Utility.Extensions.Authentication
{
    public interface IChiperTextHelper
    {
        bool CheckTimestampInRange(string TimeStamp, int inspectionSecond);

        string GetTimeStamp();

        string GetSignature(string encryptKey, string saltKey, string timestamp, string content);
    }
}
