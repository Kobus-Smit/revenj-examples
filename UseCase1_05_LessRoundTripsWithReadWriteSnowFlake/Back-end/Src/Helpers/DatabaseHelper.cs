using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using AcmeCorp.Common;
using Npgsql;
using NpgsqlTypes;

namespace UseCase1.App.Service.Plugin.Helpers
{
    public static class DatabaseHelper
    {

        public static string GetConnectionString() => ConfigurationManager.AppSettings["ConnectionString"];

        public static NpgsqlConnection OpenDatabaseConnection()
        {
            var conn = new NpgsqlConnection(GetConnectionString());
            conn.Open();
            return conn;
        }

        public static NpgsqlCommand CreateCommand(this NpgsqlConnection conn, string commandText)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = commandText;
            return cmd;
        }
        
        public static int ExecuteNonQuery(this NpgsqlConnection conn, string commandText) => conn.CreateCommand(commandText).ExecuteNonQuery();

        public static IDataReader ExecuteReader(this NpgsqlConnection conn, string commandText) => conn.CreateCommand(commandText).ExecuteReader();

        public static IDataReader ExecuteReader(this NpgsqlConnection conn, string commandText, CommandBehavior behavior)  => conn.CreateCommand(commandText).ExecuteReader(behavior);

        public static void BulkInsert(this DataTable dataTable, NpgsqlConnection connection)
        {
            var columns = string.Join(",", dataTable.Columns.Cast<DataColumn>().Select(c => "\"" + c.ColumnName + "\""));
            var commandFormat = string.Format(CultureInfo.InvariantCulture, "COPY {0} ({1}) FROM STDIN BINARY", dataTable.TableName, columns);
            using (var writer = connection.BeginBinaryImport(commandFormat))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    writer.StartRow();

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        var value = row[column];
                        if (column.ColumnName == "ID" && value.IsBlank())
                            value = Guid.NewGuid();

                        if (value == DBNull.Value)
                            writer.WriteNull();
                        else
                          writer.Write(value, column.DataType.ToNpgsqlDbType());
                    }
                }
            }
        }

        public static NpgsqlDbType ToNpgsqlDbType(this Type type)
        {
            return 
                type == typeof(byte[]) ? NpgsqlDbType.Bytea : 
                type == typeof(DateTime) ? NpgsqlDbType.Date : 
                type == typeof(double) ? NpgsqlDbType.Double : 
                type == typeof(short) ? NpgsqlDbType.Smallint : 
                type == typeof(int) ? NpgsqlDbType.Integer : 
                type == typeof(long) ? NpgsqlDbType.Bigint : 
                type == typeof(decimal) ? NpgsqlDbType.Numeric : 
                type == typeof(float) ? NpgsqlDbType.Real : 
                type == typeof(string) ? NpgsqlDbType.Text : 
                type == typeof(DateTime) ? NpgsqlDbType.Timestamp : 
                type == typeof(bool) ? NpgsqlDbType.Bit : 
                type == typeof(Guid) ? NpgsqlDbType.Uuid : 
                type == typeof(Array) ? NpgsqlDbType.Array : 
                NpgsqlDbType.Varchar; 
        }

    }
}