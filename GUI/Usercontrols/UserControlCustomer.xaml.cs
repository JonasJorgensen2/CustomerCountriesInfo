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
using BIZ;
using Repository;
namespace GUI.Usercontrols
{
    /// <summary>
    /// Interaction logic for UserControlCustomer.xaml
    /// </summary>
    public partial class UserControlCustomer : UserControl
    {
        ClassBIZ BIZ;
        Grid MotherGrid;
        List<UserControlPersonObject> PersonList;
        public UserControlCustomer(ClassBIZ inBIZ, Grid motherGrid)
        {
            InitializeComponent();
            BIZ = inBIZ;
            MotherGrid = motherGrid;
            MainGrid.DataContext=BIZ;
            
        }
        /// <summary>
        /// En event listener til at kalde en usercontrol, som lader brugeren at oprette en ny kunde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOpret_Click(object sender, RoutedEventArgs e)
        {
            BIZ.FallbackCustomer = new ClassCustomer();
            MotherGrid.Children.Add(new UserControlEditCustomer(BIZ,MotherGrid));
        }
        /// <summary>
        /// En event listener til at kalde en usercontrol, som lader brugeren at redigere en eksiterene kunde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRediger_Click(object sender, RoutedEventArgs e)
        {
            if (BIZ.SelectedCustomer != null)
            {
                if (BIZ.SelectedCustomer.Customer.Id >0)
                {
                    BIZ.FallbackCustomer = new ClassCustomer(BIZ.SelectedCustomer.Customer);
                    MotherGrid.Children.Add(new UserControlEditCustomer(BIZ, MotherGrid));
                } 
            }
        }
        
    }
}
