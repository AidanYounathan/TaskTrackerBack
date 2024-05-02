namespace TaskTrackerBackend.Models;

    public class UserModel
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }
        public string? BoardIDs { get; set; }
         public string Password { get; set; }
        public List<BoardModel>? BoardInfo { get; set; }
        public string? ProfileImg {get; set; }
        public bool? AccountCreated { get; set; }

        
        public string? joinDate { get; set; }

        public UserModel()
        {
            
        }
    }
