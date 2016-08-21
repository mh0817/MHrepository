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

namespace test_thumnail
{
    /// <summary>
    /// ViewerWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ViewerWindow : Window
    {
        public ViewerWindow()
        {
            InitializeComponent();
        }

        /// <summary>  
        /// このウィンドウに関連付けられたモデルを取得します。  
        /// </summary>  
        public ViewerWindowModel Model
        {
            get { return DataContext as ViewerWindowModel; }
        }

        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            // Modelに委譲する  
            this.Model.OpenDirectory();
        }
    }
}
