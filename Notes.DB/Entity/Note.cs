using System;
using System.Collections.Generic;

namespace Notes.DB.Entity;

public partial class Note
{
    public int IdNote { get; set; }

    public int IdOwner { get; set; }

    public DateTime DateCreate { get; set; }

    public DateTime DateChange { get; set; }

    public bool Complete { get; set; }

    public bool HasStickers { get; set; }

    public string Text { get; set; } = null!;

    public DateTime TargetDate { get; set; }

    public virtual User IdOwnerNavigation { get; set; } = null!;
}
