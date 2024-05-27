using SQLiteNetExtensions.Attributes;

namespace GymDay.Models;

public class Exercise : BaseWorkoutComponent
{
    [ForeignKey(typeof(Workout))]
    public int ParentId { get; set; }
    public int PreviousWeekKgs { get; set; }
    public int EstimatedReps { get; set; }
    public int OneRepMax { get; set; }
    public int PersonalBest { get; set; }

    //Relationships
    [OneToMany(CascadeOperations = CascadeOperation.CascadeDelete | CascadeOperation.CascadeRead)]
    public List<Set> Sets { get; set; }
}
