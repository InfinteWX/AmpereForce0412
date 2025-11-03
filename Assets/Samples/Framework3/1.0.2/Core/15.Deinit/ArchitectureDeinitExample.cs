// ------------------------------------------------------------
// @file       ArchitectureDeinitExample.cs
// @brief
// @author     zheliku
// @Modified   2024-10-16 15:10:11
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

using UnityEngine;

namespace Framework3.Core.Example._15.Deinit
{
    using System.Collections;

    public class ArchitectureDeinitExample : MonoBehaviour
    {
        private IEnumerator Start()
        {
            Debug.Log("Start Init");
            var simpleArchitecture = SimpleArchitecture.Architecture;
            yield return new WaitForSeconds(2.0f);
            Debug.Log("Start Deinit");
            simpleArchitecture.Deinit();
        }
    }
}