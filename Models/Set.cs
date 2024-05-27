using SQLiteNetExtensions.Attributes;
namespace GymDay.Models;

public class Set : BaseWorkoutComponent
{
    [ForeignKey(typeof(Exercise))]
    public int RoutineId { get; set; }
    public uint Kgs { get; set; }
    public uint Reps { get; set; }
    public float RPE { get; set; }
}
