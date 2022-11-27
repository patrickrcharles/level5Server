using System;
using System.Collections.Generic;

namespace level5Server.Models.nftairdrop
{
    public partial class NFTRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TokenId { get; set; }
        public string RequestAddress { get; set; }
        public string IpAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public int? Transferred { get; set; }
    }
}
