namespace SocialNetwork.DAL.Models
{
    public class Message
    {
        public Message(int userId, int networkId, string text)
        {
            UserId = userId;
            NetworkId = networkId;
            Text = text;
        }
        public int Id { get; set; }

        public int UserId { get; set; }

        public int NetworkId { get; set; }

        public string Text { get; set; }
    }
}
