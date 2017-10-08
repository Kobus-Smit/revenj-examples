using System.Data;
using System.IO;
using ProtoBuf.Data;

namespace UseCase1.App.Common.Helpers
{
    public static class DataTableHelper
    {

        public static byte[] ToByteArray(this DataTable table)
        {
            using (var stream = new MemoryStream())
            using (var reader = table.CreateDataReader())
            {
                DataSerializer.Serialize(stream, reader);
                return stream.ToArray();
            }
        }

        public static DataTable ToDataTable(this byte[] value)
        {
            var dt = new DataTable();
            using (var stream = new MemoryStream(value))
            using (var reader = DataSerializer.Deserialize(stream))
                dt.Load(reader);

            return dt;
        }
    }
}