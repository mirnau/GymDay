using SQLiteNetExtensions.Attributes;

namespace GymDay.Models;

public class Workout : BaseWorkoutComponent, IModelWithParentId
{
    [ForeignKey(typeof(WorkoutProgram))]
    public int ParentId { get; set; }

    //Relationships
    [OneToMany(CascadeOperations = CascadeOperation.CascadeDelete | CascadeOperation.CascadeRead)]
    public List<Exercise> Exercises { get; set; }
}