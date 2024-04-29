namespace TaskTrackerBackend.Models;

    public class UserModel
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }

        public UserModel()
        {
            
        }
    }
