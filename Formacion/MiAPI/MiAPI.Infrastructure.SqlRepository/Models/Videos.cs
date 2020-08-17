using System;
using System.Collections.Generic;

namespace MiAPI.Infrastructure.Repository.Models
{
    public partial class Videos
    {
        public long VideoId { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
