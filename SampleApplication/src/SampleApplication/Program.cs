using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Administrator\\Downloads\\AdventureWorks2012_Data.mdf; Integrated Security = True; Connect Timeout = 30"))
            {

                connection.Open();

                SqlCommand cmd = new SqlCommand("select * from HumanResources.Department", connection);
                DbDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SchemaOnly);

                if (reader.CanGetColumnSchema())
                {
                    var columns = reader.GetColumnSchema();
                    foreach (var column in columns)
                    {
                        Console.Write("ColumName: " + column.ColumnName);
                        Console.Write(", DataTypeName: " + column.DataTypeName);
                        Console.Write(", ColumnSize: " + column.ColumnSize);
                        Console.WriteLine(", IsUnique: " + column.IsUnique);
                    }
                }
                else
                    throw new Exception("Connection does not support GetColumnSchema.");
            }

            Console.ReadLine();
        }
    }
}
