// ------------------------------------------------------------
// @file       SingletonObjectPoolExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-23 23:10:18
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.PoolKit.Example._1.SingletonObjectPoolExample
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class SingletonObjectPoolExample : MonoBehaviour
    {
        [ShowInInspector]
        private ObjectPool<ImageItem> _pool;
    
        [SerializeField]
        private ImageItem _imageItem;

        [SerializeField]
        private Transform _useParent;

        private void Start()
        {
            _pool = SingletonPool<ImageItem>.Pool;
        
            // 设置对象池的工厂方法，实例化 ImageItem 并激活
            SingletonPool<ImageItem>.Pool.SetObjectFactory(new CustomObjectFactory<ImageItem>(() =>
            {
                var item = Instantiate(_imageItem);
                item.gameObject.SetActive(true);
                return item;
            }));
        }

        public void GetGameObjectFromPool()
        {
            SingletonPool<ImageItem>.Get();
        }

        public void ReleaseGameObjectToPool()
        {
            if (_useParent.childCount > 0)
            {
                var item = _useParent.GetChild(0).GetComponent<ImageItem>();
                item.Release2Pool();
            }
        }

        public void ClearGameObjectPool()
        {
            SingletonPool<ImageItem>.Clear();
        }
    }
}