
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

namespace bioImagechart.ViewModel
{
    public class chartlogic:Presenter
    {
        private IDataSeries _chartData;
        public IDataSeries ChartData
        {
            get { return _chartData; }
            set
            {
                _chartData = value;
             //   RaisePropertyChangedEvent("ChartData");
            }
        }
        public chartlogic()
        {
            var ds0 = new XyDataSeries<double, double>();
            for (int i = 0; i < xlen; i++)
            {
                ds0.Append(i,averageIntensity[i]);
            }
            _chartData = ds0;
        }

    }
}