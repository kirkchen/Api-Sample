using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Utility.Extensions.Authentication
{
    public class ChiperTextHelper : IChiperTextHelper
    {
        public IEncryptHelper EncryptHelper { get; set; }

        public ChiperTextHelper(IEncryptHelper encryptHelper)
        {
            this.EncryptHelper = encryptHelper;
        }

        public bool CheckTimestampInRange(string TimeStamp, int inspectionSecond)
        {
            bool result = false;            
            int apiTimeStamp;
            apiTimeStamp = Convert.ToInt32(TimeStamp);

            ////取得現在的TimeStamp
            int nowTimeStamp = Convert.ToInt32(this.GetTimeStamp());

            ////判斷Timestamp是否過期
            var isValid = (nowTimeStamp - apiTimeStamp) <= inspectionSecond;

            if (isValid)
            {
                result = true;
            }

            return result;
        }

        public string GetTimeStamp()
        {
            DateTime gtm = new DateTime(1970, 1, 1);//宣告一個GTM時間出來
            DateTime utc = DateTime.UtcNow.AddHours(8);//宣告一個目前的時間

            //我們把現在時間減掉GTM時間得到的秒數就是timpStamp，因為我不要小數點後面的所以我把它轉成int
            int timeStamp = Convert.ToInt32(((TimeSpan)utc.Subtract(gtm)).TotalSeconds);
            return timeStamp.ToString();
        }

        public string GetSignature(string encryptKey, string saltKey, string timestamp, string content)
        {
            var encryptSource = string.Format("ts={0};d={1};sk={2}", timestamp, content, saltKey);
            var encryptContent = this.EncryptHelper.Encrypt(encryptKey, content);

            return encryptContent;
        }
    }
}
