using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        static void Main(string[] args)
        {
            var typeOfBox = typeof(BlackBoxInteger);
            object instance = Activator.CreateInstance(typeOfBox, true);

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var tokens = input.Split('_').ToArray();
                string methodName = tokens[0];
                int value = int.Parse(tokens[1]);

                MethodInfo method = typeOfBox.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(instance, new object[] { value });

                FieldInfo resultValue = typeOfBox.GetField(
                    "innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

                Console.WriteLine(resultValue.GetValue(instance));
            }
        }
    }
}
