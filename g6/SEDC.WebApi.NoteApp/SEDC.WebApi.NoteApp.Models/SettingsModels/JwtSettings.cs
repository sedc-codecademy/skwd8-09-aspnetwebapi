namespace SEDC.WebApi.NoteApp.Models.SettingsModels
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpireDays { get; set; }
    }
}
