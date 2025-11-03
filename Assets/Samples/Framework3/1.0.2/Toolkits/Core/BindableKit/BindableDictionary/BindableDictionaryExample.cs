// ------------------------------------------------------------
// @file       BindableListExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 10:10:10
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------


namespace Framework3.Toolkits.Core.BindableKit.Example.BindableDictionary
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAPI;
    using Framework3.Core;
    using TMPro;
    using Toolkits.BindableKit;
    using UnityEngine;

    public class BindableDictionaryExample : MonoBehaviour
    {
        private BindableDictionary<string, string>  _nameDict   = new BindableDictionary<string, string>();
        private Dictionary<string, TextMeshProUGUI> _recordDict = new Dictionary<string, TextMeshProUGUI>();

        private TextMeshProUGUI _txtNameTemplate;
        private Transform       _contentRoot;
        private int             _count;

        private void Awake()
        {
            _txtNameTemplate = GameObject.Find("Canvas/txtName").GetComponent<TextMeshProUGUI>();
            _contentRoot = GameObject.Find("Canvas/ContentRoot").transform;

            UnityEngineGameObjectExtension.DisableGameObject(_txtNameTemplate);

            _nameDict.OnCountChanged.Register(OnNameDictCountChanged).UnregisterWhenGameObjectDestroyed(gameObject);
            _nameDict.OnAdd.Register(OnNameDictAdd).UnregisterWhenGameObjectDestroyed(gameObject);
            _nameDict.OnRemove.Register(OnNameDictOnRemove).UnregisterWhenGameObjectDestroyed(gameObject);
            _nameDict.OnReplace.Register(OnNameDictOnReplace).UnregisterWhenGameObjectDestroyed(gameObject);
            _nameDict.OnClear.Register(OnNameDictOnClear).UnregisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnNameDictCountChanged(int count)
        {
            Debug.Log("OnNameDictCountChanged: " + count);
        }

        private void OnNameDictAdd(string key, string value)
        {
            Debug.Log("OnNameDictAdd: " + key + ", " + value);

            var text = _txtNameTemplate
                      .Instantiate(_contentRoot)
                      .EnableGameObject()
                      .Self(txt => txt.text = $"{key}: {value}");
            _recordDict.Add(key, text);
        }

        private void OnNameDictOnRemove(string key, string value)
        {
            Debug.Log("OnNameDictOnRemove: " + key + ", " + value);

            var item = _recordDict[key];
            item.DestroyGameObjectGracefully();
            _recordDict.Remove(key);
        }

        private void OnNameDictOnReplace(string key, string oldValue, string newValue)
        {
            Debug.Log("OnNameDictOnReplace: " + key + ", " + oldValue + ", " + newValue);

            _recordDict[key].text = newValue;
        }

        private void OnNameDictOnClear()
        {
            Debug.Log("OnNameDictOnClear");

            _contentRoot.DestroyChildren();
        }

        public void Add()
        {
            _nameDict.Add("Key " + ++_count, Random.Range(0, 100).ToString());
        }
        
        public void Remove()
        {
            if (_nameDict.Count > 0)
            {
                _nameDict.Remove(_nameDict.Keys.First());
            }
        }
        
        public void Replace()
        {
            if (_nameDict.Count > 0)
            {
                _nameDict[_nameDict.Keys.First()] = _nameDict.Keys.First() + ": " + Random.Range(0, 100);
            }
        }
        
        public void Clear()
        {
            _nameDict.Clear();
        }
    }
}