using System;
using System.Collections.Generic;

namespace Notes.DB.Entity;

public partial class Sticker
{
    public int IdSticker { get; set; }

    public byte[] Img { get; set; } = null!;

    public int IdUser { get; set; }

    public byte[] StickerName { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
