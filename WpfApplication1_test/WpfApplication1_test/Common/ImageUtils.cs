using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1_test.Common
{
    /// <summary>  
    /// 画像ビューワのコモンディレクトリ画像取得用プログラム
    /// </summary>  
    public static class ImageUtils
    {
        /// <summary>  
        /// 指定したフォルダから、指定した拡張子のファイルを  
        /// ImageInfo型のリストにして返す。  
        /// </summary>  
        /// <param name="directory">ファイルを探すディレクトリへのパス</param>  
        /// <param name="supportExts">探す拡張子</param>  
        /// <returns>引数で指定した条件に合致する画像の情報</returns>  
        public static IList<ImageInfo> GetImages(string directory, string[] supportExts)
        {
            if (!Directory.Exists(directory))
            {
                // ディレクトリが無い時は空のリストを返す  
                return new List<ImageInfo>();
            }
            var dirInfo = new DirectoryInfo(directory);
            // ディレクトリからファイルを拡張子で絞り込んで返す  
            return dirInfo.GetFiles().
                Where(f => supportExts.Contains(f.Extension)).
                Select(f => new ImageInfo { Path = f.FullName }).
                ToList();
        }
    }

    /// <summary>  
    /// 画像に関する情報を持たせるクラス  
    /// </summary>  
    public class ImageInfo
    {
        /// <summary>  
        /// 画像ファイルへのパス  
        /// </summary>  
        public string Path { get; set; }
    }

}
