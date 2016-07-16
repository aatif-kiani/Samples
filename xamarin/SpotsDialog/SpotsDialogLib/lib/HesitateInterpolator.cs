using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Views.Animations;

namespace SpotsDialogLib.lib
{
    class HesitateInterpolator : Java.Lang.Object, IInterpolator
    {
        private static double POW = 1.0 / 2.0;
        
        public float GetInterpolation(float input)
        {
            return input < 0.5
                    ? (float)Math.Pow(input * 2, POW) * 0.5f
                    : (float)Math.Pow((1 - input) * 2, POW) * -0.5f + 1;
        }
    }
}