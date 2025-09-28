using AbstractFactoryClient = ExampleDesignPatterns.Generating.AbstractFactory.Client;
using FactoryMethodClient = ExampleDesignPatterns.Generating.FactoryMethod.Client;
using BuilderClient = ExampleDesignPatterns.Generating.Builder.Client;
using PrototypeCleint = ExampleDesignPatterns.Generating.Prototype.Client;
using SingletonClient = ExampleDesignPatterns.Generating.Singleton.Client;
using AdapterClient = ExampleDesignPatterns.Structural.Adapter.Client;
using BridgeClient = ExampleDesignPatterns.Structural.Bridge.Client;
using CompositeClient = ExampleDesignPatterns.Structural.Composite.Client;
using DecoratorClient = ExampleDesignPatterns.Structural.Decorator.Client;
using FacadeClient = ExampleDesignPatterns.Structural.Facade.Client;
using FlyweightClient = ExampleDesignPatterns.Structural.Flyweight.Client;
using ProxyClient = ExampleDesignPatterns.Structural.Proxy.Client;
using ChainOfResponsibilityClient = ExampleDesignPatterns.Behavioral.ChainOfResponsibility.Client;
using CommandClient = ExampleDesignPatterns.Behavioral.Command.Client;
using InterpreterClient = ExampleDesignPatterns.Behavioral.Interpreter.Client;
using IteratorClient = ExampleDesignPatterns.Behavioral.Iterator.Client;
using MediatorClient = ExampleDesignPatterns.Behavioral.Mediator.Client;
using MementoClient = ExampleDesignPatterns.Behavioral.Memento.Client;
using ObserverClient = ExampleDesignPatterns.Behavioral.Observer.Client;
using StateClient = ExampleDesignPatterns.Behavioral.State.Client;
using StrategyClient = ExampleDesignPatterns.Behavioral.Strategy.Client;

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
FacadeClient.Run();
FlyweightClient.Run();
ProxyClient.Run();

//Поведенческие шаблоны проектирования:
ChainOfResponsibilityClient.Run();
CommandClient.Run();
InterpreterClient.Run();
IteratorClient.Run();
MediatorClient.Run();
MementoClient.Run();
ObserverClient.Run();
StateClient.Run();
StrategyClient.Run();

