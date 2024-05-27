using SQLiteNetExtensions.Attributes;
using System.Collections.ObjectModel;

namespace GymDay.Models;

public class Routine : BaseWorkoutComponent, IModelWithParentId
{
    [ForeignKey(typeof(WorkoutPlan))]
    public int ParentId { get; set; }

    //Relationships
    [ManyToOne(CascadeOperations = CascadeOperation.All)]
    public WorkoutPlan WorkoutPlan { get; set; }

    [ManyToOne(CascadeOperations = CascadeOperation.All)]
    public ObservableCollection<Workout> Workouts { get; set; }
}
