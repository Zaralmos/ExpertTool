using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Views
{
    public static class DateTimeExtensions
    {
        public static string ToHtmlDateFormat(this DateTime? date) => date != null ? string.Join('-', ((DateTime)date).ToShortDateString().Split('.').Reverse()) : null;
    }
}
