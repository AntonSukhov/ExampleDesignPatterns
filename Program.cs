using AbstractFactoryClient = ExampleDesignPatterns.Generating.AbstractFactory.Client;
using FactoryMethodClient = ExampleDesignPatterns.Generating.FactoryMethod.Client;
using BuilderClient = ExampleDesignPatterns.Generating.Builder.Client;
using PrototypeCleint = ExampleDesignPatterns.Generating.Prototype.Client;
using SingletonClient = ExampleDesignPatterns.Generating.Singleton.Client;
using AdapterClient = ExampleDesignPatterns.Structural.Adapter.Client;
using BridgeClient = ExampleDesignPatterns.Structural.Bridge.Client;
using CompositeClient = ExampleDesignPatterns.Structural.Composite.Client;
using DecoratorClient = ExampleDesignPatterns.Structural.Decorator.Client;

//Порождающие шаблоны проектирования:
AbstractFactoryClient.Run();
FactoryMethodClient.Run();
BuilderClient.Run();
PrototypeCleint.Run();
SingletonClient.Run();

//Структурные шаблоны проектирования:
AdapterClient.Run();
BridgeClient.Run();
CompositeClient.Run();
DecoratorClient.Run();


