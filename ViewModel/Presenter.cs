using System.Windows;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;
using bioImagechart.ViewModel;
using System;
namespace bioImagechart.ViewModel
{
    public class Presenter:ObservableObject 
    {
       public static int xlen;
       public static float[] averageIntensity;
        public static int count;
        IntPtr Iptr = IntPtr.Zero;

        public Presenter()           
        {
            int ht;
            if (count == 0)
            {
                Bitmap bmp = new Bitmap(@"P:\ImageProcessing\1.png");
                LockBitmap lockbitmap = new LockBitmap(bmp);
                lockbitmap.LockBits();
                xlen = lockbitmap.Width;
                int ylen = lockbitmap.Height;
               // MessageBox.Show(Convert.ToString(xlen));
               // MessageBox.Show(Convert.ToString(ylen));
                float[,] byteIntensity = new float[lockbitmap.Width, lockbitmap.Height];
                averageIntensity = new float[lockbitmap.Width];
               // MessageBox.Show("Success");
                // isIntensityCalculated = true;
                for (int wd = 60; wd < 1500; wd++)
                {
                    for (ht = 1500; ht < 2000; ht++) 
                    {
                        Color c = lockbitmap.GetPixel(wd, ht);
                        float f = c.GetBrightness();
                        byteIntensity[wd, ht] = f;
                        averageIntensity[wd] += f;
                    }
                    averageIntensity[wd] = averageIntensity[wd] / lockbitmap.Height;
                    // MessageBox.Show(Convert.ToString(averageIntensity[wd]));
                }
                count = 1;
                lockbitmap.UnlockBits();
            }           
        }
       
        public void verify_link()
        {
            MessageBox.Show("Working");
        }
        public string bioImage
        {
            get
            {
                return @"P:\ImageProcessing\1.png";
            }
        }



    }
}
