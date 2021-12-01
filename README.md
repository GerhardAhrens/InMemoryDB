# InMemoryDB
Storing objects in a memory database via a repository
Different methods are provided to simulate the work with a database table.

## The repository class provides the following methods
#### Count()
#### FindById(Guid id)
#### Add(T)
#### Update(T)
#### Delete(T)
#### DeleteAll()
#### Exist()
#### ExistById(Guid id)
#### SaveContent(string filename)
#### LoadContent(string filename)

## Simple example 
### Add New Item in Repository
```
DemoClassShort dom = new DemoClassShort();
dom.Id = Guid.NewGuid();
dom.ClassName = "Test-1-A";

/* Store in Repository */
InMemoryRepository<DemoClassShort> repository = new InMemoryRepository<DemoClassShort>();
repository.Add(dom);

```
### Update Item in Repository
```
DemoClassShort dom = new DemoClassShort();
dom.Id = Guid.NewGuid();
dom.ClassName = "Test-1-A";

/* Store in Repository */
InMemoryRepository<DemoClassShort> repository = new InMemoryRepository<DemoClassShort>();
repository.Add(dom);

DemoClassShort result1 = repository.FindById(dom.Id);
result1.ClassName = "Test-B";
repository.Update(result1);

```
