 namespace P01_HarvestingFields
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = Type.GetType("P01_HarvestingFields.HarvestingFields");
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public 
                | BindingFlags.Instance);

            string command;
            while ((command = Console.ReadLine())!= "HARVEST")
            {
                IEnumerable<FieldInfo> fieldsToPrint = null;
                switch (command)
                {
                   case"public":
                        fieldsToPrint = fields.Where(f => f.IsPublic);
                        break;
                    case "protected":
                        fieldsToPrint = fields.Where(f => f.IsFamily);
                        break;
                    case "private":
                        fieldsToPrint = fields.Where(f => f.IsPrivate);
                        break;
                    case "all":
                        fieldsToPrint = fields;
                        break;
                }

                foreach (var field in fieldsToPrint)
                {
                    Print(field);
                }
            }
        }

        private static void Print(FieldInfo field)
        {
            string access = null;
            switch (field.Attributes)
            {
                case FieldAttributes.Family:
                    access = "protected";
                    break;
                case FieldAttributes.Public:
                    access = "public";
                    break;
                case FieldAttributes.Private:
                    access = "private";
                    break;
            }

            string fieldString = $"{access} {field.FieldType.Name} {field.Name}";
            Console.WriteLine(fieldString);
        }
    }
}
