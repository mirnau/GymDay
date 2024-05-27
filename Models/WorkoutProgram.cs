using SQLiteNetExtensions.Attributes;
using System.Collections.ObjectModel;

namespace GymDay.Models;

public class WorkoutProgram : BaseWorkoutComponent
{
    //Relationships
    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public ObservableCollection<Workout> Workouts { get; set; }
}