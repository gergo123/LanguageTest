// See https://aka.ms/new-console-template for more information
using LanguageTest;
using LanguageTest.Features;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

var assembly = typeof(Program).Assembly;
var assemblyTypes = assembly.GetTypes();

foreach (Type assemblyType in assemblyTypes.Where(x => !x.IsInterface && x.GetInterfaces().Contains(typeof(IFeature))))
{
    Console.WriteLine($"""------- start {assemblyType.FullName} -------""");
    //IFeature feature = (IFeature)Activator.CreateInstance(assemblyType);
    //feature.Action();

    Object o = assembly.CreateInstance(assemblyType.FullName, false, BindingFlags.ExactBinding,
        null, new object[] { }, null, null);

    var mInfo = assembly.GetType(assemblyType.FullName).GetMethod(nameof(IFeature.Action));
    mInfo.Invoke(o, null);
    Console.WriteLine($"""------- end {assemblyType.FullName} -------""");
}

if (assemblyTypes is { Length: 1 or 5 })
{

}

Person person = new("Nancy", "Davolio");
Console.WriteLine(person);

public record Person(string FirstName, string LastName);
