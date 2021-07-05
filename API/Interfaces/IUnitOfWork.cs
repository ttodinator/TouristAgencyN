﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Complete();
        bool HasChanged();
        public IUserRepository UserRepository { get; }
        public IDestinationRepository DestinationRepository { get; }
    }
}
