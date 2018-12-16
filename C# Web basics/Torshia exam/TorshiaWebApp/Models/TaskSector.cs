namespace TorshiaWebApp.Models
{
    public class TaskSector
    {
        public string TaskId { get; set; }
        public virtual Task Task { get; set; }

        public string SectorId { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
