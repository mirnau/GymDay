using GymDay.Models;
using System.Collections.ObjectModel;

namespace GymDay.Views.CustomViews;

public partial class RoutineCard : ContentView
{
    #region RankInWeekRegion

    public int RankInRoutine
    {
        get => (int)GetValue(RankInWeekProperty);
        set => SetValue(RankInWeekProperty, value);
    }

    public static readonly BindableProperty RankInWeekProperty =
        BindableProperty.Create
        (nameof(RankInRoutine),
        typeof(int),
        typeof(RoutineCard),
        -1);
    #endregion

    #region WeekNameRegion

    public int RoutineName
    {
        get => (int)GetValue(WeekNameProperty);
        set => SetValue(WeekNameProperty, value);
    }

    public static readonly BindableProperty WeekNameProperty =
        BindableProperty.Create
        (nameof(RoutineName),
        typeof(int),
        typeof(RoutineCard),
        null);
    #endregion


    #region WorkoutsRegion

    public ObservableCollection<RoutineCard> Workouts
    {
        get => (ObservableCollection<RoutineCard>)GetValue(WorkoutsProperty);
        set => SetValue(WorkoutsProperty, value);
    }

    public static readonly BindableProperty WorkoutsProperty =
        BindableProperty.Create
        (nameof(Workouts),
        typeof(ObservableCollection<Workout>),
        typeof(RoutineCard),
        null);
    #endregion



    #region AddWorkoutCommandParameterRegion

    public object AddWorkoutCommandParameter
    {
        get => (object)GetValue(AddWorkoutCommandParameterProperty);
        set => SetValue(AddWorkoutCommandParameterProperty, value);
    }

    public static readonly BindableProperty AddWorkoutCommandParameterProperty =
        BindableProperty.Create
        (nameof(AddWorkoutCommandParameter),
        typeof(object),
        typeof(RoutineCard),
        null);
    #endregion

    #region EditWorkoutCommandParameterRegion

    public object EditWorkoutCommandParameter
    {
        get => (object)GetValue(EditWorkoutCommandParameterProperty);
        set => SetValue(EditWorkoutCommandParameterProperty, value);
    }

    public static readonly BindableProperty EditWorkoutCommandParameterProperty =
        BindableProperty.Create
        (nameof(EditWorkoutCommandParameter),
        typeof(object),
        typeof(RoutineCard),
        null);
    #endregion
}