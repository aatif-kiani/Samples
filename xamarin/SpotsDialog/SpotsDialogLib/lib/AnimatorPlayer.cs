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
using Android.Animation;

namespace SpotsDialogLib.lib
{
    class AnimatorPlayer : AnimatorListenerAdapter
    {
        private bool interrupted = false;
        private Animator[] animators;

        public AnimatorPlayer(Animator[] animators)
        {
            this.animators = animators;
        }
        
        public override void OnAnimationEnd(Animator animation)
        {
            if (!interrupted) animate();
        }

        public void play()
        {
            animate();
        }

        public void stop()
        {
            interrupted = true;
        }

        private void animate()
        {
            AnimatorSet set = new AnimatorSet();
            set.PlayTogether(animators);
            set.AddListener(this);
            set.Start();
        }
    }
}