using MyCustomAttributes;
using System.Reflection;

namespace MyCustomOrm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string assemblyPath = @"C:\Users\Junaid\Desktop\Github uploads\C#DotNet\day10\Employee\bin\Debug\net9.0\Employee.dll";

            Assembly assembly = Assembly.LoadFrom(assemblyPath);

            Type[] allTypes = assembly.GetTypes();

            for (int i = 0; i < allTypes.Length; i++) 
            {
                Type type = allTypes[i];
                Console.WriteLine($"Class Name: {type.Name}");

                Attribute[] allAttribute = type.GetCustomAttributes().ToArray();

                string query = "";

                for (int j = 0; j < allAttribute.Length; j++)
                {
                    Attribute attribute = allAttribute[j];

                    if (attribute is SerializableAttribute)
                    {
                        Console.WriteLine($"Type: {type.FullName} is serializable");
                    }

                    query = "Create Table ";
                    if (attribute is Table)
                    {
                        Table table = attribute as Table;
                        query = query + table.TableName + "(";
                    }

                    PropertyInfo[] allProperties = type.GetProperties();
                    
                    for (int k = 0; k < allProperties.Length; k++)
                    {
                        PropertyInfo property = allProperties[k];

                        Attribute[] propAttributes = property.GetCustomAttributes().ToArray();

                        for (int l = 0; l < propAttributes.Length; l++)
                        {
                            Attribute attr = propAttributes[l];

                            if (attr is Column)
                            {
                                Column column = attr as Column;

                                query = $"{query} {column.ColumnName} {column.ColumnType},";
                            }
                        }
                    }
                }

                query = query.TrimEnd(',') + ");";
                Console.WriteLine(query);

                string path = @"C:\Users\Junaid\Desktop\Github uploads\C#DotNet\day10\MyCustomOrm\DBQuery\MyQuery.sql";
                File.WriteAllText(path, query);
                Console.WriteLine("Query written to file successfully.");
            }
        }
    }
}
