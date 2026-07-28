using ExampleDesignPatterns.Architectural.Saga.Enums;

namespace ExampleDesignPatterns.Architectural.Saga.Models;

    /// <summary>
    /// Состояние саги создания документа.
    /// Используется для оркестрации шагов и корректной компенсации при ошибках.
    /// </summary>
    public class DocumentSagaState
    {
        /// <summary>
        /// Уникальный идентификатор создаваемого документа.
        /// </summary>
        public Guid DocumentId { get; set; }

        /// <summary>
        /// Заголовок документа успешно создан.
        /// </summary>
        public bool IsHeaderCreated { get; set; }

        /// <summary>
        /// Тело документа успешно создано.
        /// </summary>
        public bool IsBodyCreated { get; set; }

        /// <summary>
        /// Подвал (итоги) документа успешно создан
        /// .</summary>
        public bool IsFooterCreated { get; set; }

        /// <summary>
        /// Текущий статус саги для мониторинга и логирования.
        /// </summary>
        public SagaStatus Status { get; set; } = SagaStatus.Pending;
    }

