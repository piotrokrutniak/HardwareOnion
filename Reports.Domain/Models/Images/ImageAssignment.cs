﻿using Reports.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Reports.Domain.Models.Images
{
    public class ImageAssignment : AuditableBaseEntity
    {
        public int ImageId { get; set; }
        public int TargetId { get; set; }
        public string TargetType { get; set; }
        [JsonIgnore]
        public virtual Report Image { get; set; }
    }
}
