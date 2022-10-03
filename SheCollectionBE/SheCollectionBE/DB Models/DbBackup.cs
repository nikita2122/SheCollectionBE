namespace SheCollectionBE.DB_Models
{
    public class DbBackup
    {
        public DbBackup()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime  Date { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
    }
}
