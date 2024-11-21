using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BIZ
{
    /// <summary>
    /// Interaction logic for UserControlPersonObject.xaml
    /// </summary>
    public partial class UserControlPersonObject : UserControl
    {
        private ClassCustomer _ClassCustomer;
        public UserControlPersonObject()
        {
            InitializeComponent();
            Customer = new ClassCustomer();
        }
        public UserControlPersonObject(ClassCustomer inCustomer)
        {
            InitializeComponent();
            Customer = new ClassCustomer(inCustomer);
        }


        public ClassCustomer Customer
        {
            get { return _ClassCustomer; }
            set { _ClassCustomer = value; }
        }

    }
}
