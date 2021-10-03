using System;
using System.Reflection;

namespace Reflections_Copy
{
    class Program
    {
        public static void SetValues<T>(ref T instance)
        {
            var type = instance.GetType();
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var time = DateTime.Today;
            if (fields[0].FieldType == time.GetType())
            {
                fields[0].SetValue(instance, time);

                Console.WriteLine("input the name of Your service: ");
                fields[1].SetValue(instance, Console.ReadLine());
            }
            else
            {
                fields[1].SetValue(instance, time);

                Console.WriteLine("input the name of Your service: ");
                fields[0].SetValue(instance, Console.ReadLine());
            }
            
        }

        public static T PropsCopy<T>(ref T instance,ref T secondInstance)
        {
            
            var type = instance.GetType();
            var fieldsOfInstance = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            var secondType = secondInstance.GetType();
            var fieldsOfSecondInstance = secondType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            int i = 0;
            foreach (var field in fieldsOfSecondInstance)
            {
                field.SetValue(secondInstance, fieldsOfInstance[i].GetValue(instance));
                i++;
            }

            return secondInstance;
        }

        public static void Print<T>(T instance)
        {
            var type = instance.GetType();
            var fields = type.GetFields(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public);
            foreach (var field in fields)
            {
                Console.WriteLine("Name of Field: " + field.Name + "-" + "Field Value: " + field.GetValue(instance));
            }
        }

        static void Main(string[] args)
        {
            var instance = new ProjectServices();
            var secondInstance = new ProjectServices();


            Console.WriteLine("Input name of your client: ");
            instance.clientName = Console.ReadLine();

            Console.WriteLine("Input count of deploy days: ");
            instance.deployDaysCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Input count of Jobs: ");
            instance.jobsCount = int.Parse(Console.ReadLine());

            SetValues(ref instance);
            PropsCopy(ref instance,ref secondInstance);
            Print(secondInstance);
            
        }
    }
}
