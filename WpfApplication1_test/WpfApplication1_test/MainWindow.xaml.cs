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
using System.ComponentModel;
using WpfApplication1_test.Common;

namespace WpfApplication1_test
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage m_bitmap = null;    // 読み込んだ画像用

        public MainWindow()
        {

            InitializeComponent();
            // カレントディレクトリを取得する
            string stCurrentDir = System.IO.Directory.GetCurrentDirectory();

            string file_number = "\0001";

            string filename = stCurrentDir + file_number;

            // BitmapImageにファイルから画像を読み込む
            m_bitmap = new BitmapImage();
            m_bitmap.BeginInit();
            m_bitmap.UriSource = new Uri(filename);
            m_bitmap.EndInit();
            // Imageコントロールに表示
            image1.Source = m_bitmap;
        }

//        static string File_name(string file_path)
//        {
//            string stCurrentDir = System.IO.Directory.GetCurrentDirectory();

//            string file_name = ;

//            string filename = stCurrentDir + Int32.Parse(file_number);

//            return ();
//        }



        //メニュー　- 開く
        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            string stCurrentDir = System.IO.Directory.GetCurrentDirectory();

            string file_number = "\0002";

            string filename = stCurrentDir + file_number;
            // BitmapImageにファイルから画像を読み込む
            m_bitmap = new BitmapImage();
            m_bitmap.BeginInit();
            m_bitmap.UriSource = new Uri(filename);
            m_bitmap.EndInit();
            // Imageコントロールに表示
            image1.Source = m_bitmap;
        }
        // メニュー - 終了
        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            // ファイルを開くダイアログ
            Microsoft.Win32.OpenFileDialog dlg =
                new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPEG|*.jpg|JPEG, PNG|*jpg;*.png|BMP|*.bmp";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;

                // 既に読み込まれていたら解放する
                if (m_bitmap != null)
                {
                    m_bitmap = null;
                }
                // BitmapImageにファイルから画像を読み込む
                m_bitmap = new BitmapImage();
                m_bitmap.BeginInit();
                m_bitmap.UriSource = new Uri(filename);
                m_bitmap.EndInit();
                // Imageコントロールに表示
                image1.Source = m_bitmap;
            }
        }
    }

    /// <summary>  
    /// ViewerWindowのモデルクラス  
    /// </summary>  
    public partial class ViewerWindowModel : INotifyPropertyChanged
    {
        #region コンストラクタ  
        public ViewerWindowModel()
        {
            // OnPropertyChangedでnullチェックするのがめんどいので  
            // 空の処理をあらかじめ１つ追加しておく。  
            PropertyChanged += (sender, e) => { };
        }
        #endregion

        #region INotifyPropertyChanged メンバ  

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region プロパティ  
        private IList<ImageInfo> _images;
        /// <summary>  
        /// ビューワーで表示する画像の情報を取得または設定します。  
        /// </summary>  
        public IList<ImageInfo> Images
        {
            get
            {
                return _images;
            }
            set
            {
                _images = value;
                OnPropertyChanged("Images");
            }
        }
        #endregion
    }



}
