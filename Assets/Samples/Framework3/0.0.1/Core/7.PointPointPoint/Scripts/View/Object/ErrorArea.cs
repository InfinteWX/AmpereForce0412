// ------------------------------------------------------------
// @file       ErrorArea.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 16:10:48
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._7.PointPointPoint.Scripts.View.Object
{
    using Command;
    using Core;

    public class ErrorArea : AbstractView
    {
        protected override IArchitecture _Architecture => PointGame.Architecture;

        private void OnMouseDown()
        {
            this.SendCommand<MissCommand>();
        }
    }
}