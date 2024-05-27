using SQLiteNetExtensions.Attributes;
using System.Collections.ObjectModel;

namespace GymDay.Models;

public class WorkoutPlan : BaseWorkoutComponent
{
    //Relationships
    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public ObservableCollection<Routine> Routines { get; set; }
}