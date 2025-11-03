// ------------------------------------------------------------
// @file       SimpleObjectPoolExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-23 22:10:22
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.PoolKit.Example._0.ObjectPoolExample
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ObjectPoolExample : MonoBehaviour
    {
        private ObjectPool<GameObject> _objectPool;

        [SerializeField]
        private Image _imageItem;

        [SerializeField]
        private Transform _poolParent;

        [SerializeField]
        private Transform _useParent;

        void Start()
        {
            _objectPool = new ObjectPool<GameObject>(
                () =>
                {
                    var image = Instantiate(_imageItem, _poolParent);
                    image.gameObject.SetActive(true);
                    image.color = Color.gray;
                    return image.gameObject;
                },
                actionOnGet: gameObj =>
                {
                    gameObj.transform.SetParent(_useParent);
                    gameObj.GetComponent<Image>().color = Color.white;
                },
                actionOnRelease: gameObj =>
                {
                    gameObj.transform.SetParent(_poolParent);
                    gameObj.GetComponent<Image>().color = Color.gray;
                },
                actionOnDestroy: Destroy,
                defaultCapacity: 10);
        }

        public void GetGameObjectFromPool()
        {
            _objectPool.Get();
        }

        public void ReleaseGameObjectToPool()
        {
            if (_useParent.childCount > 0)
            {
                var item = _useParent.GetChild(0);
                _objectPool.Release(item.gameObject);
            }
        }

        public void ClearGameObjectPool()
        {
            _objectPool.Clear();
        }
    }
}