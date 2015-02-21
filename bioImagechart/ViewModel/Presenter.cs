using System.Windows;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;
using bioImagechart.ViewModel;
using System;
using System.Threading;
using System.Numerics;
using MathNet.Numerics.IntegralTransforms;
using Abt.Controls.SciChart.Model.DataSeries;
using Abt.Controls.SciChart.Utility;
using Abt.Controls.SciChart.Visuals;
using Abt.Controls.SciChart.Rendering;
namespace bioImagechart.ViewModel
{
    public class Intensitycalculator//class to calculate average intensity
    {
        public void brightness(int width,int width_max, LockBitmap lockbitmap )
        {
            for (int wd = width; wd < width_max; wd++)
            {
                for (int ht = 1500; ht < 2000; ht++)
                {
                    Color c = lockbitmap.GetPixel(wd, ht);
                    float f = c.GetBrightness();
                   // obj.byteIntensity[wd, ht] = f;
                    Presenter.averageIntensity[wd] += f;
                }
                 Presenter.averageIntensity[wd] = Presenter.averageIntensity[wd] / lockbitmap.Height; 
                 Presenter.fftData[wd] = Presenter.averageIntensity[wd];
             //    MessageBox.Show(Convert.ToString(Presenter.averageIntensity[wd]));
            }
        }
    }

    public class ViewUpdater
    {
        Presenter obj = new Presenter();
        public void starttimer()
        { 

             DispatcherTimer dispatcherTimer = new DispatcherTimer();
             dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick); 
             dispatcherTimer.Interval = new TimeSpan(0, 0, 0,0,20); 
             dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
    {      
       obj.StartCalculation();
    } 
    }
    public class Presenter:ObservableObject
    {     
        Intensitycalculator IntensityThread = new Intensitycalculator();//class that contain function to calculate intensity
       // ViewUpdater timer = new ViewUpdater();
        public static bool hasIntensityStartedExecution=false;
        public static bool hasfrequencyStartedExecution = false;
        public static bool hasphaseStartedExecution = false;
        public static int xlen;
        public static Complex[] fftData;
        public static float[] averageIntensity;
        public static int count;
        public float[,] byteIntensity;
        public string _bioImage;      
        chartlogic presernterchartlogic = chartlogic.GetInstance();
        FFTViewModel fftLogic = new FFTViewModel();
        Thread []threadarray = new Thread[20];//creating 20 threads
       // Complex []fftData;
        public Presenter()           
        {
          //  StartCalculation();

            _bioImage = @"P:\ImageProcessing\1.png";
        }
        public void StartCalculation()
        {          
            DateTime start;
            TimeSpan time;
            start = DateTime.Now;
            Bitmap bmp;
            averageIntensity = new float[xlen];
      //      MessageBox.Show(Convert.ToString(count));
            if (count == 0)
            {               
                bmp = new Bitmap(@"P:\ImageProcessing\1.png");
           }
           else if(count==1)
            {
                bmp = new Bitmap( @"P:\ImageProcessing\2.png");
            }
            else if (count == 2)
            {
                bmp = new Bitmap(@"P:\ImageProcessing\3.png");
            }
            else if (count == 3)
            {
                bmp = new Bitmap(@"P:\ImageProcessing\4.png");
            }
            else if (count == 4)
            {
                bmp = new Bitmap(@"P:\ImageProcessing\5.png");
            }
            else if (count == 5)
            {
                bmp = new Bitmap(@"P:\ImageProcessing\6.png");
            }
            else if (count == 6)
            {
                bmp = new Bitmap(@"P:\ImageProcessing\7.png");
            }
            else if (count == 7)
            {
                bmp = new Bitmap(@"P:\ImageProcessing\8.png");
            }
            else if (count == 8)
            {
                bmp = new Bitmap(@"P:\ImageProcessing\9.png");
            }
            else 
            {
                bmp = new Bitmap(@"P:\ImageProcessing\10.png");
                count = 0;
            }
            
          
            LockBitmap lockbitmap = new LockBitmap(bmp);
                lockbitmap.LockBits();
                xlen = lockbitmap.Width;
                fftData = new Complex[xlen];
               int ylen = lockbitmap.Height;
                averageIntensity = new float[xlen];           
            //create 20 threads
              //  MessageBox.Show(Convert.ToString(xlen));
                for (int i = 0; i < 20; i++)
                {
                    int threadNumber = i;
                    threadarray[threadNumber] = new Thread(() => IntensityThread.brightness(60 + threadNumber * 72, 60 + threadNumber * 72 + 72, lockbitmap));
                }
                for (int i = 0; i < 20; i++)
                {
                    int threadNumber = i;
                    threadarray[threadNumber].Start();
                }
                for (int i = 0; i < 20; i++)
                {
                    int threadNumber = i;
                    threadarray[threadNumber].Join();
                }

                time = DateTime.Now - start;
                //   MessageBox.Show(time.Milliseconds.ToString().PadLeft(4, '0'));
                count ++;
                lockbitmap.UnlockBits();
           
            fftLogic.Samples = fftData;
            fftLogic.option = FourierOptions.Default;
            Thread chartViewThread = new Thread(new ThreadStart(presernterchartlogic.plotData));
            Thread fftCalculation = new Thread(new ThreadStart(fftLogic.calculatefft));
            chartViewThread.Start();
            fftCalculation.Start();            
            chartViewThread.Join();
            fftCalculation.Join();
            Thread plotFreqandPhase=new Thread((new ThreadStart(fftLogic.plotFreqandPhase )));
            plotFreqandPhase.Start();
            plotFreqandPhase.Join();


        }   
      
        public string bioImage
        {
            get
            {
                return _bioImage;
            }
            set
            {
                if(value!=null)
                {
                    _bioImage = value;
                    RaisePropertyChangedEvent("bioImage");
                }
            }
        }
        public void updateImage()
        {
            if (count == 1)
            {
                bioImage = @"P:\ImageProcessing\11.png";
                StartCalculation();
                count = 0;
            }
            else
            {
                bioImage = @"P:\ImageProcessing\1.png";
                StartCalculation();
            }
        }
            private void timer1_Tick(object sender, EventArgs e)
{
    MessageBox.Show("Hello world");
}
        



    }
   
}
