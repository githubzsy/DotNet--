using ConsoleApp1;
using System;
using System.Data;
using System.Xml.Serialization;

class SampleCollection<T>
{
    // Declare an array to store the data elements.
    private T[] arr = new T[100];

    // Define the indexer to allow client code to use [] notation.
    public T this[int i]
    {
        get { return arr[i]; }
        set { arr[i] = value; }
    }

    [My("abc")]
    [My("CDE")]
    public int Count { get; set; }
}

class Program
{
    static void Main()
    {
        var stringCollection = new SampleCollection<string>();
        stringCollection[0] = "Hello, World";

        var t = stringCollection.GetType();
        var t2 = typeof(SampleCollection<string>);
        var t3 = typeof(SampleCollection<int>);
        var t4 = typeof(SampleCollection<string>);
        // Fasle
        Console.WriteLine(t3 == t2);
        // True
        Console.WriteLine(t4 == t2);
        // True
        Console.WriteLine(t == t2);
    }

    static void ReadMyAttribute()
    {
        Type t = typeof(SampleCollection<string>);

        var methodInfo = t.GetMethods().FirstOrDefault();
        methodInfo.Invoke(null, new object[] { });

        var properties = t.GetProperties();
        foreach (var property in properties)
        {
            Console.WriteLine(property.Name);
            var attrs = property.GetCustomAttributes(typeof(MyAttribute), true);
            foreach (var attr in attrs)
            {
                if (attr is MyAttribute myAttr)
                {
                    Console.WriteLine(myAttr.Name);
                }
            }

        }
    }

    //static DataTable ListToDataTable<T>(List<T> lst)
    //{
    //    Type t= typeof(T);
    //    var properties = t.GetProperties();
    //    var dt = new DataTable();
    //}

    static List<T> DataTableToList<T>(DataTable dt) where T: new()
    {
        Type type = typeof(T);
        var properties = type.GetProperties();
        List<T> list = new List<T>();
        foreach (DataRow row in dt.Rows)
        {
            T t = new T();
            foreach (DataColumn col in dt.Columns)
            {
                var property = properties.Single(a => a.Name == col.ColumnName);
                // 单元格的值, 对应 t.ColumnName 的值
                object obj = row[col.ColumnName];
                property.SetValue(t, obj);
            }
            list.Add(t);
        }

        return list;
    }

    [Obsolete]
    static void AA()
    {

    }
}
// The example displays the following output:
//       Hello, World.