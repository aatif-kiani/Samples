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
using Java.Lang;
using Android.Animation;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics.Drawables;

namespace SpotsDialogLib.lib
{
    class SpotsDialog : AlertDialog
    {

        private static int DELAY = 150;
        private static int DURATION = 1500;

        private int size;
        private AnimatedView[] spots;
        private AnimatorPlayer animator;
        private ICharSequence message;

        public SpotsDialog(Context context) : this(context, Resource.Style.SpotsDialogDefault)
        {
        }

        public SpotsDialog(Context context, ICharSequence message) : this(context)
        {
            this.message = message;
        }

        public SpotsDialog(Context context, ICharSequence message, int theme) : this(context, theme)
        {
            this.message = message;
        }

        public SpotsDialog(Context context, int theme) : base(context, theme)
        {
        }

        public SpotsDialog(Context context, bool cancelable, EventHandler cancelListener)
            : base(context, cancelable, cancelListener)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.dmax_spots_dialog);
            SetCanceledOnTouchOutside(false);

            initMessage();
            initProgress();
        }

        protected override void OnStart()
        {
            base.OnStart();

            animator = new AnimatorPlayer(createAnimations());
            animator.play();
        }

        protected override void OnStop()
        {
            base.OnStop();

            animator.stop();
        }

        public void setMessage(ICharSequence message)
        {
            ((TextView)FindViewById(Resource.Id.dmax_spots_title)).Text = Convert.ToString(message);
        }
        
        private void initMessage()
        {
            if (message != null && message.Length() > 0)
            {
                ((TextView)FindViewById(Resource.Id.dmax_spots_title)).Text = Convert.ToString(message);
            }
        }

        private void initProgress()
        {
            ProgressLayout progress = (ProgressLayout)FindViewById(Resource.Id.dmax_spots_progress);
            this.size = progress.getSpotsCount();

            spots = new AnimatedView[this.size];
            int size = Application.Context.Resources.GetDimensionPixelSize(Resource.Dimension.spot_size);
            int progressWidth = Application.Context.Resources.GetDimensionPixelSize(Resource.Dimension.progress_width);
            for (int i = 0; i < spots.Length; i++)
            {
                AnimatedView v = new AnimatedView(Application.Context);
                //v.SetBackgroundDrawable(s);
                v.SetBackgroundResource(Resource.Drawable.dmax_spots_spot);
                v.SetBackgroundColor(Android.Graphics.Color.Black);
                v.setTarget(progressWidth);
                v.setXFactor(-1f);
                progress.AddView(v, size, size);
                spots[i] = v;
            }
        }

        private Animator[] createAnimations()
        {
            Animator[] animators = new Animator[size];
            for (int i = 0; i < spots.Length; i++)
            {
                Animator move = ObjectAnimator.OfFloat(spots[i], "xFactor", 0, 1);
                move.SetDuration(DURATION);
                move.SetInterpolator(new HesitateInterpolator());
                move.StartDelay = (DELAY * i);
                animators[i] = move;
            }
            return animators;
        }
    }
}