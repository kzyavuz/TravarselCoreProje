using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Areas.Admin.Models
{
    public class DestinationViewModel
    {
        public int DestinationID { get; set; }

        [MinLength(3, ErrorMessage = "Etkinlik adı en az 3 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Etkinlik adı en fazla 30 karakter olmalıdır.")]
        [Required(ErrorMessage = "Etkinlik adını giriniz.")]
        public string DestinationName { get; set; }

        [MinLength(6, ErrorMessage = "Sehir bilgisi en az 6 karakter olmalıdır.")]
        [MaxLength(14, ErrorMessage = "Sehir bilgisi en fazla 14 karakter olmalıdır.")]
        [Required(ErrorMessage = "Sehir bilgisini giriniz.")]
        public string City { get; set; }

        [MinLength(3, ErrorMessage = "İlçe bilgisi en az 3 karakter olmalıdır.")]
        [MaxLength(16, ErrorMessage = "İlçe bilgisi en fazla 16 karakter olmalıdır.")]
        [Required(ErrorMessage = "İlçe bilgisini giriniz.")]
        public string District { get; set; }

        public string DayNight { get; set; }

        [Required(ErrorMessage = "Etkinlik fiyat bilgisini giriniz.")]
        public int Price { get; set; }

        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile NewImageFile { get; set; }

        [MinLength(30, ErrorMessage = "Kısa tanıtım bilgisini en az 30 karakter olmalıdır.")]
        [MaxLength(100, ErrorMessage = "Kısa tanıtım bilgisini en fazla 100 karakter olmalıdır.")]
        [Required(ErrorMessage = "Kısa tanıtım bilgisini giriniz.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Kapasite bilgisini giriniz.")]
        public int Capacity { get; set; }

        [MinLength(500, ErrorMessage = "İçerik bilgisini en az 500 karakter olmalıdır.")]
        [Required(ErrorMessage = "İçerik bilgisini giriniz.")]
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public IFormFile Image1 { get; set; }
        public string Image1Url { get; set; }
        public IFormFile NewImage1File { get; set; }

        public IFormFile Image2 { get; set; }
        public string Image2Url { get; set; }
        public IFormFile NewImage2File { get; set; }

        public bool Status { get; set; }

        [Required(ErrorMessage = "Kategori adını seçiniz.")]
        public int CatagoryID { get; set; }

        [Required(ErrorMessage = "Rehber adını seçiniz.")]
        public int GuideID { get; set; }
    }
}
