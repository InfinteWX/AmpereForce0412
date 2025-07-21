// ------------------------------------------------------------
// @file       SingletonObjectPoolExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-23 23:10:18
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.PoolKit.Example._1.SingletonObjectPoolExample
{
    using System.Collections;
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class SingletonObjectPoolExample : MonoBehaviour
    {
        [ShowInInspector]
        private SingletonObjectPool<Bullet> _pool;
        
        private void Start()
        {
            _pool = SingletonObjectPool<Bullet>.Instance;
            
            SingletonObjectPool<Bullet>.Instance.SetObjectFactory(new CustomObjectFactory<Bullet>(() =>
            {
                var bullet = new Bullet();
                Debug.Log("Create Bullet");
                return bullet;
            }));
            
            SingletonObjectPool<Bullet>.Instance.Init(5, 10);
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Spawn GameObject", GUILayout.Width(150), GUILayout.Height(50)))
            {
                var bullet = SingletonObjectPool<Bullet>.Instance.Get();
                StartCoroutine(Recycle(bullet));
            }

            if (GUILayout.Button("Clear GameObject", GUILayout.Width(150), GUILayout.Height(50)))
            {
                SingletonObjectPool<Bullet>.Instance.Clear();
            }
        }
        
        private IEnumerator Recycle(Bullet bullet)
        {
            yield return new WaitForSeconds(1);
            
            // SingletonObjectPool<Bullet>.Instance.Release(bullet);
            bullet.Release2Pool();
        }
    }
}