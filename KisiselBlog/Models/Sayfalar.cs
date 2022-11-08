using System;
using System.Collections.Generic;

#nullable disable

namespace KisiselBlog.Models
{
    public partial class Sayfalar
    {
        public Sayfalar()
        {
            Yorumlars = new HashSet<Yorumlar>();
        }

        public int SayfaId { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public bool? Aktif { get; set; }
        public bool? Silindi { get; set; }

        public virtual ICollection<Yorumlar> Yorumlars { get; set; }
    }
}
