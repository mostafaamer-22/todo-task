﻿

namespace ToDo.Domain.Primitives;

public interface IAuditableEntity
{
    DateTime CreatedOnUtc { get; }
    DateTime? ModifiedOnUtc { get; }
}
