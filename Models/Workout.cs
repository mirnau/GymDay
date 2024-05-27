namespace GymDay.Models
{
    internal class Workout
    {
        public Workout()
        {
            Exercises = [];
            Name = string.Empty;
        }

        public string Name { get; set; }
        public int Week { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
