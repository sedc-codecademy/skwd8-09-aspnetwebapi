using StickyNotes.PresentationLayer.Responses;
using System.Collections.Generic;

namespace StickyNotes.Services.Services.Interfaces
{
    public interface INoteService
    {
        List<GetNoteResponse> GetAllNotes();
        List<GetNoteResponse> GetAllNotesByUserId(int userId);
        List<GetNoteResponse> GetAllNotesByColor(int color);
        GetNoteResponse GetNoteById(int noteId,int userId);
        void AddANoteToAUser(GetNoteResponse note, int userId);
        void UpdateNoteToAUser(GetNoteResponse note,int userid);
        void DeleteNoteFromAUser(int noteId, int userid);

    }
}
