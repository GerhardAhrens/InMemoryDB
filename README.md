# InMemoryDB
Storing objects in a memory database via a repository

## Simple example 
```
DemoClassShort dom = new DemoClassShort();
dom.Id = Guid.NewGuid();
dom.ClassName = "Test-1-A";

/* Store in Repository */
InMemoryRepository<DemoClassShort> repository = new InMemoryRepository<DemoClassShort>();
repository.Add(dom);

```
