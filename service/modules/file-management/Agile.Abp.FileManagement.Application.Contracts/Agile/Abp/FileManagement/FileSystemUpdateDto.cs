using System.ComponentModel.DataAnnotations;

namespace Agile.Abp.FileManagement
{
    public class FileSystemUpdateDto
    {
        [Required]
        [StringLength(255)]
        public string NewName { get; set; }
    }
}
