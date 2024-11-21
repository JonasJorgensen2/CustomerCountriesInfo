using BIZ;
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

namespace GUI.Usercontrols
{
    /// <summary>
    /// Interaction logic for UserControlEditCustomer.xaml
    /// </summary>
    public partial class UserControlEditCustomer : UserControl
    {
        ClassBIZ BIZ;
        Grid MotherGrid;

        public UserControlEditCustomer(ClassBIZ inBIZ, Grid motherGrid)
        {
            InitializeComponent();
            BIZ = inBIZ;
            MotherGrid = motherGrid;
            MainGrid.DataContext=BIZ;
        }
        /// <summary>
        /// En event listener til at excekvere metoder, som kan oprette en ny kunde til databasen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOpret_Click(object sender, RoutedEventArgs e)
        {
            if (BIZ.FallbackCustomer.name.Length!= 0 && BIZ.FallbackCustomer.address.Length!=0 && BIZ.FallbackCustomer.city.Length != 0 && BIZ.FallbackCustomer.postalCode.Length != 0 && BIZ.FallbackCustomer.country.Id != 0 && BIZ.FallbackCustomer.phone.Length != 0 && BIZ.FallbackCustomer.mailAdr.Length != 0)
            {
                BIZ.InsertOrUpdateCustomerinDB();
                MotherGrid.Children.Remove(this);
            }
        }
        /// <summary>
        /// En event listener  til at få barnet til at dræbe demselv. Aka Fortrydning.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFortryd_Click(object sender, RoutedEventArgs e)
        {
            MotherGrid.Children.Remove(this);
        }
    }
}
