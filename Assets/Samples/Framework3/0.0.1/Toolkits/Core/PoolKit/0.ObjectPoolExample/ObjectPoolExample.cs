// ------------------------------------------------------------
// @file       SimpleObjectPoolExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-23 22:10:22
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.PoolKit.Example._0.ObjectPoolExample
{
    using System.Collections;
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class ObjectPoolExample : MonoBehaviour
    {
        [ShowInInspector]
        private ObjectPool<GameObject> _objectPool;

        void Start()
        {
            _objectPool = new ObjectPool<GameObject>(
                () =>
                {
                    var gameObj = new GameObject();
                    gameObj.SetActive(false);
                    return gameObj;
                },
                actionOnRelease: gameObj => { gameObj.SetActive(false); },
                actionOnDestroy: Destroy,
                defaultCapacity: 10);
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Spawn GameObject", GUILayout.Width(150), GUILayout.Height(50)))
            {
                var obj = _objectPool.Get();
                obj.SetActive(true);
                StartCoroutine(Recycle(obj));
            }

            if (GUILayout.Button("Clear GameObject", GUILayout.Width(150), GUILayout.Height(50)))
            {
                _objectPool.Clear();
            }
        }

        private IEnumerator Recycle(GameObject obj)
        {
            yield return new WaitForSeconds(1);
            _objectPool.Release(obj);
        }
    }
}