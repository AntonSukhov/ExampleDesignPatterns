# Паттерн Абстрактная фабрика (Abstract Factory)

## Описание

**Абстрактная фабрика (Abstract Factory)** — порождающий паттерн проектирования, который предоставляет интерфейс для создания семейств связанных объектов без указания их конкретных классов.

## Проблема

```
Клиент                    Код создания
┌──────────────┐         ┌──────────────────────────────┐
│ Client       │         │                              │
│              │         │ var connection =             │
│ Use()        │         │   new SqlConnection(...);    │
│              │         │ var command =                │
│              │         │   new SqlCommand(...);       │
│              │         │ var parameter =              │
│              │         │   new SqlParameter(...);     │
└──────────────┘         └──────────────────────────────┘
```

**Недостатки:**

- **Жёсткая зависимость**: клиент создаёт `SqlConnection`, `SqlCommand`, `SqlParameter` напрямую — привязан к SQL Server
- **Сложность замены**: для перехода на PostgreSQL нужно менять каждый `new SqlConnection` на `new NpgsqlConnection`, каждый `SqlCommand` на `NpgsqlCommand`
- **Нет семейства**: нет гарантии, что `SqlCommand` совместим с `SqlConnection` — каждый создаётся независимо
- **Нарушение OCP**: для поддержки новой БД нужно менять существующий код клиента

> ✅ Клиент должен работать с `IDbProvider` — а не с `SqlConnection` и `SqlCommand`.  
> ❌ Проблема — когда клиент создаёт объекты конкретных классов БД напрямую.

## Решение

Фабрика, которая создаёт семейства связанных объектов (connection, command, parameter) для конкретной БД:

```
Клиент                    Абстрактная фабрика              Реальные фабрики
┌──────────────┐         ┌──────────────────┐           ┌─────────────────────┐
│ Client       │         │ IDbProvider      │           │ SqlDbProvider       │
│              │         │                  │           │                     │
│ Use()        │───────→ │ CreateConnection │───────→   │ new SqlConnection   │
│              │         │ CreateCommand    │───────→   │ new SqlCommand      │
│              │         │ CreateParameter  │───────→   │ new SqlParameter    │
└──────────────┘         └──────────────────┘           └─────────────────────┘
                                  │
                                  ├── NpgDbProvider
                                  │   ├── new NpgsqlConnection
                                  │   ├── new NpgsqlCommand
                                  │   └── new NpgsqlParameter
                                  │
                                  └── SqlDbProvider
                                      ├── new SqlConnection
                                      ├── new SqlCommand
                                      └── new SqlParameter
```

**Абстрактная фабрика** — `IDbProvider` с методами `CreateConnection()`, `CreateCommand()`, `CreateParameter()`.  
**Конкретные фабрики** — `SqlDbProvider` (SQL Server) и `NpgDbProvider` (PostgreSQL), каждая создаёт совместимое семейство объектов.

> Клиент работает только с `IDbProvider` — не знает, какую БД использует.  
> Семейство объектов гарантированно совместимо — все объекты создаются одной фабрикой.

### Как работает

```
Выбор БД:
  IDbProvider dbProvider = new SqlDbProvider();   // SQL Server
  IDbProvider dbProvider = new NpgDbProvider();   // PostgreSQL

Создание совместимого семейства:
  var connection = dbProvider.CreateConnection("...");     // SqlConnection или NpgsqlConnection
  var command = dbProvider.CreateCommand("SELECT...");     // SqlCommand или NpgsqlCommand
  var parameter = dbProvider.CreateParameter("@id", ...);  // SqlParameter или NpgsqlParameter
```

**Независимость от конкретной БД:**

```
SqlDbProvider                    NpgDbProvider
    │                                  │
    ▼                                  ▼
SqlConnection                      NpgsqlConnection
SqlCommand                         NpgsqlCommand
SqlParameter                         NpgsqlParameter
    │                                  │
    └────────── ОДИН ИНТЕРФЕС ─────────┘
                    IDbProvider
```

Клиент не меняется при переходе с SQL Server на PostgreSQL — меняется только строка `new SqlDbProvider()` / `new NpgDbProvider()`.

## Структура

| Компонент | Описание | Пример |
|-----------|----------|--------|
| **AbstractFactory** | Интерфейс фабрики, определяет методы создания объектов семейства | `IDbProvider` |
| **ConcreteFactory** | Конкретная фабрика, создаёт семейство объектов для одной БД | `SqlDbProvider`, `NpgDbProvider` |
| **AbstractProduct** | Абстрактный тип продукта (базовый класс или интерфейс) | `DbConnection`, `DbCommand`, `DbParameter` |
| **ConcreteProduct** | Конкретный продукт конкретной фабрики | `SqlConnection`, `SqlCommand`, `SqlParameter`, `NpgsqlConnection`... |

## Преимущества

- **Гарантия совместимости**: все объекты семейства создаются одной фабрикой — совместимость гарантирована
- **Открытость к расширению**: для новой БД создаётся новая фабрика — существующий код клиента не меняется
- **Сокрытие конкретных классов**: клиент работает только с абстрактными типами (`DbConnection`, `DbCommand`)
- **Централизация создания**: вся логика создания объектов — в фабрике, а не разбросана по клиенту

## Когда использовать

- Нужно поддерживать несколько семейств связанных объектов (например, для разных БД)
- Требуется гарантия совместимости объектов внутри семейства
- Нужно избежать привязки клиента к конкретным классам
- Семейства продуктов могут меняться в рантайме

## Связь с другими паттернами

- **Factory Method** — Factory Method создаёт один продукт через наследование, а Abstract Factory создаёт семейства продуктов через композицию
- **Builder** — Builder пошагово собирает сложный объект, а Abstract Factory создаёт семейства связанных объектов одной операцией
- **Singleton** — абстрактная фабрика часто реализуется как одиночка, если фабрика ресурсоёмкая

## См. также

- [Клиент](./Client.cs)
- [Фабрика](./IDbProvider.cs)
- [Конкретные фабрики](./SqlDbProvider.cs), [./NpgDbProvider.cs](./NpgDbProvider.cs)
