using System;
using System.Collections.Generic;

#nullable disable

namespace KisiselBlog.Models
{
    public partial class Iletisim
    {
        public int IletisimId { get; set; }
        public string Adres { get; set; }
        public DateTime? Eklenmetarihi { get; set; }
        public int? KulaniciId { get; set; }
        public bool? Aktif { get; set; }
        public bool? Silindi { get; set; }

        public virtual Kullanicilar Kulanici { get; set; }
    }
}
