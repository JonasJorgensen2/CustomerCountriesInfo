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
using Repository;
using BIZ;
namespace GUI.Usercontrols
{
    /// <summary>
    /// Interaction logic for UserControlCountry.xaml
    /// </summary>
    public partial class UserControlCountry : UserControl
    {
        ClassBIZ BIZ;
        public UserControlCountry(ClassBIZ inBIZ)
        {
            InitializeComponent();
            BIZ = inBIZ;
            MainGrid.DataContext = BIZ;
        }
    }
}
