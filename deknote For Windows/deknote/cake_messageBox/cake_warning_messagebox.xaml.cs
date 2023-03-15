using Newtonsoft.Json.Linq;
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
using System.Windows.Shapes;

namespace deknote.cake_messageBox
{
    /// <summary>
    /// Interaction logic for cake_warning_messagebox.xaml
    /// </summary>
    public partial class cake_warning_messagebox : Window
    {
        public string cakemessage { get; set; }
        public cake_warning_messagebox()
        {
            InitializeComponent();
        }
        protected override void OnContentRendered(EventArgs e){
            base.OnContentRendered(e);
            cakeiron.Content = cakemessage;
        }

        private void cake_ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
