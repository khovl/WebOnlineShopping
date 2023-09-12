using System;
using System.Collections.Generic;

namespace WebOnlineShopping.Models
{
    public partial class News
    {
        public int NewsId { get; set; }
        public string? Title { get; set; }
        public string? Sdesc { get; set; }
        public string? Content { get; set; }
        public string? Thumb { get; set; }
        public bool? Pulished { get; set; }
        public string? Alias { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Author { get; set; }
        public int? AccountId { get; set; }
        public string? Tags { get; set; }
        public int? CatId { get; set; }
        public bool? IsHot { get; set; }
        public bool? IsNewfeed { get; set; }
        public string? MetaDesc { get; set; }
        public string? MetaKey { get; set; }
        public int? Views { get; set; }

        public virtual Account? Account { get; set; }
    }
}
