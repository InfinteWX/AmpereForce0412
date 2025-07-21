// ------------------------------------------------------------
// @file       Game.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 16:10:41
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._7.PointPointPoint.Scripts.View
{
    using Core;
    using UnityEngine;

    public class Game : AbstractView
    {
        protected override IArchitecture _Architecture => PointGame.Architecture;

        private Transform _enemies;

        protected void Awake()
        {
            _enemies = transform.Find("Enemies");

            this.RegisterEvent<GameStartEvent>(OnGameStart).UnRegisterWhenGameObjectDestroyed(gameObject);
            this.RegisterEvent<OnCountDownEndEvent>(OnCountDownEnd).UnRegisterWhenGameObjectDestroyed(gameObject);
            this.RegisterEvent<GameWinEvent>(OnGameWin).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnGameStart(GameStartEvent e)
        {
            _enemies.gameObject.SetActive(true);

            foreach (Transform childTrans in _enemies)
            {
                childTrans.gameObject.SetActive(true);
            }
        }

        private void OnCountDownEnd(OnCountDownEndEvent e)
        {
            _enemies.gameObject.SetActive(false);
        }

        private void OnGameWin(GameWinEvent e)
        {
            _enemies.gameObject.SetActive(false);
        }
    }
}