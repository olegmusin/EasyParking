﻿using System;

namespace EasyParking.Domain.Abstract
{
    public interface IModifiableEntity
    {
        string Name { get; set; }
    }

    public interface IEntity : IModifiableEntity
    {
        object Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        byte[] Version { get; set; }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
