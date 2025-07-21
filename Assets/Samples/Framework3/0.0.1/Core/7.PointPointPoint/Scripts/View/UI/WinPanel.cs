// ------------------------------------------------------------
// @file       WinPanel.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 14:10:10
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._7.PointPointPoint.Scripts.View.UI
{
    using System.CountSownSystem;
    using Command;
    using Core;
    using Model;
    using TMPro;
    using UnityEngine.UI;

    public class WinPanel : AbstractView
    {
        protected override IArchitecture _Architecture => PointGame.Architecture;

        private ICountDownSystem _countDownSystem;
        private IGameModel       _gameModel;

        private TextMeshProUGUI _txtScoreValue;
        private TextMeshProUGUI _txtRemainSecondValue;
        private TextMeshProUGUI _txtBestScoreValue;

        private Button _btnBack;

        protected void Awake()
        {
            _countDownSystem = this.GetSystem<ICountDownSystem>();
            _gameModel       = this.GetModel<IGameModel>();

            _txtRemainSecondValue = transform.Find("RemainSecond/Value").GetComponent<TextMeshProUGUI>();
            _txtScoreValue        = transform.Find("Score/Value").GetComponent<TextMeshProUGUI>();
            _txtBestScoreValue    = transform.Find("BestScore/Value").GetComponent<TextMeshProUGUI>();
            _btnBack              = transform.Find("btnBack").GetComponent<Button>();

            _btnBack.onClick.AddListener(OnBtnBackClick);
        }

        private void OnEnable()
        {
            _txtRemainSecondValue.text = _countDownSystem.CurrentRemainSecond + "s";
            _txtScoreValue.text        = _gameModel.Score.Value.ToString();
            _txtBestScoreValue.text    = _gameModel.BestScore.Value.ToString();
        }

        private void OnDestroy()
        {
            _countDownSystem = null;
            _gameModel       = null;
        }

        private void OnBtnBackClick()
        {
            gameObject.SetActive(false);
            this.SendCommand<ReturnMenuCommand>();
        }
    }
}