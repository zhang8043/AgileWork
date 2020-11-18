namespace Agile.Abp.SettingManagement
{
    public class UpdateSettingsDto
    {
        public UpdateSettingDto[] Settings { get; set; }
        public UpdateSettingsDto()
        {
            Settings = new UpdateSettingDto[0];
        }
    }
}
