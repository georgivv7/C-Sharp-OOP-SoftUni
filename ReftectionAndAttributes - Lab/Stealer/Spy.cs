using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfClass, params string[] fields)
    {
        Type classType = Type.GetType(nameOfClass);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static
            | BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder stringBuilder = new StringBuilder();
        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        stringBuilder.AppendLine($"Class under investigation: {nameOfClass}");

        foreach (FieldInfo field in classFields.Where(f=>fields.Contains(f.Name)))
        {
            stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return stringBuilder.ToString().Trim();
    }
}
