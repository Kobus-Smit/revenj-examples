using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using Revenj.Processing;

namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public abstract class BaseServerCommand<TInput, TOutput> : IServerService<TInput, TOutput>
    {
        protected readonly IDataContext context;
        protected readonly IDatabaseQuery databaseQuery;

        protected BaseServerCommand(IDataContext context, IDatabaseQuery databaseQuery)
        {
            //TODO Is it bad to have a base Command like this that injects many of these:
            this.context = context;
            this.databaseQuery = databaseQuery;
        }

        public abstract TOutput Execute(TInput data);
    }
}