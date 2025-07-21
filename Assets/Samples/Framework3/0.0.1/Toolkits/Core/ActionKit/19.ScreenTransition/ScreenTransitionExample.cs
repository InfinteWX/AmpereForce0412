// ------------------------------------------------------------
// @file       ScreenTransitionsExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-31 15:10:33
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.ActionKit.Example
{
    using UnityEngine;

    public class ScreenTransitionExample : MonoBehaviour
    {
        private void OnGUI()
        {
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("FadeIn", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.ScreenTransition
                   .FadeIn()
                   .Start(this);
            }

            GUILayout.Space(20);

            if (GUILayout.Button("FadeOut", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.ScreenTransition
                   .FadeOut()
                   .Start(this);
            }

            GUILayout.Space(20);

            if (GUILayout.Button("FadeInOut", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.ScreenTransition
                   .FadeInOut(intervalTime: 1)
                   .OnInFinish(() => { Debug.Log("Loading scene..."); })
                   .OnOutFinish(() => { Debug.Log("Load Finished."); })
                   .Start(this);
            }

            GUILayout.Space(20);

            if (GUILayout.Button("FadeIn White", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.ScreenTransition
                   .FadeIn(color: Color.white) // 参数设置
                   .Start(this);
            }

            GUILayout.Space(20);

            if (GUILayout.Button("FadeOut Red", GUILayout.Width(120), GUILayout.Height(50)))
            {
                ActionKit.ScreenTransition
                   .FadeOut()
                   .Color(Color.red) // 方法设置
                   .Start(this);
            }

            GUILayout.Space(20);

            if (GUILayout.Button("FadeInOut 0.5s in green out blue", GUILayout.Width(200), GUILayout.Height(50)))
            {
                ActionKit.ScreenTransition
                   .FadeInOut(fadeInDuration: 0.5f, fadeOutDuration: 0.5f)
                   .In(fadeIn => fadeIn.Color(Color.green))
                   .Out(fadeOut => fadeOut.Color(Color.blue))
                   .Start(this);
            }

            GUILayout.EndHorizontal();
        }
    }
}