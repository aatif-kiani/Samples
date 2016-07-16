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
using Android.Util;
using Android.Annotation;
using Android.Content.Res;

namespace SpotsDialogLib.lib
{
    class ProgressLayout : FrameLayout
    {
        private int spotsCount;
        private static int DEFAULT_COUNT = 5;

        public ProgressLayout(Context context) : this( context, null )
        {
        }

        public ProgressLayout(Context context, IAttributeSet attrs) : this( context, attrs, 0 )
        {
        }

        public ProgressLayout(Context context, IAttributeSet attrs, int defStyleAttr) : base( context, attrs, defStyleAttr )
        {
            init(attrs, defStyleAttr, 0);
        }

        //[TargetApiAttribute = BuildVersionCodes.Lollipop]
        public ProgressLayout(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base ( context, attrs, defStyleAttr , defStyleRes)
        {
            init(attrs, defStyleAttr, defStyleRes);
        }

        private void init(IAttributeSet attrs, int defStyleAttr, int defStyleRes)
        {
            TypedArray a = Application.Context.Theme.ObtainStyledAttributes(
                    attrs,
                    Resource.Styleable.Dialog,
                    defStyleAttr, defStyleRes);

            spotsCount = a.GetInt(Resource.Styleable.Dialog_DialogSpotCount, DEFAULT_COUNT);
            a.Recycle();
        }

        public int getSpotsCount()
        {
            return spotsCount;
        }
    }
}