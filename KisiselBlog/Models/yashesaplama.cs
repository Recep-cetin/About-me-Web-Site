using System;
using System.ComponentModel.DataAnnotations;
using KisiselBlog.Models;

namespace KisiselBlog.Models
{
	public class yashesaplama
	{
		[Display(Name = "Ad")]
		[MinLength(2, ErrorMessage = "En az iki karakter Girilmelidir")]
		[MaxLength(50, ErrorMessage = "En fazla 50 karakter girilebilir")]
		public string adi { get; set; }
		[MinLength(2, ErrorMessage = "En az iki karakter Girilmelidir")]
		[MaxLength(50, ErrorMessage = "En fazla 50 karakter girilebilir")]
		public string soyadi { get; set; }
		[MinLength(2, ErrorMessage = "En az iki karakter Girilmelidir")]
		[MaxLength(50, ErrorMessage = "En fazla 50 karakter girilebilir")]
		public string meslek { get; set; }
		[EmailAddress(ErrorMessage = "Lütfen Geçerli Bir Eposta Giriniz")]
		[MaxLength(100, ErrorMessage = "En fazla 100 karakter girilebilir")]
		public string email { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime dogum_tarihi { get; set; }
	}
}
