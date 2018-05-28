using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Model
{
    internal class LogFormat
    {
        public string DateTime { get; set; }
        public string Type { get; set; }
        public string Server { get; set; }
        public string Application { get; set; }
        public string Source { get; set; }
        public string Method { get; set; }
        public string AppData { get; set; }
        public string Statement { get; set; }
        public string Description { get; set; }
        public LogFormatReference Reference { get; set; }
        public dynamic customData { get; set; }
    }

    #region NOT USED
    internal class LogFormatReference
    {
        public string TransactionId { get; set; }
        public string AppCode { get; set; }
        public string VenueCode { get; set; }
    }
    #endregion
}
