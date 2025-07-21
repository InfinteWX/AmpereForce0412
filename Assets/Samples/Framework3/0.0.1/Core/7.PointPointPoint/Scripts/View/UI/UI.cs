// ------------------------------------------------------------
// @file       UI.cs
// @brief
// @author     zheliku
// @Modified   2024-10-15 15:10:03
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._7.PointPointPoint.Scripts.View.UI
{
    using Core;

    public class UI : AbstractView
    {
        protected override IArchitecture _Architecture => PointGame.Architecture;

        private AbstractView _startPanel;
        private AbstractView _gamePanel;
        private AbstractView _winPanel;
        private AbstractView _losePanel;

        protected void Awake()
        {
            _startPanel = transform.Find("Canvas/StartPanel").GetComponent<StartPanel>();
            _gamePanel  = transform.Find("Canvas/GamePanel").GetComponent<GamePanel>();
            _winPanel   = transform.Find("Canvas/WinPanel").GetComponent<WinPanel>();
            _losePanel  = transform.Find("Canvas/LosePanel").GetComponent<LosePanel>();

            this.RegisterEvent<GameStartEvent>(OnGameStart).UnRegisterWhenGameObjectDestroyed(gameObject);
            this.RegisterEvent<GameWinEvent>(OnGameWin).UnRegisterWhenGameObjectDestroyed(gameObject);
            this.RegisterEvent<GameLoseEvent>(OnGameLose).UnRegisterWhenGameObjectDestroyed(gameObject);
            this.RegisterEvent<OnCountDownEndEvent>(OnCountDownEnd).UnRegisterWhenGameObjectDestroyed(gameObject); // 计时结束，即游戏失败
            this.RegisterEvent<OnReturnMenuEvent>(OnReturnMenu).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnGameStart(GameStartEvent e)
        {
            _gamePanel.gameObject.SetActive(true);
        }

        private void OnGameWin(GameWinEvent e)
        {
            _gamePanel.gameObject.SetActive(false);
            _winPanel.gameObject.SetActive(true);
        }

        private void OnGameLose(GameLoseEvent e)
        {
            _gamePanel.gameObject.SetActive(false);
            _losePanel.gameObject.SetActive(true);
        }

        private void OnCountDownEnd(OnCountDownEndEvent e)
        {
            OnGameLose(null);
        }

        private void OnReturnMenu(OnReturnMenuEvent e)
        {
            _startPanel.gameObject.SetActive(true);
        }
    }
}