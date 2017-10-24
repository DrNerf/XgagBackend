using AutoMapper;
using DAL;
using Microsoft.Extensions.Logging;
using System;

namespace ServiceLayer
{
    internal class ServiceBase<TEntity> : IServiceBase
        where TEntity : class
    {
        protected IRepository<TEntity> Repository { get; private set; }
        protected IMapper Mapper { get; private set; }
        protected ILogger<ServiceBase<TEntity>> Logger { get; private set; }

        public ServiceBase(IServiceProvider serviceProvider)
        {
            Repository = serviceProvider.GetService(typeof(IRepository<TEntity>))
                as IRepository<TEntity>;
            Mapper = serviceProvider.GetService(typeof(IMapper)) as IMapper;
            Logger = serviceProvider.GetService(typeof(ILogger<ServiceBase<TEntity>>))
                as ILogger<ServiceBase<TEntity>>;
        }

        public void Dispose()
        {
            Repository.Dispose();
        }
    }
}
