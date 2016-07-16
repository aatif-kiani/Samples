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

namespace SpotsDialogLib.lib
{
    class AnimatedView : View
    {
        private int target;

        public AnimatedView(Context context) : base(context)
        {
        }

        public float getXFactor()
        {
            return GetX() / target;
        }

        public void setXFactor(float xFactor)
        {
            SetX(target * xFactor);
        }

        public void setTarget(int target)
        {
            this.target = target;
        }

        public int getTarget()
        {
            return target;
        }
    }
}