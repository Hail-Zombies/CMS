using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.App_Start
{
    public class DateTimeHelper
    {
        public static string ToChinese(DateTime dt)
        {
            string yyyyMMdd = dt.ToString("yyyyMMdd");

            return GetChineseNumber(Convert.ToInt32(yyyyMMdd.Substring(0, 1))) +
                GetChineseNumber(Convert.ToInt32(yyyyMMdd.Substring(1, 1))) +
                GetChineseNumber(Convert.ToInt32(yyyyMMdd.Substring(2, 1))) +
                GetChineseNumber(Convert.ToInt32(yyyyMMdd.Substring(3, 1))) +
                "年" +
                GetChineseNumber(Convert.ToInt32(yyyyMMdd.Substring(4, 2))) +
                "月" +
                GetChineseNumber(Convert.ToInt32(yyyyMMdd.Substring(6, 2))) +
                "日";
        }

        private static string GetChineseNumber(int m)
        {
            string[] cns = new string[] {
            "〇", "一", "二", "三", "四", "五", "六", "七", "八", "九",
            "十", "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九",
            "二十", "二十一", "二十二", "二十三", "二十四", "二十五", "二十六", "二十七", "二十八", "二十九",
            "三十", "三十一"
            };

            return cns[m];
        }
    }
}