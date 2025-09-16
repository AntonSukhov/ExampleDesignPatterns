namespace ExampleDesignPatterns.Behavioral.ChainOfResponsibility;

public static class Client
{
    public static void Run()
    {
        HandlerBase register = new RegisterErrorHandler();
        HandlerBase searchSolution = new SearchErrorSolutionHandler();
        HandlerBase executeSolution = new ExecuteErrorSolutionHandler();
        HandlerBase finishWorks = new FinishWorksHandler();

        register.SetNextHandler(searchSolution);
        searchSolution.SetNextHandler(executeSolution);
        searchSolution.SetNextAlternativeHandler(finishWorks);
        executeSolution.SetNextHandler(finishWorks);

        var error = new Error
        {
            Description = "При открытии окна Просмотр карточки товара возникла ошибка превышения значения таймаута"
        };

        var parameters = new ParametersContext();
        parameters.SetParameter(ConstantsService.Error, error);

        register.Handle(parameters);

    }
}
