using EFCore7Bulk;
using Microsoft.EntityFrameworkCore;

using var dbconext = new AppDbContext();

Console.Clear();

dbconext.People.ExecuteDelete();

var repo = new PersonRepository();

repo.InsertBulk(1000);
Console.Clear();

dbconext.People.Where(x=>x.DeleteMe).ExecuteDelete();

Console.ReadKey();
Console.Clear();

var update = DateTime.Now;

dbconext.People.ExecuteUpdate(c=>c.SetProperty(d=>d.UpdateDate,d=>update)
.SetProperty(d=>d.Name,d=>d.Name+"UPDATED"));

Console.ReadKey();
