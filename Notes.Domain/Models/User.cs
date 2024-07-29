using System;
using System.Collections.Generic;

namespace Notes.Domain.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public string? Email { get; set; }

    public int Age { get; set; }

    public virtual ICollection<Note> Notes { get; } = new List<Note>();

    public virtual ICollection<Sticker> Stickers { get; } = new List<Sticker>();
}
