namespace QuizApp.Core.Entities
{
    public class Participant : BaseEntity
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public int? Score { get; set; }
        public int? TimeTaken { get; set; }
    }
}
