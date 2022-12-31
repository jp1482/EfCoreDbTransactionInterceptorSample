
using (var context = new ExampleContext())
{
    await context.Database.EnsureDeletedAsync();
    await context.Database.EnsureCreatedAsync();    
}

using (var context = new ExampleContext())
{
    var exampleEntity = new ExampleEntity()
    {
         Name = "Test",
    };

    context.Examples.Add(exampleEntity);
    await context.SaveChangesAsync();
}

Console.WriteLine("Done");
Console.ReadLine();
