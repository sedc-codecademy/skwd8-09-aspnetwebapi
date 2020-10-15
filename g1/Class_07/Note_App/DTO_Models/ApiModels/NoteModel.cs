using Domain_Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_Models.ApiModels
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public TagType Tag { get; set; }
        public int UserId { get; set; }
    }
}
