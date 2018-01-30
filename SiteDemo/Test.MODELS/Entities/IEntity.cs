using System;
using System.Collections.Generic;
using System.Text;

namespace Site.MODELS.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
