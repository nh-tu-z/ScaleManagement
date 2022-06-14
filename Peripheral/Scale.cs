using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// for debugging
using System.Diagnostics;

namespace scale.Peripheral
{
    // This container defines the scale. It is XK3190-D10 
    // (References: https://candientuhanoi.com.vn/wp-content/uploads/2016/10/Manual_D10-Chi-Anh-Scales.pdf)
    // TODO - because there just has one scale so far, I haven't used the base class for general definition. 
    // In the future, there might have more types of scale or other peripherals. So at that time, we have to
    // refractor the code i.e write the base class for general definition, etc...
    class Scale
    {
        /*
            - There are 2 modes to communicate with PC:
                + Continuously send (TF set as 0).
                + Command mode (TF as 1).

            - This indicator can be conneted to loadcell (through 9-pin connector), 
            PC or ScoreBoard (15-pin connector).

            - Loadcell and ScoreBoard is not implemented right now.
         */ 
        enum ScaleMode
        {
            NA_,
            ContinuouslySend_,
            Command_
        }

        // continuously send - the indicator sends one frame (12 groups) data to PC.
        // this helper function is used to convert 1 frame data to weigh in float type
        public void frameToWeigh(byte[] frame)
        {
            // debug -  check for input
            Trace.WriteLine($"Scale - frameToWeigh() - Input param: {string.Join(" ", frame)}");

            // weighing data is from frame[3] to frame[7]
            string weighingData = string.Empty;
            byte[] weightInBytes = new byte[] { frame[2], frame[3], frame[4], frame[5], frame[6], frame[7] };
            weighingData += Encoding.Default.GetString(weightInBytes);

            // debug - check convert to weight
            Trace.WriteLine($"Scale - frameToWeigh() - Weight: {weighingData}");
        }
    }
}
