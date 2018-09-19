
using Revenj.Processing;
using test;

namespace SimpleMapping.App.Service.Plugin
{
    public class SetTestData  : IServerService<test_data, int>
    {
        public int Execute(test_data data) => data.bytes.Length;
    }
}