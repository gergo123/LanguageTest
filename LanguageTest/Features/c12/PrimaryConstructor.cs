namespace LanguageTest.Features.c12;

public class PrimaryConstructor(string name)
{
    // its a method with implicit return
    public string Name => name;

    //public void Change(string name)
    //{
    //    Name = name;
    //}

    public override string ToString()
    {
        return $"{Name}, {name}";
    }
}

public class PrimaryConstructorTest : IFeature
{
    public void Action()
    {
        var inst = new PrimaryConstructor("Test name");
        Console.WriteLine(inst.ToString());
    }
}
