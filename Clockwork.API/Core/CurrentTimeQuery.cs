using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwork.API.Core
{
    public class CurrentTimeQuery
    {
        public virtual int CurrentTimeQueryId { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual string ClientIp { get; set; }
        public virtual DateTime UTCTime { get; set; }       
    }
}
