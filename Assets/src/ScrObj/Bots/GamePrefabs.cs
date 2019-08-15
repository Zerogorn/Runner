using System.Collections.Generic;
using System.Linq;
using Assets.src.ScrObj.Bots.interfaces;
using Assets.src.Ui.Utils;
using src.Ui.Components.Windows.Game;
using UnityEngine;

namespace Assets.src.ScrObj.Bots
{
    [CreateAssetMenu(fileName = "Bots Pull", menuName = "ScriptableObjects/BotsPull")]
    internal sealed class GamePrefabs : ScriptableObject
                                        , IGamePrefabs
    {
        [SerializeField]
        [Header("Game Container")]
        private GameViewer _gameViewer;

        [Header("Bots")]
        [SerializeField]
        private List<BotSettings> _bots;

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
