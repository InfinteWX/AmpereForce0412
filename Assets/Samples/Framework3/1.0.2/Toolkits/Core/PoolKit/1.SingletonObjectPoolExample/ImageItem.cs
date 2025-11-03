// ------------------------------------------------------------
// @file       ImageItem.cs
// @brief
// @author     zheliku
// @Modified   2024-10-23 23:10:35
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.PoolKit.Example._1.SingletonObjectPoolExample
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ImageItem : MonoBehaviour, IPoolable
    {
        private Image _image;
        
        [SerializeField]
        private Transform _poolParent;

        [SerializeField]
        private Transform _useParent;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void OnCreate()
        {
            transform.SetParent(_poolParent);
            _image.color = Color.gray;
        }
        
        public void OnGet()
        {
            transform.SetParent(_useParent);
            _image.color = Color.white;
        }

        public void OnRelease()
        {
            transform.SetParent(_poolParent);
            _image.color = Color.gray;
        }
        
        public void OnDestroy()
        {
            if (this)
            {
                Destroy(gameObject);
            }
        }

        public bool IsInPool { get; set; }
    }
}