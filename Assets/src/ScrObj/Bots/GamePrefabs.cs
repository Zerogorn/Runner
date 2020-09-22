using System.Collections.Generic;
using ScrObj.Bots.interfaces;
using Ui.Components.Windows.Game;
using UnityEngine;

namespace ScrObj.Bots
{
    [CreateAssetMenu(fileName = "Bots Pull", menuName = "ScriptableObjects/BotsPull")]
    internal sealed class GamePrefabs : ScriptableObject
                                        , IGamePrefabs
    {
        [SerializeField]
        [Header("Game Container")]
        private GameViewer _gameViewer = null;

        [Header("Bots")]
        [SerializeField]
        private List<BotSettings> _bots = null;

        public GameViewer GameContainer(Transform parent)
        {
            GameViewer gameViewer = Instantiate(_gameViewer, parent);

            gameViewer.transform.SetSiblingIndex(0);
            gameViewer.gameObject.SetActive(true);

            return gameViewer;
        }

        public IList<BotSettings> GetBotsSettings()
        {
            return _bots;
        }
    }
}
