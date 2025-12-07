using System;
using System.ComponentModel.DataAnnotations; // Để dùng Required

namespace AweShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        // 🌟 Thông tin người dùng (Đã sửa để khớp với View Checkout) 🌟
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")] // Thêm validation email
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number Format")] // Đổi từ 'Phone' sang 'PhoneNumber'
        public string PhoneNumber { get; set; }

        // 🌟 Thông tin Shipping (Đã sửa để khớp với View Checkout) 🌟
        [Required(ErrorMessage = "Street Address is required")]
        public string StreetAddress { get; set; } // Đổi từ 'Address' sang 'StreetAddress'

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; } // Thiếu trường State trong Model cũ

        [Required(ErrorMessage = "Post Code is required")]
        public string PostCode { get; set; } // Thiếu trường PostCode trong Model cũ

        public string ExtraNote { get; set; } // Thiếu trường ExtraNote trong Model cũ

        // Ngày đặt hàng
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending"; // Mặc định là Pending (Chờ xử lý)
    }
}