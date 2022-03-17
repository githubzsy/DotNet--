// See https://aka.ms/new-console-template for more information
using Autofac;
using IService;
using Service.MySql;
using Service.Oracle;

// Create the builder with which components/services are registered.
// 创建 ContainerBuilder
var builder = new ContainerBuilder();

// Register types that expose interfaces...
// 定义接口与实体的对应关系
builder.RegisterType<AnimalService_MySql>().As<IAnimalService>();
builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();

// Build the container to finalize registrations
// and prepare for object resolution.
// 创建容器
var container = builder.Build();


IAnimalService animalService = container.Resolve<IAnimalService>();
animalService.Add("123123");

var service = container.Resolve<IGenericService<string>>();
Console.WriteLine(service.SayHello("nihao"));

var service2 = container.Resolve<IGenericService<string>>();
Console.WriteLine(service==service2);

