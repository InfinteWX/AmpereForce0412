// ------------------------------------------------------------
// @file       StartPanel.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 14:10:43
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._7.PointPointPoint.Scripts.View.UI
{
    using Command;
    using Core;
    using Model;
    using TMPro;
    using UnityEngine.UI;

    public class StartPanel : AbstractView
    {
        protected override IArchitecture _Architecture => PointGame.Architecture;

        private IGameModel _gameModel;

        private Button _btnStart;
        private Button _btnBuyLife;

        private TextMeshProUGUI _txtBestScoreValue;
        private TextMeshProUGUI _txtLifeValue;
        private TextMeshProUGUI _txtGoldValue;

        protected void Awake()
        {
            _gameModel = this.GetModel<IGameModel>();

            _btnStart   = transform.Find("btnStart").GetComponent<Button>();
            _btnBuyLife = transform.Find("btnBuyLife").GetComponent<Button>();

            _txtBestScoreValue = transform.Find("BestScore/Value").GetComponent<TextMeshProUGUI>();
            _txtLifeValue      = transform.Find("Life/Value").GetComponent<TextMeshProUGUI>();
            _txtGoldValue      = transform.Find("Gold/Value").GetComponent<TextMeshProUGUI>();

            _gameModel.Gold.RegisterWithInitValue(OnGoldValueChanged).UnRegisterWhenGameObjectDestroyed(gameObject);
            _gameModel.Life.RegisterWithInitValue(OnLifeValueChanged).UnRegisterWhenGameObjectDestroyed(gameObject);

            _btnStart.onClick.AddListener(OnBtnStartClick);
            _btnBuyLife.onClick.AddListener(OnBtnBuyLifeClick);

            _txtBestScoreValue.text = _gameModel.BestScore.Value.ToString();
        }

        private void OnDestroy()
        {
            _gameModel = null;
        }

        private void OnGoldValueChanged(int oldGold, int gold)
        {
            _btnBuyLife.gameObject.SetActive(gold > 0);
            _txtGoldValue.text = gold.ToString();
        }

        private void OnLifeValueChanged(int oldLife, int life)
        {
            _txtLifeValue.text = life.ToString();
        }

        private void OnBtnStartClick()
        {
            gameObject.SetActive(false);
            this.SendCommand<StartGameCommand>();
        }

        private void OnBtnBuyLifeClick()
        {
            this.SendCommand<BuyLifeCommand>();
        }
    }
}