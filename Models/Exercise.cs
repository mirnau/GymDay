namespace GymDay.Models
{
    internal class Exercise
    {
        public Exercise()
        {
            AlternativeExercises = [];
            WorkoutSets = [];
            WarmupSets = [];
            Name = string.Empty;
            Description = string.Empty;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Exercise> AlternativeExercises { get; set; }
        public List<Set> WorkoutSets { get; set; }
        public List<Set> WarmupSets { get; set; }
    }
}
