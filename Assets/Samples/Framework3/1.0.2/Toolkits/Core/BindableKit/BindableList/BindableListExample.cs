// ------------------------------------------------------------
// @file       BindableListExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 10:10:10
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------


namespace Framework3.Toolkits.Core.BindableKit.Example.BindableList
{
    using FluentAPI;
    using Framework3.Core;
    using TMPro;
    using Toolkits.BindableKit;
    using UnityEngine;

    public class BindableListExample : MonoBehaviour
    {
        private BindableList<string> _nameList = new BindableList<string>();

        private TextMeshProUGUI _txtNameTemplate;
        private Transform       _contentRoot;

        private void Awake()
        {
            _txtNameTemplate = GameObject.Find("Canvas/txtName").GetComponent<TextMeshProUGUI>();
            _contentRoot = GameObject.Find("Canvas/ContentRoot").transform;

            _txtNameTemplate.DisableGameObject();

            _nameList.OnCountChanged.Register(OnNameListCountChanged).UnregisterWhenGameObjectDestroyed(gameObject);
            _nameList.OnAdd.Register(OnNameListAdd).UnregisterWhenGameObjectDestroyed(gameObject);
            _nameList.OnMove.Register(OnNameListMove).UnregisterWhenGameObjectDestroyed(gameObject);
            _nameList.OnRemove.Register(OnNameListOnRemove).UnregisterWhenGameObjectDestroyed(gameObject);
            _nameList.OnReplace.Register(OnNameListOnReplace).UnregisterWhenGameObjectDestroyed(gameObject);
            _nameList.OnClear.Register(OnNameListOnClear).UnregisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnNameListCountChanged(int oldCount, int count)
        {
            Debug.Log("OnNameListCountChanged: " + oldCount + "->" + count);
        }

        private void OnNameListAdd(int index, string item)
        {
            Debug.Log("OnNameListAdd: " + index + ", " + item);

            _txtNameTemplate.Instantiate(_contentRoot)
                            .SetSiblingIndex(index)
                            .EnableGameObject()
                            .text = item;
        }

        private void OnNameListMove(int oldIndex, int newIndex, string item)
        {
            Debug.Log("OnNameListMove: " + oldIndex + ", " + newIndex + ", " + item);

            _contentRoot.GetChild(oldIndex).SetSiblingIndex(newIndex);
        }

        private void OnNameListOnRemove(int index, string item)
        {
            Debug.Log("OnNameListOnRemove: " + index + ", " + item);

            _contentRoot.GetChild(index).DestroyGameObjectGracefully();
        }

        private void OnNameListOnReplace(int index, string oldItem, string newItem)
        {
            Debug.Log("OnNameListOnReplace: " + index + ", " + oldItem + ", " + newItem);

            _contentRoot.GetChild(index).GetComponent<TextMeshProUGUI>().text = newItem;
        }

        private void OnNameListOnClear()
        {
            Debug.Log("OnNameListOnClear");

            _contentRoot.DestroyChildren();
        }

        public void Add()
        {
            _nameList.Add("Name " + _nameList.Count);
        }
        
        public void Move0To1()
        {
            if (_nameList.Count > 1)
            {
                _nameList.Move(0, 1);
            }
        }
        
        public void RemoveAt0()
        {
            if (_nameList.Count > 0)
            {
                _nameList.RemoveAt(0);
            }
        }
        
        public void ReplaceAt0()
        {
            if (_nameList.Count > 0)
            {
                _nameList[0] = "Name " + _nameList.Count;
            }
        }
        
        public void Clear()
        {
            _nameList.Clear();
        }
    }
}