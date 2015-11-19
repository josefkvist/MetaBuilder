using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaBuilder.Core
{
    public static class Extensions
    {
        public static string ToMinuteString(this double seconds)
        {
            var minutes = (int)seconds / 60;
            var secondsLeft = (int)seconds % 60;
            var left = 0.0;
            if ((int)seconds > 0)
                left = (seconds % (int)seconds) * 100;
            return minutes + ":" + (secondsLeft < 10 ? "0" + secondsLeft : secondsLeft.ToString())
                + ":" + (left < 10 ? "0" + ((int)left) : ((int)left).ToString());
        }

        public static int ToMilliSeconds(this double seconds)
        {
            return (int) (1000*Math.Round(seconds,3));
        }    
    }
}
