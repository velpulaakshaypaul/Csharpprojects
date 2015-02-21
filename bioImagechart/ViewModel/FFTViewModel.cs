using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;
using System.Threading;

namespace bioImagechart.ViewModel
{
   public class FFTViewModel
    {
          public Complex[] Samples;
          public FourierOptions option;
          chartlogic freqobject; 
          public void calculatefft()
        {
            freqobject = chartlogic.GetInstance();
           Transform.FourierForward(Samples);           
        //one thread for plotting frequency 
             // Thread FrewuencyPlot= new Thread(Threadstart)
          
              //another for plotting phase
     //  Samples[1].
          }
       public void plotFreqandPhase()
          {
              Thread frequencyThread = new Thread(() => freqobject.plotFFT(Samples, Samples.Length));
              Thread PhaseThread = new Thread(() => freqobject.plotPhase(Samples, Samples.Length));
              frequencyThread.Start();
              PhaseThread.Start();
              frequencyThread.Join();
              PhaseThread.Join();
          }

          
         

          
    }
}
