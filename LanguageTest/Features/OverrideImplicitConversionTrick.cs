namespace LanguageTest.Features;

public class Base
{
    public virtual void DoWork(int param)
    {
        Console.WriteLine("""Do work in Base with int param""");
    }
}

/// <summary>
/// Original implementation on <see cref="Derived"/> are:
/// - <see cref="DoWork(double)"/>
/// New implementations of a method declared on a base class:
/// - <see cref="DoWork(int)"/>
/// C# compiler will first try to make the call compatible with the versions of 
///  DoWork declared *originally* on Derived even if it means to make an
///  implicit conversion in this example from int to double 
///  (int can fit into double without data loss)
/// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/versioning-with-the-override-and-new-keywords#override-and-method-selection
/// </summary>
public class Derived : Base, IFeature
{
    public void Action()
    {
        var d = new Derived();

        int val = 5;
        // calls method with Double param
        d.DoWork(val);

r        // cals base method with int param (or overriden one if exists)
        ((Base)d).DoWork(val);
    }

    //public override void DoWork(int param)
    //{
    //    Console.WriteLine("Do work in derived with int param");
    //}

    public void DoWork(double param)
    {
        Console.WriteLine("Do work in Derived with double param");
    }
}
