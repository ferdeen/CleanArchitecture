﻿using PaxosExercise.Core.SharedKernel;
using System.Collections.Generic;

namespace PaxosExercise.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : BaseEntity;
        T GetByDigest<T>(string digest) where T : BaseEntity;
        List<T> List<T>() where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        void DeleteAll<T>() where T : BaseEntity;
    }
}
