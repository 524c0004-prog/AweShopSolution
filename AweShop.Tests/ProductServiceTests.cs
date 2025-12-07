using Microsoft.VisualStudio.TestTools.UnitTesting;
using AweShop.BLL; // Gọi thư viện BLL

namespace AweShop.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        // Test Case 1: Kiểm tra giá trị âm hoặc bằng 0 (Biên dưới - Sai)
        [TestMethod]
        public void IsPriceValid_InputZero_ReturnsFalse()
        {
            // 1. Arrange (Chuẩn bị)
            ProductService service = new ProductService();
            decimal price = 0; // Giá trị biên

            // 2. Act (Thực hiện)
            bool result = service.IsPriceValid(price);

            // 3. Assert (Kiểm tra kết quả mong muốn)
            Assert.IsFalse(result, "Giá bằng 0 thì phải trả về False");
        }

        // Test Case 2: Kiểm tra giá trị hợp lệ (Vùng tương đương - Đúng)
        [TestMethod]
        public void IsPriceValid_InputNormalPrice_ReturnsTrue()
        {
            ProductService service = new ProductService();
            decimal price = 500; // Giá trị bình thường

            bool result = service.IsPriceValid(price);

            Assert.IsTrue(result, "Giá 500 thì phải trả về True");
        }

        // Test Case 3: Kiểm tra giá trị quá lớn (Biên trên - Sai)
        [TestMethod]
        public void IsPriceValid_InputTooHigh_ReturnsFalse()
        {
            ProductService service = new ProductService();
            decimal price = 1000000000; // 1 Tỷ (Biên trên)

            bool result = service.IsPriceValid(price);

            Assert.IsFalse(result, "Giá 1 tỷ thì phải trả về False");
        }
    }
}