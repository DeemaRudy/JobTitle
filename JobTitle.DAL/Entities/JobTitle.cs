namespace JobTitle.DAL.Entities
{
    public class JobTitle
    {
        public JobTitle(string name)
        {
            Name = name;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
    }
}
