using System.ComponentModel.DataAnnotations;

namespace Agile.Abp.FileManagement
{
    public class FolderCreateDto
    {
        [Required]
        [StringLength(255)]
        public string Path { get; set; }

        public string Parent { get; set; }
    }
}
