using System.ComponentModel.DataAnnotations;

namespace Agile.Abp.FileManagement
{
    public class FolderCopyDto
    {
        [Required]
        [StringLength(255)]
        public string CopyToPath { get; set; }
    }
}
