# InMemoryDB
<img src="./InMemoryDB.png" style="width:100px;"/>

Storing objects in a memory database via a repository
InMemoryDB is a simple way to manage an object through a repository without storing the individual properties on a database. The different database operations can be simulated with InMemoryDB.
Different methods are provided to simulate the work with a database table. The editing is done via the methods Add(), Update(), Delete() etc. directly in the memory (without database). If necessary, the current content can also be saved as an XML file and loaded again.
It is possible to edit an object with a repository. Connected objects in one repository are not possible.

## The repository class provides the following methods
#### Count()
#### FindById(Guid id)
#### FindAll()
#### Add(T)
#### Update(T)
#### Delete(T)
#### DeleteAll()
#### Exist(T)
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
### Delete Item in Repository
```
DemoClassShort dom = new DemoClassShort();
dom.Id = Guid.NewGuid();
dom.ClassName = "Test-1-A";

/* Store in Repository */
InMemoryRepository<DemoClassShort> repository = new InMemoryRepository<DemoClassShort>();
repository.Add(dom);

DemoClassShort result1 = repository.FindById(dom.Id);
repository.Delete(result1);

```