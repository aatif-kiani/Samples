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
using Java.Interop;

namespace SpotsDialogLib.lib
{
    class AnimatedView : View
    {
        private int target;

        public AnimatedView(Context context) : base(context)
        {
        }

        [Export]
        public float getXFactor()
        {
            return GetX() / target;
        }

        [Export]
        public void setXFactor(float xFactor)
        {
            SetX(target * xFactor);
        }

        [Export]
        public void setTarget(int target)
        {
            this.target = target;
        }

        [Export]
        public int getTarget()
        {
            return target;
        }
    }
}