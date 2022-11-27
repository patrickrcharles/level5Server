using System;
using System.Collections.Generic;

namespace level5Server.Models.nftairdrop
{
    public partial class NFT
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TokenId { get; set; }
        public int? AvailableRequests { get; set; }
        public int? MaxRequests { get; set; }
    }
}
