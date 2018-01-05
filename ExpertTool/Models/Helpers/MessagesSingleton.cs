using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models.Helpers
{
    public static class MessagesSingleton
    {
        private static Lazy<Messages> data = new Lazy<Messages>(() => new Messages());

        public static Messages Messages { get => data.Value; }
    }
}
