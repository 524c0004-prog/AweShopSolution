using System;
using System.Windows.Forms;
using AweShop.BLL;
using AweShop.Models;

namespace AweShop.Desktop
{
    public partial class ProductForm : Form
    {
        private ProductService service = new ProductService();
        public int? ProductId { get; set; } // Biến để lưu ID (nếu là Sửa)

        public ProductForm()
        {
            InitializeComponent();
        }

        // Khi Form hiện lên
        private void ProductForm_Load(object sender, EventArgs e)
        {
            // Nếu có ID (tức là đang Sửa), thì điền dữ liệu cũ vào ô
            if (ProductId.HasValue)
            {
                var p = service.GetById(ProductId.Value);
                if (p != null)
                {
                    txtName.Text = p.Name;
                    txtCategory.Text = p.Category;
                    txtPrice.Text = p.Price.ToString();
                    txtImage.Text = p.ImageUrl;
                }
            }
        }

        // Nút Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Tạo đối tượng Product từ dữ liệu nhập
                Product p = new Product();
                p.Name = txtName.Text;
                p.Category = txtCategory.Text;
                p.Price = decimal.Parse(txtPrice.Text); // Nhớ nhập số nhé, nhập chữ là lỗi đó
                p.ImageUrl = txtImage.Text;
                
                // 2. Kiểm tra xem là Thêm hay Sửa
                if (ProductId.HasValue) 
                {
                    // --- Đang SỬA ---
                    p.Id = ProductId.Value; // Gán ID cũ để nó biết đường update
                    service.Update(p);
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    // --- Đang THÊM MỚI ---
                    service.Create(p);
                    MessageBox.Show("Thêm mới thành công!");
                }

                // Đóng form và báo cho MainForm biết là OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}