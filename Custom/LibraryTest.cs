using System;
using System.Collections.Generic;

namespace Codepractice.Custom
{
    using System.Data;
    using System.Reflection;

    using Codepractice.DesignPattern;

    public abstract class LibraryTest
    {
        public virtual void testfun() { }
    }

    public class LibraryDerived : LibraryTest
    {
        public override void testfun()
        {
            throw new NotImplementedException();
        }

      //  Parallel.ForEach(x, x => );
    }

    public static class TestGenetic<T>
    {
        public static void testGeneric()
        {
            Console.WriteLine(typeof(T).GetProperty("Age").PropertyType);
            Console.WriteLine(typeof(T).Name);
        }




        public static DataTable CreateTypeTable(IEnumerable<long?> collection)
        {
            // Create DataTable which will contain data from List<T>
            var dataTable = new DataTable();
            Type valuetype = typeof(long);
            dataTable.Columns.Add("Id", Nullable.GetUnderlyingType(valuetype) ?? valuetype);

            // Return parameter with null value
            if (collection == null)
                return dataTable;

            // Traverse through number of entries / rows in the List
            foreach (var item in collection)
            {
                // Create a new DataRow
                var dataRow = dataTable.NewRow();
                dataRow["Id"] = item;
                // Add Row to Table
                dataTable.Rows.Add(dataRow);
            }

            return (dataTable);
        }

        public static void FetchCustom<T>()
        {
            //// Fetch Type Property Info
            var property = typeof(T).GetProperty("StartDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase).PropertyType;
            if (property.IsGenericType && property.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                property = property.GetGenericArguments()[0];
            }

            Console.WriteLine(property.Name);
        }

        // Check for Singleton 
        public static void CheckSingleton()
        {
            var instance = Singleton.getInstance();

            var instance2 = Singleton.getInstance();

            if (instance == instance2) Console.WriteLine("both instance are same");

        }

    }

}
