using System;
using System.Collections.Generic;

namespace mysql_scaffold_dbcontext_test.Models.nftairdrop
{
    public partial class NFTRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TokenId { get; set; }
        public string RequestAddress { get; set; }
        public int? Transferred { get; set; }
    }
}
