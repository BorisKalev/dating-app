namespace ProjFinRBEM.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public DateTime MessageSent { get; set; }


        public int SenderId { get; set; }

        public int RecipientId { get; set; }
    }
}
