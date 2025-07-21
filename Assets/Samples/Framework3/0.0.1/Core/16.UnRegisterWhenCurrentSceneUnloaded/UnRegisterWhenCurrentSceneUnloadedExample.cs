namespace Framework.Core.Example._16.UnRegisterWhenCurrentSceneUnloaded
{
    using global::System;
    using global::System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class UnRegisterWhenCurrentSceneUnloadedExample : MonoBehaviour
    {
        private static bool _Registered = false;

        private static readonly EasyEvent _EXAMPLE_EVENT = new EasyEvent();

        async void Start()
        {
            if (!_Registered)
            {
                _Registered = true;

                _EXAMPLE_EVENT.Register(() =>
                {
                    Debug.Log("Received When Scene Not Changed");
                }).UnRegisterWhenCurrentSceneUnloaded();

                var gameObj = new GameObject("gameObj");
                DontDestroyOnLoad(gameObj);
                _EXAMPLE_EVENT.Register(() =>
                {
                    Debug.Log("Received When GameObj Not Destroyed");
                }).UnRegisterWhenGameObjectDestroyed(gameObj);

                _EXAMPLE_EVENT.Register(() =>
                {
                    Debug.Log("Received Forever");
                });
                Debug.Log("@@@@ In Current Scene @@@@");
                _EXAMPLE_EVENT.Trigger();

                Debug.Log("@@@@ After GameObject Destroyed @@@@");
                Destroy(gameObj);
                await Task.Delay(TimeSpan.FromSeconds(0.1f));
                _EXAMPLE_EVENT.Trigger();

                Debug.Log("@@@@ After Scene Unloaded/Changed @@@@");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                await Task.Delay(TimeSpan.FromSeconds(0.1f));
                _EXAMPLE_EVENT.Trigger();
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