using API.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IMapper mapper;
        private DataContext context;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        //public IUserRepository UserRepository => new UserRepository(context, mapper);
        //public IDestinationRepository DestinationRepository => new DestinationRepository(context, mapper);

        public async Task<bool> Complete()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public bool HasChanged()
        {
            return context.ChangeTracker.HasChanges();
        }
    }
}
