using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Windows.Forms;
using AweShop.BLL;   // Gọi tầng Logic
using AweShop.Models; // Gọi tầng Model

namespace AweShop.Desktop
{
    public partial class MainForm : Form
    {
        // Khởi tạo Service (Dùng chung logic với Web)
        private ProductService service = new ProductService();

        public MainForm()
        {
            InitializeComponent();
        }

        // 1. Khi Form vừa hiện lên thì tải dữ liệu ngay
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Hàm lấy dữ liệu từ Database đổ vào bảng
        private void LoadData()
        {
            try
            {
                // Gọi hàm GetAllProducts y hệt như bên Web Controller
                dgvProducts.DataSource = service.GetAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối Database: " + ex.Message);
            }
        }

        // Nút Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // Nút Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Hiện lại form đăng nhập
           // LoginForm login = new LoginForm();
           // login.Show();
            this.Close();
        }

        // Nút Xóa (Delete)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Lấy ID của dòng đang chọn
                int id = int.Parse(dgvProducts.SelectedRows[0].Cells["Id"].Value.ToString());

                DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xóa ID: " + id + "?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    service.Delete(id); // Gọi Service để xóa
                    LoadData(); // Tải lại bảng
                    MessageBox.Show("Đã xóa thành công!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        // Nút Thêm (Add) - Để tạm đó, làm sau
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm();
            form.ProductId = null; // Không có ID -> Là thêm mới

            // Hiện form lên và chờ kết quả
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Tải lại bảng sau khi thêm xong
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có chọn dòng nào chưa
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Lấy ID của dòng đang chọn
                int id = int.Parse(dgvProducts.SelectedRows[0].Cells["Id"].Value.ToString());

                ProductForm form = new ProductForm();
                form.ProductId = id; // Truyền ID sang -> Là sửa

                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Tải lại bảng sau khi sửa xong
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!");
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.ShowDialog(); // Hiện form đơn hàng lên
        }
    }
}