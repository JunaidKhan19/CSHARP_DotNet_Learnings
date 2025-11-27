using System;
using System.Reflection;

namespace ReflectionExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Junaid\Desktop\Github uploads\C#DotNet\day09\MyMathFunctions\bin\Debug\net9.0\MyMathFunctions.dll";

            Assembly assembly = Assembly.LoadFrom(filePath);

            Type[] mathType = assembly.GetTypes();

            for (int i = 0; i < mathType.Length; i++)
            {
                Type type = mathType[i];

                object? dynamicallyCreatedObject = assembly.CreateInstance(type.FullName);

                MethodInfo[] methods = type.GetMethods();

                for (int j = 0; j < methods.Length; j++)
                {
                    string methodSignature = "";
                    MethodInfo currentMethod = methods[j];

                    methodSignature += currentMethod.ReturnType.ToString() + " " + currentMethod.Name + " (";

                    ParameterInfo[] parameters = currentMethod.GetParameters();

                    for (int k = 0; k < parameters.Length; k++)
                    {
                        ParameterInfo currentParameter = parameters[k];

                        methodSignature = methodSignature + " " + currentParameter.ParameterType.ToString() + " " + currentParameter.Name + ",";
                    }

                    object[] userInputs = new object[parameters.Length];
                    for (int l = 0; l < parameters.Length; l++)
                    {
                        ParameterInfo param = parameters[l];
                        Console.WriteLine($"Enter value for {param.Name} of type {param.ParameterType.ToString()}");
                        object? value = Convert.ChangeType(Console.ReadLine(), param.ParameterType);
                        userInputs[l] = value;
                    }

                    methodSignature = methodSignature.TrimEnd(',', ' ') + ")";

                    Console.WriteLine(methodSignature);

                    object result = type.InvokeMember(currentMethod.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, dynamicallyCreatedObject, userInputs); 

                    Console.WriteLine(result);
                }
            }
        }
    }
}
02