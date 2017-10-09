using System;
using Revenj.Api;
using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using Revenj.Processing;
using Revenj.Serialization;

namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public abstract class BaseServerCommand<TInput, TOutput> : IServerService<TInput, TOutput>
    {
        public readonly IServiceProvider locator;
        protected readonly IDataContext context;
        protected readonly IDatabaseQuery databaseQuery;
        public readonly IDomainModel domainModel;
        public readonly IWireSerialization serialization;
        public readonly ICommandConverter converter;

        protected BaseServerCommand(IServiceProvider locator, IDataContext context, IDatabaseQuery databaseQuery, IDomainModel domainModel, IWireSerialization serialization, ICommandConverter converter)
        {
            //TODO Is it bad to have a base Command like this that injects many of these:
            this.locator = locator;
            this.context = context;
            this.databaseQuery = databaseQuery;
            this.domainModel = domainModel;
            this.serialization = serialization;
            this.converter = converter;
        }

        public abstract TOutput Execute(TInput data);
    }
}