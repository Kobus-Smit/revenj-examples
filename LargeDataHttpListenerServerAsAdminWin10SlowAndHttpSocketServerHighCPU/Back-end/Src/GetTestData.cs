using System;
using Revenj.Processing;
using test;

namespace SimpleMapping.App.Service.Plugin
{
    public class GetTestData : IServerService<int, test_data>
    {
        public test_data Execute(int sizeInKB)
        {
            var randomBytes = new byte[sizeInKB*1024];
            new Random().NextBytes(randomBytes);
            return new test_data { bytes = randomBytes };
        }
    }
}