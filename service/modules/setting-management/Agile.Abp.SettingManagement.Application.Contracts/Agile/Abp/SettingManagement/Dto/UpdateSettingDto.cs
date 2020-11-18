using System.ComponentModel.DataAnnotations;
using Volo.Abp.SettingManagement;
using Volo.Abp.Validation;

namespace Agile.Abp.SettingManagement
{
    public class UpdateSettingDto
    {
        [Required]
        [DynamicStringLength(typeof(SettingConsts), nameof(SettingConsts.MaxNameLength))]
        public string Name { get; set; }

        [DynamicStringLength(typeof(SettingConsts), nameof(SettingConsts.MaxValueLength))]
        public string Value { get; set; }
    }
}
