using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using Revenj.Processing;

namespace InterfaceTest.App.Service.Plugin
{
    public class TestCommonParameter : IServerService<CommonParam, string>
    {

        private readonly IDataContext db;
        private readonly IDatabaseQuery qry;

        public TestCommonParameter(IDataContext db, IDatabaseQuery qry)
        {
            this.db = db;
            this.qry = qry;
        }

        public string Execute(CommonParam cp)
        {           
            var person = new Person().FromVM(cp.Person);
            //...
            return "";
        }
    }
}