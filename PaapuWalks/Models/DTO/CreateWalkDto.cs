namespace PaapuWalks.Models.DTO
{
    public class CreateWalkDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Double LengthInKm { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
