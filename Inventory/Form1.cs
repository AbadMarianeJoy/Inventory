using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Inventory
{
    
    public partial class frmAddProduct : Form
    {
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private int _Quantity;
        private double _SellPrice;
        private BindingSource showProductList = new BindingSource();

        public frmAddProduct()
        {
            InitializeComponent();
            MessageBox.Show("Hello welcome to \n our Inventory Form :) ");           
            string[] ListOfProductCategory = { "Beverages", "Bread/Bakery", "Canned/Jarred Goods", "Dairy", "Frozen Goods", "Meat", "Personal Care", "Other" };
            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }
        }

                 
        private string Product_Name(string StringOnly)
        {
            if (!Regex.IsMatch(StringOnly, @"^[a-zA-Z\s]+$")) 
                throw new StringOnly("Product name should contain only letters and spaces.");
            return StringOnly;
        }

        private int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]+$"))
                throw new NumberOnly("Quantity should be a whole number. \n Only numbers Acceptable here");
            return Convert.ToInt32(qty);
        }

        private double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price, @"^(\d*\.)?\d+$"))
                throw new CurrencyPeso("Selling price should be a valid decimal number.");
            return Convert.ToDouble(price);
        }

       
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);

              
              var product = new ProductClass(_ProductName, _Category, _MfgDate, _ExpDate, _SellPrice, _Quantity, _Description);
                showProductList.Add(product);

              
                gridViewProductList.AutoGenerateColumns = true; 
                gridViewProductList.DataSource = null; 
                gridViewProductList.DataSource = showProductList; 
                gridViewProductList.Refresh(); 


                
            }
            catch (StringOnly ex)
            {
                MessageBox.Show(ex.Message, "Letters only here");
            }
            catch (NumberOnly ex)
            {
                MessageBox.Show(ex.Message, "Only numbers Acceptable here");
            }
            catch (CurrencyPeso ex)
            {
                MessageBox.Show(ex.Message, "Currency must be Peso");
            }

            
        }
    }

    
    public class StringOnly: Exception
    {
        public StringOnly(string message) : base(message) { }
    }

    public class NumberOnly : Exception
    {
        public NumberOnly (string message) : base(message) { }
    }

    public class CurrencyPeso : Exception
    {
        public CurrencyPeso(string message) : base(message) { }
    }

    
    public class ProductClass
    {
        private int _Quantity;
        private double _SellingPrice;
        private string _ProductName, _Category, _ManufacturingDate, _ExpirationDate, _Description;

        public ProductClass(string ProductName, string Category, string MfgDate, string ExpDate, double Price, int Quantity, string Description)
        {
            this._ProductName = ProductName;
            this._Category = Category;
            this._ManufacturingDate = MfgDate;
            this._ExpirationDate = ExpDate;
            this._SellingPrice = Price;
            this._Quantity = Quantity;
            this._Description = Description;
        }
        public string productName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this._ProductName = value;
            }
        }
        public string category
        {
            get
            {
                return this._Category;
            }
            set
            {
                this._Category = value;
            }
        }
        public string manufacturingDate
        {
            get
            {
                return this._ManufacturingDate;
            }
            set
            {
                this._ManufacturingDate = value;
            }
        }
        public string expiratonDate
        {
            get
            {
                return this._ExpirationDate;
            }
            set
            {
                this._ExpirationDate = value;
            }
        }
        public string description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }
        public int quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this._Quantity = value;
            }
        }
        public double sellingPrice
        {
            get
            {
                return this._SellingPrice;
            }
            set
            {
                this._SellingPrice = value;
            }
        }
    }
}
