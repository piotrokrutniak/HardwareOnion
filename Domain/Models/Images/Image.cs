using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Models.Images
{
    public class Image : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageType { get; set; }
        public string ImageUrl { get; set;}
        [JsonIgnore]
        public virtual List<ImageAssignment> ImageAssignments { get; set; }
    }
}
