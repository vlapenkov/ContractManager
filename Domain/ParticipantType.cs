namespace Domain
{
    public class ParticipantType: BaseEntity
    {
        private ParticipantType() { }
        public string Name { get; private set; }
        public ParticipantType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}