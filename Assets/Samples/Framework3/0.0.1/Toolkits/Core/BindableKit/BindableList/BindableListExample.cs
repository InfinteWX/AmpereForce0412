// ------------------------------------------------------------
// @file       BindableListExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-20 10:10:10
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------


namespace Framework.Toolkits.Core.BindableKit.Example.BindableList
{
    using FluentAPI;
    using Framework.Core;
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
            _contentRoot     = GameObject.Find("Canvas/ContentRoot").transform;

            UnityEngineGameObjectExtension.DisableGameObject(_txtNameTemplate);

            _nameList.OnCountChanged.Register(OnNameListCountChanged).UnRegisterWhenGameObjectDestroyed(gameObject);
            _nameList.OnAdd.Register(OnNameListAdd).UnRegisterWhenGameObjectDestroyed(gameObject);
            _nameList.OnMove.Register(OnNameListMove).UnRegisterWhenGameObjectDestroyed(gameObject);
            _nameList.OnRemove.Register(OnNameListOnRemove).UnRegisterWhenGameObjectDestroyed(gameObject);
            _nameList.OnReplace.Register(OnNameListOnReplace).UnRegisterWhenGameObjectDestroyed(gameObject);
            _nameList.OnClear.Register(OnNameListOnClear).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnNameListCountChanged(int oldCount, int count)
        {
            Debug.Log("OnNameListCountChanged: " + oldCount + "->" + count);
        }

        private void OnNameListAdd(int index, string item)
        {
            Debug.Log("OnNameListAdd: " + index + ", " + item);

            _txtNameTemplate.Instantiate(_contentRoot)
                            .SiblingIndex(index)
                            .EnableGameObject()
                            .text = item;
        }

        private void OnNameListMove(int oldIndex, int newIndex, string item)
        {
            Debug.Log("OnNameListMove: " + oldIndex + ", " + newIndex + ", " + item);

            _contentRoot.GetChild(oldIndex).SiblingIndex(newIndex);
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

        private void OnGUI()
        {
            if (GUILayout.Button("Add", GUILayout.Width(150), GUILayout.Height(60)))
            {
                _nameList.Add("Name " + _nameList.Count);
            }

            if (GUILayout.Button("Move 0 -> 1", GUILayout.Width(150), GUILayout.Height(60)))
            {
                if (_nameList.Count > 1)
                {
                    _nameList.Move(0, 1);
                }
            }

            if (GUILayout.Button("Remove at 0", GUILayout.Width(150), GUILayout.Height(60)))
            {
                if (_nameList.Count > 0)
                {
                    _nameList.RemoveAt(0);
                }
            }

            if (GUILayout.Button("Replace at 0", GUILayout.Width(150), GUILayout.Height(60)))
            {
                _nameList[0] = "Name " + _nameList.Count;
            }

            if (GUILayout.Button("Clear", GUILayout.Width(150), GUILayout.Height(60)))
            {
                _nameList.Clear();
            }
        }
    }
}