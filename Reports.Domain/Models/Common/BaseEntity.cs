﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Reports.Domain.Models.Common
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
    }
}
