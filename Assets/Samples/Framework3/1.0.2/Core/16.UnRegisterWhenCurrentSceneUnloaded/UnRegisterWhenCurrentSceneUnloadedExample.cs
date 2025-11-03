namespace Framework3.Core.Example._16.UnregisterWhenCurrentSceneUnloaded
{
    using System;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class UnregisterWhenCurrentSceneUnloadedExample : MonoBehaviour
    {
        private static bool s_registered = false;

        private static readonly EasyEvent example_event = new EasyEvent();

        async void Start()
        {
            if (!s_registered)
            {
                s_registered = true;

                example_event.Register(() =>
                {
                    Debug.Log("Received When Scene Not Changed");
                }).UnregisterWhenCurrentSceneUnloaded();

                var gameObj = new GameObject("gameObj");
                DontDestroyOnLoad(gameObj);
                example_event.Register(() =>
                {
                    Debug.Log("Received When GameObj Not Destroyed");
                }).UnregisterWhenGameObjectDestroyed(gameObj);

                example_event.Register(() =>
                {
                    Debug.Log("Received Forever");
                });
                Debug.Log("@@@@ In Current Scene @@@@");
                example_event.Trigger();

                Debug.Log("@@@@ After GameObject Destroyed @@@@");
                Destroy(gameObj);
                await Task.Delay(TimeSpan.FromSeconds(0.1f));
                example_event.Trigger();

                Debug.Log("@@@@ After Scene Unloaded/Changed @@@@");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                await Task.Delay(TimeSpan.FromSeconds(0.1f));
                example_event.Trigger();
            }
        }
    }
}

// @@@@ In Current Scene @@@@
// Received When Scene Not Changed
// Received When GameObj Not Destroyed
// Received Forever
// @@@@ After GameObject Destroyed @@@@
// Received When Scene Not Changed
// Received Forever
// @@@@ After Scene Unloaded/Changed @@@@
// Received Forever