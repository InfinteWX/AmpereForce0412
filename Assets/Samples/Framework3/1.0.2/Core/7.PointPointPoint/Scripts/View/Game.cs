// ------------------------------------------------------------
// @file       Game.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 16:10:41
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.View
{
    using Framework3.Core;
    using UnityEngine;

    public class Game : AbstractView
    {
        protected override IArchitecture _Architecture
        {
            get => PointGame.Architecture;
        }

        private Transform _enemies;

        protected override void Awake()
        {
            base.Awake();
            
            _enemies = transform.Find("Enemies");

            this.RegisterEvent<GameStartEvent>(OnGameStart).UnregisterWhenGameObjectDestroyed(gameObject);
            this.RegisterEvent<OnCountDownEndEvent>(OnCountDownEnd).UnregisterWhenGameObjectDestroyed(gameObject);
            this.RegisterEvent<GameWinEvent>(OnGameWin).UnregisterWhenGameObjectDestroyed(gameObject);
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