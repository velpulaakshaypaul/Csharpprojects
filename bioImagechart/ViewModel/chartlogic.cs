
﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using bioImagechart;
using Abt.Controls.SciChart;
using System;
using System.Diagnostics;
using System.Windows;
using Abt.Controls.SciChart.Model.DataSeries;
using Abt.Controls.SciChart.Utility;
using Abt.Controls.SciChart.Visuals;
using Abt.Controls.SciChart.Rendering;
using bioImagechart.ViewModel;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;

namespace bioImagechart.ViewModel
{
   public class chartlogic:ObservableObject
    {
       private static chartlogic _instance = new chartlogic();       
       private chartlogic()
       {
       }
       public static chartlogic GetInstance()
       {
           return _instance;
       }
       private IDataSeries _IntensityData;
        private IDataSeries _FFTData;
        private IDataSeries _PhaseData;
       // Presenter calc = new Presenter();
         public  IDataSeries IntensitytData
        {
            get { return _IntensityData; }
            set
            {
                _IntensityData = value;
                RaisePropertyChangedEvent("IntensitytData");
            }
        }
        public IDataSeries FFTData
        {
            get { return _FFTData; }
            set
            {
                _FFTData = value;
                RaisePropertyChangedEvent("FFTData");
                // FFTds0.Append(i, Samples[i].Magnitude);   RaisePropertyChangedEvent("ChartData");
            }
        }
         public IDataSeries PhaseData
        {
            get { return _PhaseData;}
            set {
                _PhaseData = value;
                RaisePropertyChangedEvent("PhaseData");
                //   RaisePropertyChangedEvent("ChartData");
            }
        }
       public XyDataSeries<double, double> ds0 = new XyDataSeries<double, double>();
        public void plotData()
        {
           // Complex[] c1;

         

            if (Presenter.hasIntensityStartedExecution == false)
            {
                for (int i = 0; i < Presenter.xlen; i++)
                {
                    ds0.Append(i, Presenter.averageIntensity[i]);
                }
               IntensitytData = ds0;
               Presenter.hasIntensityStartedExecution = true;    
             //   ds0.Clear();
           }
            else
            {
                for (int i = 0; i < Presenter.xlen; i++)
                {
                    ds0.Update(i, Presenter.averageIntensity[i]);
                }
                IntensitytData = ds0;
            }
          //  ds0.Clear();
     
        }
        public XyDataSeries<double, double> FFTds0 = new XyDataSeries<double, double>();
        public  void plotFFT(Complex[] Samples,int length)
        {
           // MessageBox.Show(Convert.ToString(Presenter.count));
            if (Presenter.hasfrequencyStartedExecution == false)
            {
                for (int i = 0; i < length; i++)
                {
                    FFTds0.Append(i, Samples[i].Magnitude);
                    //  ds0.Update(i,Samples[i].Magnitude);
                    // ds0.Update(i, 0.5);
                }
                FFTData = FFTds0;
                Presenter.hasfrequencyStartedExecution = true;
            }
            else
            {
                for (int i = 0; i < Presenter.xlen; i++)
                {
                    FFTds0.Update(i, Samples[i].Magnitude);
                }
                FFTData = FFTds0;
            }
        
        }



        public XyDataSeries<double, double> Phaseds0 = new XyDataSeries<double, double>();
        public  void plotPhase(Complex[] Samples, int length)
        {
          //  var Phaseds0 = new XyDataSeries<double, double>();

            if (Presenter.hasphaseStartedExecution == false)
            {
                for (int i = 0; i < length; i++)
                {
                    Phaseds0.Append(i, Samples[i].Phase);
                }
                PhaseData = Phaseds0;
                Presenter.hasphaseStartedExecution = true;
            }
            else
            {
                for (int i = 0; i < Presenter.xlen; i++)
                {
                    Phaseds0.Update(i, Samples[i].Phase);
                }
                PhaseData = Phaseds0;
            }

        }

    }
}