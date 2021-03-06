using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHDML.Winforms.UI.Transactions.MultipleTransaction
{
    public partial class ItemOfMultipleTransaction : UserControl
    {
        public ItemOfMultipleTransaction()
        {
            InitializeComponent();
        }
        public decimal Price
        {
            get
            {
                return Convert.ToDecimal(pricelProductName.Text.Trim(' ', '₽'));
            }
        }
        public ItemOfMultipleTransaction(string productName, string price) : this()
        {
            productNameLabel.Text = productName;
            pricelProductName.Text = price + " ₽";
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Вызывается когда пользователь удаляет транзакцию из чека")]
        public EventHandler DeleteItemFromReceipt;

        [Browsable(true)]
        [Category("Action")]
        [Description("Вызывается когда пользователь изменяет транзакцию из чека")]
        public EventHandler ChangeItemFromReceipt;

        private void deleteTransactionButton_Click(object sender, EventArgs e)
        {
            if (this.DeleteItemFromReceipt != null)
            {
                this.DeleteItemFromReceipt(this, e);
            }
        }

        private void changeItemInfo_click(object sender, EventArgs e)
        {
            if (this.ChangeItemFromReceipt != null)
            {
                this.ChangeItemFromReceipt(this, e);
            }
        }
    }
}
