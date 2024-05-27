using SQLiteNetExtensions.Attributes;

namespace GymDay.Models;

public class Workout : BaseWorkoutComponent
{
    [ForeignKey(typeof(Routine))]
    public int ParentId { get; set; }

    //Relationships
    [OneToMany(CascadeOperations = CascadeOperation.CascadeDelete | CascadeOperation.CascadeRead)]
    public List<Exercise> Exercises { get; set; }
}