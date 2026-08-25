using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.ChainOfResponsibility;

public static class Client
{
    public static void Run()
    {
        //Создание компонентов (узлов) конвейера обработки ошибки:
        HandlerBase register = new RegisterErrorHandler();
        HandlerBase searchSolution = new SearchErrorSolutionHandler();
        HandlerBase executeSolution = new ExecuteErrorSolutionHandler();
        HandlerBase finishWorks = new FinishWorksHandler();

        //Настройка конвейера обработки ошибки:
        register.SetNextHandler(searchSolution);
        searchSolution.SetNextHandler(executeSolution);
        searchSolution.SetNextAlternativeHandler(finishWorks);
        executeSolution.SetNextHandler(finishWorks);

        //Определение входных данных обработки ошибки:
        var error = new Error
        {
            Description = "При открытии окна Просмотр карточки товара возникла ошибка превышения значения таймаута"
        };

        var parameters = new ParametersContext();
        parameters.SetParameter(ConstantsService.Error, error);

        //Запуск выполнения обработки ошибки:
        register.Handle(parameters);

    }
}
