using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace KisiselBlog.Models
{
    public partial class Kullanicilar
    {
        public Kullanicilar()
        {
            Iletisims = new HashSet<Iletisim>();
            Yorumlars = new HashSet<Yorumlar>();
        }

        public int KulaniciId { get; set; }

        [Display(Name = "Ad")]
        [MinLength(2, ErrorMessage = "En az iki karakter Girilmelidir")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter girilebilir")]
        public string Adi { get; set; }
        [MinLength(2, ErrorMessage = "En az iki karakter Girilmelidir")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter girilebilir")]
        public string Soyadi { get; set; }
        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir Eposta Giriniz")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter girilebilir")]
        public string Eposta { get; set; }
        [MaxLength(15, ErrorMessage = "En fazla 15 karakter girilebilir")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Lütfen Parolayı  giriniz")]
        public string Parola { get; set; }
        public bool? Yetki { get; set; }
        public bool? Aktif { get; set; }
        public bool? Silindi { get; set; }

       
        public virtual ICollection<Iletisim> Iletisims { get; set; }
        public virtual ICollection<Yorumlar> Yorumlars { get; set; }
    }
}
