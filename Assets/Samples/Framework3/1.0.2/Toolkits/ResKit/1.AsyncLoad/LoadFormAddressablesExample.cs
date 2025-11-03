// ------------------------------------------------------------
// @file       LoadFormAddressablesExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-10 16:12:01
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

using UnityEngine;

namespace Framework3.Toolkits.ResKit.Example._1.AsyncLoad
{
    using ActionKit;
    using FluentAPI;
    using UnityEngine.ResourceManagement.AsyncOperations;

    public class LoadFormAddressablesExample : MonoBehaviour
    {
        private AsyncOperationHandle<GameObject> _handle;
        
        private void Start()
        {
            // 同步加载
            var asset = ResKit.Instantiate("Cube");
            Instantiate(asset.Result);
            
            // 异步加载
            _handle = ResKit.LoadAssetAsync<GameObject>("Cube", (res) =>
            {
                var obj = Instantiate(res);
                obj.transform.position = Vector3.right;
            });
            
            // 异步加载多个资源
            ResKit.LoadAssetsAsync<GameObject>(new[] { "Cube", "Sphere" }, objs =>
            {
                foreach (var obj in objs)
                {
                    Instantiate(obj)
                       .SetPosition(x: Random.Range(-1, 2f), y: 2);
                }
            }).UnLoadWhenGameObjectDestroyed(gameObject); // 绑定生命周期，GameObject 销毁时卸载资源

            ResKit.LoadAssetAsync<GameObject>("Cube", obj =>
            {
                Instantiate(obj)
                   .SetPosition(x: Random.Range(-1, 2f), y: -2);
            }).UnLoadWhenGameObjectDestroyed(gameObject); // 绑定生命周期，GameObject 销毁时卸载资源

            ActionKit
               .Delay(3, this.DestroyGameObjectGracefully)
               .Start(this); // 3秒后销毁当前 GameObject
        }
        
        private void OnDestroy()
        {
            // 卸载资源
            _handle.Unload();
        }
    }
}