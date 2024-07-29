using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.Domain.Stores;

namespace Notes.WEB.Pages.Authorization
{
    public class LoginModel : PageModel
    {
        public INoteStore _NoteStore;

        public LoginModel(INoteStore noteStore)
        {
            _NoteStore = noteStore;
        }

        public void OnGet()
        {

        }
    }
}
