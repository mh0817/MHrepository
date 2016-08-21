using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using test_thumnail.common;

namespace test_thumnail
{
    /// <summary>  
    /// ViewerWindowのモデルクラス  
    /// </summary>  
    public class ViewerWindowModel : INotifyPropertyChanged
    {
        #region コンストラクタ  
        public ViewerWindowModel()
        {
            // OnPropertyChangedでnullチェックするのがめんどいので  
            // 空の処理をあらかじめ１つ追加しておく。  
            PropertyChanged += (sender, e) => { };
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

        #region 公開メソッド  
        public void OpenDirectory()
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    // OK以外は何もしない  
                    return;
                }
                // Imagesプロパティを、選択された画像のリストに更新する  
                this.Images = ImageUtils.GetImages(
                    dialog.SelectedPath, App.Current.SupportExts);
            }
        }
        #endregion

        #region INotifyPropertyChanged メンバ  

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
