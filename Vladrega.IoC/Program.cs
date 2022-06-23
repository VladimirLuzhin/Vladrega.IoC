using Vladrega.IoC.Implementation;
using Vladrega.IoC.Implementation.ClassExmaples;
using Vladrega.IoC.InvertibleDependencies;

var services = new ServiceCollection();
services.AddSingleton<IInvertibleDependency, SomeInvertibleDependency>();
services.AddSingleton<ExternalDependency>();
services.AddSingleton<ExampleWithExternalDependency>();
services.AddTransient<TransientExample>();

var serviceProvider = services.Build();
var exampleWithExternalDependency = serviceProvider.GetService<ExampleWithExternalDependency>();
exampleWithExternalDependency.ShowText();

var transientExample1 = serviceProvider.GetService<TransientExample>();
transientExample1.ShowCounter();

var transientExample2 = serviceProvider.GetService<TransientExample>();
transientExample2.ShowCounter();

var transientExample3 = serviceProvider.GetService<TransientExample>();
transientExample3.ShowCounter();

Console.ReadLine();