namespace ScpApi.Models
{
    public class TeamMemberSprint
    {
        public string Id { get; }
        public string Name { get; set; }
        public int DaysAvailableBeforeFF { get; set; }
        public int DaysAvailableAfterFF { get; set; }
    }
}