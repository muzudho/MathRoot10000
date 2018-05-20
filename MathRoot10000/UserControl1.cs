using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace MathRoot1000
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画像を作成して保存
        /// 
        /// 参考Webサイト
        /// 2012/7/31「プログラムで画像を動的に作成する」dobon.net
        /// https://dobon.net/vb/dotnet/graphics/createimage.html
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1024x1024サイズのImageオブジェクトを作成する
            Bitmap img = new Bitmap((int)(1024*3.25), (int)(1024 * 3.25));

            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(img);

            Font numberFont = new Font("ＭＳ ゴシック", 8.0f);
            Font rootFont = new Font("ＭＳ ゴシック", 6.0f);
            float marginX = 32.0f;
            float marginY = 32.0f;

            // 1万升
            for (int y = 0; y < 100; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    // 元の数
                    int source = (99 - y) * 100 + (x + 1);
                    // "{0,5}"
                    g.DrawString( String.Format("{0}", source), numberFont, Brushes.Gray, 32.0f * x + marginX, 32.0f * y + marginY);
                    // ルート
                    double root = Math.Sqrt(source);
                    g.DrawString(String.Format("{0:.##}", root), rootFont, Brushes.Black, 32.0f * x + marginX, 32.0f * y + marginY + 12.0f);
                }
            }


            //リソースを解放する
            g.Dispose();

            img.Save(@"math_root10000.png", ImageFormat.Png);
        }
    }
}
