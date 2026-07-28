using ExampleDesignPatterns.Architectural.Saga.Enums;
using ExampleDesignPatterns.Architectural.Saga.Models;
using ExampleDesignPatterns.Architectural.Saga.Repositories;

namespace ExampleDesignPatterns.Architectural.Saga;

/// <summary>
/// Оркестратор саги создания документа.
/// Управляет последовательностью шагов, отслеживает состояние
/// и выполняет компенсацию при ошибках.
/// </summary>
public class DocumentCreationSaga
{
    private readonly IDocumentHeaderRepository _headerRepo;
    private readonly IDocumentBodyRepository _bodyRepo;
    private readonly IDocumentFooterRepository _footerRepo;

    public DocumentCreationSaga(
        IDocumentHeaderRepository headerRepo,
        IDocumentBodyRepository bodyRepo,
        IDocumentFooterRepository footerRepo)
    {
        _headerRepo = headerRepo;
        _bodyRepo = bodyRepo;
        _footerRepo = footerRepo;
    }

    /// <summary>
    /// Основной метод саги: выполняет все шаги последовательно.
    /// При ошибке автоматически запускает компенсацию в обратном порядке.
    /// </summary>
    public async Task<Guid> ExecuteAsync(
        string headerContent,
        string bodyContent,
        string footerContent,
        CancellationToken ct)
    {
        // Создаём состояние саги: фиксируем ID и начальный статус
        var state = new DocumentSagaState
        {
            DocumentId = Guid.NewGuid(),
            Status = SagaStatus.Pending
        };

        try
        {
            // --- ШАГ 1: создаём заголовок ---
            await _headerRepo.CreateHeaderAsync(state.DocumentId, headerContent, ct);
            MakeHeaderCreated(state);

            // --- ШАГ 2: создаём тело ---
            await _bodyRepo.CreateBodyAsync(state.DocumentId, bodyContent, ct);
            MakeBodyCreated(state);

            // --- ШАГ 3: создаём подвал ---
            await _footerRepo.CreateFooterAsync(state.DocumentId, footerContent, ct);
            MakeFooterCreated(state);

            return state.DocumentId;
        }
        catch (Exception)
        {
            // Если на любом шаге произошла ошибка — запускаем компенсацию
            await CompensateAsync(state, ct);

            // Пробрасываем ошибку дальше, чтобы вызывающий код знал о сбое
            throw;
        }
    }

    /// <summary>
    /// Метод компенсации: откатывает выполненные шаги в обратном порядке.
    /// Использует флаги состояния (Is*Created), а не статусы enum,
    /// чтобы точно знать, какие шаги реально были выполнены.
    /// Это критично, если шаг мог частично завершиться или если логика усложнится.
    /// </summary>
    private async Task CompensateAsync(DocumentSagaState state, CancellationToken ct)
    {
        // Откатываем в порядке «последний — первый»
        if (state.IsFooterCreated)
        {
            await _footerRepo.UndoFooterAsync(state.DocumentId, ct);
        }

        if (state.IsBodyCreated)
        {
            await _bodyRepo.UndoBodyAsync(state.DocumentId, ct);
        }

        if (state.IsHeaderCreated)
        {
            await _headerRepo.UndoHeaderAsync(state.DocumentId, ct);
        }

        // Фиксируем, что компенсация выполнена
        state.Status = SagaStatus.Compensated;
    }

    private static void MakeHeaderCreated(DocumentSagaState state)
    {
        state.IsHeaderCreated = true;
        state.Status = SagaStatus.HeaderCreated;
    }

    private static void MakeBodyCreated(DocumentSagaState state)
    {
        state.IsBodyCreated = true;
        state.Status = SagaStatus.BodyCreated;
    }

    private static void MakeFooterCreated(DocumentSagaState state)
    {
        state.IsFooterCreated = true;
        state.Status = SagaStatus.Completed;
    }
}
