using System.ComponentModel.DataAnnotations;

namespace EFCoreMysql.Models.Request
{
    public class CreateProjectRequest
    {
        [Required]
        public string ProjectName { get; }
        
        public string ProjectDescription { get; }

    }
    
}
