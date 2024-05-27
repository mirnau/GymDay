namespace GymDay.Models
{
    internal class Regimen
    {
        public Regimen()
        {
            Workouts = [];
            Name = string.Empty;
            Description = string.Empty;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        List<Workout> Workouts { get; set; }
    }
}
