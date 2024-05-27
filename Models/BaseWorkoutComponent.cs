using SQLite;
namespace GymDay.Models;

public class BaseWorkoutComponent
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int Rank { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime LastView { get; set; }
    public bool IsSkipped { get; set; }
    public bool IsCompleted { get; set; }
}
