using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonExtentions
{
    public static class AnimatorExtentions
    {
        public static IEnumerator PlayAndWait(this Animator animator, string animName)
        {
            animator.PlayAnim(animName);

            yield return animator.WaitForAnimEnd();
        }


        public static IEnumerator WaitForAnimEnd(this Animator animator)
        {
            yield return new WaitForEndOfFrame();

            if (animator.IsCurrentLooped())
            {
                Debug.LogWarningFormat("Waiting failed: animation {0} looped!", animator.GetCurrentAnimatorStateInfo(0).fullPathHash);
                yield break;
            }

            yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1);
        }


        public static void PlayAnim(this Animator animator, string animName, float normalizedTime = 0, int layer = -1)
        {
            animator.StopPlayback();
            animator.Play(animName, layer, normalizedTime);
        }


        public static bool IsCurrentLooped(this Animator animator)
        {
            var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.loop;
        }

        public static bool IsPlaying(this Animator animator, string animName)
        {
            var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.IsName(animName);
        }



        public static float GetCurrentLength(this Animator animator)
        {
            var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.length;
        }

        public static float GetTimeLeft(this Animator animator)
        {
            var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.length * (1 - stateInfo.normalizedTime);
        }
    }
}