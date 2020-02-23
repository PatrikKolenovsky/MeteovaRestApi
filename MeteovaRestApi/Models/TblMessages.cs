using System;
using System.Collections.Generic;

namespace MeteovaRestApi.Models
{
    public partial class TblMessages
    {
        public int MessageId { get; set; }
        public string ClientId { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public bool? Enable { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}
