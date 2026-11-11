# Паттерн Адаптер (Adapter)

## Описание

**Адаптер (Adapter)** — структурный паттерн проектирования, который позволяет объектам с несовместимыми интерфейсами работать вместе. Адаптер оборачивает существующий класс и переводит вызовы привычного клиенту интерфейса в вызовы, которые понимает адаптируемый класс.

## Проблема

```
Клиент                         Внешний платёжный сервис
┌───────────────────────┐      ┌──────────────────────────────────────┐
│ MakePayment(          │      │ PaymentService                       │
│   paymentTerminal,    │      │                                      │
│   amount, payer)      │───→  │   MakePayment(double amount,         │
│                       │      │                 string payer)        │
│ Ожидает:              │      │                                      │
│ IPaymentTerminal      │      │   НЕ реализует IPaymentTerminal      │
│   .Pay(decimal, string)│     │   сумма в double, другое имя метода  │
└───────────────────────┘      └──────────────────────────────────────┘
```

**Недостатки:**

- **Несовместимость интерфейсов**: клиент работает с `IPaymentTerminal.Pay(decimal, string)`, а внешний сервис предоставляет `PaymentService.MakePayment(double, string)` — прямой вызов невозможен
- **Разные типы данных**: сумма оплаты в клиенте — `decimal`, во внешнем сервисе — `double`
- **Зависимость клиента от внешнего кода**: чтобы «подружить» интерфейсы, пришлось бы менять клиент или код чужой библиотеки, который недоступен для правки
- **Нарушение OCP**: подключение второго платёжного сервиса с ещё одним интерфейсом требует правки клиента

> ✅ Клиент должен вызвать один метод `Pay()` — а не знать, что внутри `MakePayment` и `double`.  
> ❌ Проблема — когда нужному интерфейсу соответствует чужой класс с другими сигнатурами.

## Решение

Адаптер реализует нужный клиенту интерфейс и внутри переводит вызов в API адаптируемого сервиса:

```
Клиент              Целевой интерфейс        Адаптеры              Адаптируемый класс
┌──────────────┐   ┌──────────────────┐   ┌─────────────────────┐  ┌──────────────────┐
│ Client       │   │ IPaymentTerminal │   │ PaymentServiceAdapter│ │ PaymentService   │
│              │   │                  │   │  (наследование)      │ │                  │
│ MakePayment()│──→│ Pay(decimal,     │──→│ PaymentServiceSecond │→│ MakePayment      │
│              │   │     string)      │   │  Adapter (композиция)│ │  (double, string)│
└──────────────┘   └──────────────────┘   └─────────────────────┘  └──────────────────┘
```

**Целевой интерфейс** — `IPaymentTerminal`, с которым работает клиент (`Pay(decimal amount, string payer)`).  
**Адаптируемый класс (Adaptee)** — `PaymentService`, внешний сервис с несовместимым API.  
**Адаптер** — реализует `IPaymentTerminal` и транслирует вызов в `MakePayment`, выполняя приведение типов.

> Клиент передаёт адаптер в метод `MakePayment(IPaymentTerminal, ...)` — тот вызывает `_paymentService.MakePayment((double)amount, payer)`.  
> Клиент не знает, что платёж выполняет внешний сервис, и работает с любым терминалом одинаково.

### Как работает

```
Клиент:
  IPaymentTerminal paymentTerminalFirst  = new PaymentServiceAdapter();
  IPaymentTerminal paymentTerminalSecond = new PaymentServiceSecondAdapter(new PaymentService());

  MakePayment(paymentTerminalFirst, amount: 5000m, payer);
  MakePayment(paymentTerminalSecond, amount: 5000m, payer);

Адаптер внутри:
  1. Приведение типа суммы: (double)amount
  2. Делегирование: MakePayment(double, payer)
  3. Внешний сервис валидирует данные и выполняет платёж
```

**Два способа реализации адаптера:**

```
Адаптер-класс (наследование):
  class PaymentServiceAdapter : PaymentService, IPaymentTerminal
  {
      public void Pay(decimal amount, string payer)
          => MakePayment((double)amount, payer);   // базовый класс = Adaptee
  }

Адаптер-объект (композиция + внедрение через конструктор):
  class PaymentServiceSecondAdapter : IPaymentTerminal
  {
      private readonly PaymentService _paymentService;

      public PaymentServiceSecondAdapter(PaymentService paymentService)
      {
          ArgumentNullException.ThrowIfNull(paymentService);
          _paymentService = paymentService;
      }

      public void Pay(decimal amount, string payer)
          => _paymentService.MakePayment((double)amount, payer);
  }
```

Адаптер-объект предпочтительнее: адаптер не создаёт внешний сервис сам, а получает его извне (в том числе из DI-контейнера). Наследование же связывает адаптер с конкретным классом и делает его недоступным для подмены, пока у сервиса нет интерфейса.

## Структура

| Компонент | Описание | Пример |
|-----------|----------|--------|
| **Target** | Интерфейс, ожидаемый клиентом | `IPaymentTerminal` |
| **Adaptee** | Адаптируемый класс с несовместимым API | `PaymentService` |
| **Adapter (class)** | Адаптер через наследование Adaptee | `PaymentServiceAdapter` |
| **Adapter (object)** | Адаптер через композицию и внедрение через конструктор | `PaymentServiceSecondAdapter` |
| **Client** | Работает только с `Target` | `Client` |
| **Другие реализации Target** | Нативный терминал, реализующий интерфейс напрямую | `PaymentTerminal`, `PaymentException` |

## Преимущества

- **Совместимость несовместимого**: клиент использует привычный `IPaymentTerminal` вместо чужого API
- **Соблюдение OCP**: новый платёжный сервис добавляется новым адаптером без изменения клиента
- **Единая точка перевода**: несовпадение типов и имён методов сосредоточено в адаптере, а не размазано по клиенту
- **Тестируемость и конфигурируемость (адаптер-объект)**: `PaymentService` внедряется через конструктор, а не создаётся внутри адаптера
- **Слабая связанность**: клиент зависит от абстракции `IPaymentTerminal`, а не от конкретного внешнего сервиса

## Когда использовать

- Нужно использовать существующий класс, чей интерфейс не подходит клиенту
- Интерфейсы несовместимы по типам параметров или названиям методов
- Код адаптируемого класса недоступен для изменения (сторонняя библиотека, legacy, чужой сервис)
- Нужно подготовить код к будущей замене внешней зависимости
- Требуется изолировать клиент от деталей интеграции с внешними сервисами

## Связь с другими паттернами

- **Decorator** — Decorator расширяет интерфейс, ничего не меняя в нём, а Adapter полностью конвертирует один интерфейс в другой
- **Facade** — Facade создаёт упрощённый интерфейс подсистемы, а Adapter подгоняет существующий интерфейс под ожидаемый
- **Bridge** — Bridge проектирует разделение абстракции и реализации заранее, а Adapter «лечит» несовместимость постфактум
- **Proxy** — Proxy контролирует доступ к объекту с тем же интерфейсом, а Adapter меняет сам интерфейс

## См. также

- [Клиент](./Client.cs)
- [Целевой интерфейс](./IPaymentTerminal.cs)
- [Адаптируемый сервис](./PaymentService.cs)
- [Адаптер через наследование](./PaymentServiceAdapter.cs)
- [Адаптер через композицию](./PaymentServiceSecondAdapter.cs)
- [Нативная реализация](./PaymentTerminal.cs), [./PaymentException.cs](./PaymentException.cs)
