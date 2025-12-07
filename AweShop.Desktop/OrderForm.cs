using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Windows.Forms;
using AweShop.BLL;
using AweShop.Models;

namespace AweShop.Desktop
{
    public partial class OrderForm : Form
    {
        private OrderService service = new OrderService();

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                // Lấy danh sách đơn hàng từ Database
                dgvOrders.DataSource = service.GetAllOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải đơn hàng: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        // Nút xử lý đơn hàng (Chuyển sang Shipped)
        private void btnShip_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = int.Parse(dgvOrders.SelectedRows[0].Cells["Id"].Value.ToString());

                DialogResult result = MessageBox.Show("Xác nhận giao đơn hàng #" + orderId + "?", "Confirm", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Gọi hàm vừa viết xong
                    service.UpdateStatus(orderId, "Shipped");

                    MessageBox.Show("Đã cập nhật trạng thái thành Shipped!");
                    LoadOrders(); // Tải lại bảng để thấy trạng thái mới
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn hàng!");
            }
        }
    }
}