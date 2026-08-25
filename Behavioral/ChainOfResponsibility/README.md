# Паттерн Цепочка обязанностей (Chain of Responsibility)

## Описание

**Цепочка обязанностей (Chain of Responsibility)** — поведенческий паттерн проектирования, который позволяет передавать запросы последовательно по цепочке обработчиков. Каждый обработчик решает, либо обработать запрос самостоятельно, либо передать его следующему обработчику в цепочке.

## Проблема

```
Клиент                        Обработчики ошибок
┌──────────────────────┐     ┌──────────────────────────────────────┐
│ Client               │     │ RegisterErrorHandler                 │
│                      │     │ SearchErrorSolutionHandler           │
│ Handle(error)        │───→ │ ExecuteErrorSolutionHandler          │
│                      │     │ FinishWorksHandler                   │
│                      │     │                                      │
│                      │     │   1. Какой обработчик вызвать?       │
│                      │     │   2. В каком порядке?                │
│                      │     │   3. Что делать, если решение не     │
│                      │     │      найдено?                        │
└──────────────────────┘     └──────────────────────────────────────┘
```

**Недостатки:**

- **Жёсткая привязка**: клиент знает о каждом обработчике и сам решает, кому передать запрос
- **Дублирование логики**: клиент содержит условные конструкции (`if`/`switch`) для выбора обработчика, что разрастается при добавлении новых шагов
- **Смешение ответственности**: клиент отвечает не только за бизнес-логику, но и за порядок и условия вызова обработчиков
- **Нарушение принципа открытости/закрытости (OCP)**: добавление нового шага обработки требует изменения клиентского кода

> ✅ Клиент должен передать запрос одному обработчику — а не знать о `RegisterErrorHandler`, `SearchErrorSolutionHandler` и условиях их вызова.  
> ❌ Проблема — когда клиент жёстко связан с каждым обработчиком и содержит логику маршрутизации.

## Решение

Цепочка обязанностей — базовый обработчик хранит ссылку на следующий обработчик и делегирует ему запрос при необходимости:

```
Клиент              Цепочка обработчиков
┌──────────────┐   ┌──────────────────────┐     ┌──────────────────────────┐
│ Client       │   │ RegisterErrorHandler │───→ │ SearchErrorSolutionHandler│───→ ┌──────────────────────────┐
│              │   │                      │     │                          │      │ ExecuteErrorSolutionHandler│───→ ┌──────────────────┐
│ Handle()     │──→│ Handle()             │     │ Handle()                 │      │                          │      │ FinishWorksHandler│
│              │   │                      │     │                          │      │ Handle()                 │      │ Handle()          │
│              │   │ _nextHandler         │     │ _nextHandler             │      │ _nextHandler             │      │                  │
│              │   │                      │     │ _nextAlternativeHandler  │───→ └──────────────────────────┘      └──────────────────┘
└──────────────┘   └──────────────────────┘     └──────────────────────────┘
```

**HandlerBase** — абстрактный базовый класс, хранящий ссылку на следующий обработчик и реализующий метод передачи запроса по цепочке.  
**Конкретные обработчики** — `RegisterErrorHandler`, `SearchErrorSolutionHandler`, `ExecuteErrorSolutionHandler`, `FinishWorksHandler`, каждый из которых выполняет свой шаг обработки ошибки.  
**Client** — строит цепочку, связывая обработчики между собой, и инициирует обработку.

> Клиент связывает обработчики: `register.SetNextHandler(searchSolution)` — и вызывает первый: `register.Handle(parameters)` — запрос проходит по цепочке, а клиент не знает деталей реализации каждого шага.

### Как работает

Клиент выполняет обработку ошибки в четыре этапа:

```
Клиент:

  // 1. Создание компонентов (узлов) конвейера обработки ошибки:
  var register = new RegisterErrorHandler();
  var searchSolution = new SearchErrorSolutionHandler();
  var executeSolution = new ExecuteErrorSolutionHandler();
  var finishWorks = new FinishWorksHandler();

  // 2. Настройка конвейера обработки ошибки:
  register.SetNextHandler(searchSolution);
  searchSolution.SetNextHandler(executeSolution);
  searchSolution.SetNextAlternativeHandler(finishWorks);
  executeSolution.SetNextHandler(finishWorks);

  // 3. Определение входных данных обработки ошибки:
  var error = new Error { Description = "..." };
  var parameters = new ParametersContext();
  parameters.SetParameter(ConstantsService.Error, error);

  // 4. Запуск выполнения обработки ошибки:
  register.Handle(parameters);
```

После запуска запрос проходит по цепочке обработчиков:

```
Цепочка внутри:
  1. RegisterErrorHandler — регистрирует ошибку, передаёт дальше
  2. SearchErrorSolutionHandler — ищет решение:
       ├─ решение найдено → ExecuteErrorSolutionHandler → FinishWorksHandler
       └─ решение не найдено → FinishWorksHandler (альтернативный путь)
  3. ExecuteErrorSolutionHandler — выполняет найденное решение, передаёт дальше
  4. FinishWorksHandler — завершает обработку ошибки
```

**Упрощение маршрутизации запросов:**

```
Без цепочки (клиент сам вызывает обработчики):
  registerHandler.Handle(error);
  var solved = searchHandler.Search(error);
  if (solved)
  {
      executeHandler.Handle(error);
      finishHandler.Handle(error);
  }
  else
  {
      finishHandler.Handle(error);
  }
  // при добавлении нового шага — ещё один if/switch и изменение клиента

С цепочкой (обработчики сами передают запрос):
  register.SetNextHandler(searchSolution);
  searchSolution.SetNextHandler(executeSolution);
  searchSolution.SetNextAlternativeHandler(finishWorks);

  register.Handle(parameters);
```

## Структура

| Компонент | Описание | Пример |
|-----------|----------|--------|
| **HandlerBase** | Абстрактный базовый обработчик, хранит ссылки на следующий и альтернативный обработчики | `HandlerBase` |
| **Concrete Handlers** | Конкретные реализации шагов обработки | `RegisterErrorHandler`, `SearchErrorSolutionHandler`, `ExecuteErrorSolutionHandler`, `FinishWorksHandler` |
| **ParametersContext** | Контекст с параметрами, передаваемый по цепочке обработчиков | `ParametersContext` |
| **Client** | Строит цепочку обработчиков и инициирует запрос | `Client` |

## ParametersContext

`ParametersContext` — контейнер параметров, который передаётся по всей цепочке обработчиков. Инкапсулирует данные запроса и предоставляет типобезопасный доступ к ним через методы `GetParameterValue`, `GetParameterValueAsClass<T>` и `GetParameterValueAsStruct<T>`.

По своей роли `ParametersContext` **косвенно аналогичен `HttpContext` в ASP.NET Core**: так же, как `HttpContext` проходит через middleware-конвейер и накапливает данные запроса/ответа, `ParametersContext` проходит по цепочке обработчиков, каждый из которых может читать и дополнять его параметры.

```
ParametersContext
┌──────────────────────────────────────────────┐
│ _parameters: Dictionary<string, object>      │
│                                              │
│  GetParameterValue(name)          → object? │
│  GetParameterValueAsClass<T>(name) → T?     │
│  GetParameterValueAsStruct<T>(name) → T?    │
│  SetParameter(name, value)                   │
└──────────────────────────────────────────────┘
        │
        ▼
 RegisterErrorHandler → SearchErrorSolutionHandler → ... → FinishWorksHandler
 (каждый обработчик читает/изменяет параметры в контексте)
```

В данном примере клиент помещает объект `Error` в контекст:

```csharp
var parameters = new ParametersContext();
parameters.SetParameter(ConstantsService.Error, error);

register.Handle(parameters);
```

Каждый обработчик извлекает `Error` из контекста, выполняет свой шаг и при необходимости обновляет данные — другие обработчики видят эти изменения.

## Расширение классического паттерна — альтернативное ветвление

> ⚠️ Данное расширение **не является частью классического паттерна Цепочка обязанностей** и добавлено автором как необходимое для конкретного примера. В классическом паттерне цепочка строго линейна и альтернативного ветвления нет.

В классической реализации цепочки обязанностей каждый обработчик имеет только один следующий обработчик (`_nextHandler`), что ограничивает цепочку линейной последовательностью. Однако в реальных задачах может потребоваться **ветвление** — когда в зависимости от результата обработки запрос передаётся по одному из нескольких путей.

В данном примере введено расширение — **альтернативный обработчик** (`_nextAlternativeHandler`):

```
SearchErrorSolutionHandler
   │
   ├─ _nextHandler (решение найдено) ──→ ExecuteErrorSolutionHandler ──→ FinishWorksHandler
   │
   └─ _nextAlternativeHandler (решение не найдено) ──→ FinishWorksHandler
```

Базовый класс `HandlerBase` содержит два поля:

```csharp
protected HandlerBase? _nextHandler;           // следующий обработчик (классический)
protected HandlerBase? _nextAlternativeHandler; // альтернативный обработчик (расширение)
```

Обработчик `SearchErrorSolutionHandler` использует ветвление: если решение найдено (`error.Solved == true`), запрос уходит по основному пути — к выполнению решения; если не найдено — по альтернативному, сразу к завершению обработки. Это позволяет гибко маршрутизировать запрос без участия клиента.

## Преимущества

- **Снижение связанности**: клиент не знает, какой обработчик выполнит запрос, и не зависит от конкретных реализаций
- **Устранение условных конструкций**: логика выбора и порядка обработки выносится из клиента в сами обработчики
- **Расширяемость (OCP)**: новые шаги обработки добавляются как новые классы-обработчики, без изменения существующего кода
- **Гибкость маршрутизации**: благодаря альтернативному обработчику цепочка может ветвиться в зависимости от результата

## Когда использовать

- Нужно обработать запрос несколькими способами, но заранее неизвестно, какой именно подойдёт
- Обработчики должны выполняться в определённом порядке
- Набор обработчиков должен меняться динамически во время выполнения
- Нужно изолировать логику каждого шага обработки от клиента и других шагов

## Связь с другими паттернами

- **Strategy** — Strategy заменяет алгоритм целиком, а Chain of Responsibility передаёт запрос по цепочке, где каждый обработчик может выполнить только свою часть
- **Command** — Command инкапсулирует запрос как объект, а Chain of Responsibility определяет, кто его обработает
- **Decorator** — Decorator оборачивает объект, расширяя его поведение, а Chain of Responsibility передаёт запрос дальше по цепочке

## См. также

- [Клиент](./Client.cs)
- [Базовый обработчик](./HandlerBase.cs)
- [Регистрация ошибки](./RegisterErrorHandler.cs)
- [Поиск решения](./SearchErrorSolutionHandler.cs)
- [Выполнение решения](./ExecuteErrorSolutionHandler.cs)
- [Завершение обработки](./FinishWorksHandler.cs)
- [Модель ошибки](./Error.cs)
- [Константы](./ConstantsService.cs)
- [Контекст параметров](../../Utils/ParametersContext.cs)
