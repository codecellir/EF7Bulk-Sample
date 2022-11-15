namespace EFCore7Bulk
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool DeleteMe { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    public class PersonRepository
    {
        public void InsertBulk(int quantity)
        {
            var pepole = new List<Person>();

            for (int i = 1; i <= quantity; i++)
            {
                pepole.Add(new()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Person-{i.ToString("D4")}",
                    DeleteMe = i % 2 == 0
                });
            }

            using var context = new AppDbContext();
            context.People.AddRange(pepole);
            context.SaveChanges();
        }
    }
}
