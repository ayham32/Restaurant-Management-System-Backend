using RestaurantBusiness.InterfaceServices;

namespace RestaurantDesktop
{
    public partial class Form1 : Form
    {
        private readonly ICustomersService customersService;
        public Form1(ICustomersService customersService)
        {

            InitializeComponent();
            this.customersService = customersService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var customers = customersService.GetCustomersAsync();
           
            dataGridView1.DataSource = customers;

        }
    }
}
