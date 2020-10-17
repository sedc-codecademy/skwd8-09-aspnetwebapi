using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_Models.SettingsModels
{
    public class JwtSettings
    {
        public string Seacret { get; set; }
        public int ExpireDays { get; set; }
    }
}
