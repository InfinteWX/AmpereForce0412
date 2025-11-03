// ------------------------------------------------------------
// @file       LoadFormResourcesExample.cs
// @brief
// @author     zheliku
// @Modified   2024-12-10 11:12:28
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Toolkits.ResKit.Example._0.Basic
{
    using UnityEngine;

    public class LoadFormResourcesExample : MonoBehaviour
    {
        private GameObject _res;
        
        private ResourceRequest _req;

        private void Start()
        {
            // 同步加载
            _res = ResKit.LoadFromResources<GameObject>("Sphere");
            Instantiate(_res);
            
            // 异步加载
            _req = ResKit.LoadFromResourcesAsync<GameObject>("Sphere", res =>
            {
                var obj = Instantiate(res);
                obj.transform.position = Vector3.up;
            });
        }

        private void OnDestroy()
        {
            // 加载后的资源需要及时释放
            _res.Unload();
            _req.Unload();
        }
    }
}