// ------------------------------------------------------------
// @file       GamePanel.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 13:10:06
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework3.Core.Example._7.PointPointPoint.Scripts.View.UI
{
    using System.CountSownSystem;
    using Core;
    using Model;
    using TMPro;
    using UnityEngine;

    public class GamePanel : AbstractView
    {
        protected override IArchitecture _Architecture => PointGame.Architecture;

        private ICountDownSystem _countDownSystem;
        private IGameModel       _gameModel;

        private TextMeshProUGUI _txtScoreValue;
        private TextMeshProUGUI _txtLifeValue;
        private TextMeshProUGUI _txtGoldValue;
        private TextMeshProUGUI _txtCountDownValue;

        protected override void Awake()
        {
            base.Awake();

            _countDownSystem = this.GetSystem<ICountDownSystem>();
            _gameModel       = this.GetModel<IGameModel>();

            _txtScoreValue     = transform.Find("Score/Value").GetComponent<TextMeshProUGUI>();
            _txtLifeValue      = transform.Find("Life/Value").GetComponent<TextMeshProUGUI>();
            _txtGoldValue      = transform.Find("Gold/Value").GetComponent<TextMeshProUGUI>();
            _txtCountDownValue = transform.Find("CountDown/Value").GetComponent<TextMeshProUGUI>();

            // 注册 UI 更新事件
            _gameModel.Score.RegisterWithInitValue(OnScoreValueChanged).UnregisterWhenGameObjectDestroyed(gameObject);
            _gameModel.Life.RegisterWithInitValue(OnLifeValueChanged).UnregisterWhenGameObjectDestroyed(gameObject);
            _gameModel.Gold.RegisterWithInitValue(OnGoldValueChanged).UnregisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            if (Time.frameCount % 20 == 0)
            { // 每 20 帧更新一次
                _txtCountDownValue.text = _countDownSystem.CurrentRemainSecond + "s";

                _countDownSystem.Update();
            }
        }

        private void OnDestroy()
        {
            _countDownSystem = null;
            _gameModel       = null;
        }

        private void OnScoreValueChanged(int oldScore, int score)
        {
            _txtScoreValue.text = score.ToString();
        }

        private void OnLifeValueChanged(int oldLife, int life)
        {
            _txtLifeValue.text = life.ToString();
        }

        private void OnGoldValueChanged(int oldGold, int gold)
        {
            _txtGoldValue.text = gold.ToString();
        }
    }
}