// ------------------------------------------------------------
// @file       ScreenTransitionsExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-31 15:10:33
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.ActionKit.Example
{
    using UnityEngine;

    public class ScreenTransitionExample : MonoBehaviour
    {
        public void FadeIn()
        {
            ActionKit.ScreenTransition
               .FadeIn()
               .Start(this);
        }
        
        public void FadeOut()
        {
            ActionKit.ScreenTransition
               .FadeOut()
               .Start(this);
        }
        
        public void FadeInOut()
        {
            ActionKit.ScreenTransition
               .FadeInOut(intervalTime: 1)
               .OnInFinish(() => { Debug.Log("Loading scene..."); })
               .OnOutFinish(() => { Debug.Log("Load Finished."); })
               .Start(this);
        }
        
        public void FadeInWhite()
        {
            ActionKit.ScreenTransition
               .FadeIn(color: Color.white) // 参数设置
               .Start(this);
        }
        
        public void FadeOutRed()
        {
            ActionKit.ScreenTransition
               .FadeOut()
               .Color(Color.red) // 方法设置
               .Start(this);
        }
        
        public void FadeInOutSpecial()
        {
            ActionKit.ScreenTransition
               .FadeInOut(fadeInDuration: 0.5f, fadeOutDuration: 0.5f)
               .In(fadeIn => fadeIn.Color(Color.green))
               .Out(fadeOut => fadeOut.Color(Color.blue))
               .Start(this);
        }
    }
}