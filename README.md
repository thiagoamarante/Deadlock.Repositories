# Deadlock.Repositories (1.0.0)
# Deadlock.Repositories.DocumentDB (1.0.0)


Framework in C # for the abstract creation of repositories.
> Soon implementation for JSON File and SQL Server
> The objective of the framework was to create helpers in which always recur in every project when using the pattern repository.

## Context
In many applications, the business logic accesses data from data stores such as databases, or Web services. Directly accessing the data can result in the following:

* Duplicated code
* A higher potential for programming errors
* Weak typing of the business data
* Difficulty in centralizing data-related policies such as caching
* An inability to easily test the business logic in isolation from external dependencies

## Objectives
Use the Repository pattern to achieve one or more of the following objectives:

* You want to maximize the amount of code that can be tested with automation and to isolate the data layer to support unit testing.
* You access the data source from many locations and want to apply centrally managed, consistent access rules and logic.
* You want to implement and centralize a caching strategy for the data source.
* You want to improve the code's maintainability and readability by separating business logic from data or service access logic.
* You want to use business entities that are strongly typed so that you can identify problems at compile time instead of at run time.
* You want to associate a behavior with the related data. For example, you want to calculate fields or enforce complex relationships or business rules between the data elements within an entity.
* You want to apply a domain model to simplify complex business logic.

[More About The Repository Pattern](https://msdn.microsoft.com/en-us/library/ff649690.aspx)

## Abstract Repository
```c#
    using Deadlock.Repositories;

    public interface ITestRepository : IRepository
    {
        Task<Test> Get(string id);

        Task<Test> Save(Test value);

        Task Delete(string id);
    }
```

## Abstract Context
```c#
    using Deadlock.Repositories;

    public interface ISampleContext : IContext
    {
        ITestRepository Tests { get; }
    }
```

## Implementing Repository in DocumentDB
```c#
    using Deadlock.Repositories;
    using Deadlock.Repositories.DocumentDB;

    public class TestRepository : DefaultRepository<Test>, ITestRepository
    {

    }
```

## Implementing Context in DocumentDB
```c#
    using Deadlock.Repositories;
    using Deadlock.Repositories.DocumentDB;

    public class SampleContext : DocumentDBContext, ISampleContext
    {
        public SampleContext(Configuration configuration)
            :base(configuration)            
        {

        }

        public ITestRepository Tests { get { return this.GetRepository<TestRepository>(); } }
    }
```

## Registering Context in DocumentDB 
```c#
    using Deadlock.Repositories;

    Context.Register<Repositories.DocumentDB.SampleContext>();
```

## Setting Access of DocumentDB
```c#
    using Deadlock.Repositories;

    IConfiguration configuration = new Deadlock.Repositories.DocumentDB.Configuration()
    {
        EndpointUrl = config.EndpointUrl,
        AuthorizationKey = config.AuthorizationKey,
        DataBaseName = config.DataBaseName,
        CollectionDefault = config.CollectionDefault
    };
```

## Using Abstract Context
```c#
    using Deadlock.Repositories;

    using (var context = Context.Create<ISampleContext>(configuration))
    {
        await context.Tests.Save(new Models.Test()
        {
            Id = "id",
            Name = "test"
        });
    }
```