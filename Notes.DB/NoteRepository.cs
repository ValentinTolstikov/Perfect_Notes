using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Domain.Models;
using Notes.Domain.Stores;

namespace Notes.DB
{
    public class NoteRepository : INoteStore
    {
        public NotesDbContext _context;

        public NoteRepository()
        {
            _context = new NotesDbContext();
        }

        public Task Add(Note note)
        {
            return _context.Notes.AddAsync(note).AsTask();
        }

        public Task Delete(int id)
        {
            Note delete_note = _context.Notes.Find(id);

            if (delete_note == null)
            {
                throw new Exception();
            }

            _context.Notes.Remove(delete_note);
            return _context.SaveChangesAsync();
        }

        public Task<Note[]> GetAllByUserId(int user_id)
        {
            return _context.Notes.Where(note => note.IdOwner == user_id).ToArrayAsync();
        }

        public Task Update(Note note)
        {
            _context.Notes.Update(note);
            return _context.SaveChangesAsync();
        }
    }
}
