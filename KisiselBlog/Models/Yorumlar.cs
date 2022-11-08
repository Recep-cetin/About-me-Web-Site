using System;
using System.Collections.Generic;

#nullable disable

namespace KisiselBlog.Models
{
    public partial class Yorumlar
    {
        public int YorumId { get; set; }
        public string Yorum { get; set; }
        public DateTime? Eklenmetarihi { get; set; }
        public int? SayfaId { get; set; }
        public int? KulaniciId { get; set; }
        public bool? Aktif { get; set; }
        public bool? Silindi { get; set; }

        public virtual Kullanicilar Kulanici { get; set; }
        public virtual Sayfalar Sayfa { get; set; }
    }
}
