using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerBackend.Models
{
    public class PostModel
    {
        public int ID { get; set; }
        public string? BoardID { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? DateCreated { get; set; }
        public int? AssigneeID { get; set; }
        public string? Status { get; set; }
        public string? PriorityLevel { get; set; }
        public List<CommentsModel>? Comments { get; set; }
        public bool IsDeleted { get; set; } = false;

        public PostModel(){
            
        }
    }
}