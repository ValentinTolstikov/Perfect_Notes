using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Domain.Models;

namespace Notes.Domain.Stores
{
    public interface INoteStore
    {
        Task Add(Note note);
        Task Update(Note note);
        Task Delete(int id);
        Task<Note[]> GetAllByUserId(int user_id);
    }
}
