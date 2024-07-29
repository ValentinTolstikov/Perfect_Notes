using Notes.Domain.Stores;
using Notes.Domain.Models;

namespace Notes.Servises
{
    public class NoteService
    {
        private INoteStore _noteRepository;

        public NoteService(INoteStore NoteRepository)
        {
            _noteRepository = NoteRepository;
        }

        public async Task Create(Note note)
        {
            await _noteRepository.Add(note);
        }
    }
}
