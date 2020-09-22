using Game.Bot.interfaces;
using Game.Bot.Utils;
using UnityEngine;

namespace ScrObj.Bots
{
    [CreateAssetMenu(fileName = "Bots Settings", menuName = "ScriptableObjects/Bot")]
    internal sealed class BotSettings : ScriptableObject
                                        , IBotSettings
    {
        [SerializeField]
        private bool _trap = false;

        [SerializeField]
        private int _trigger = 0;

        [SerializeField]
        private Transform _botObj = null;

        [SerializeField]
        private EnumStrategy _strategy = EnumStrategy.Default;

        public bool Trap()
        {
            return _trap;
        }

        public int HitBoxRadius()
        {
            return _trigger;
        }

        public Transform Transform()
        {
            _botObj.gameObject.SetActive(true);

            return _botObj;
        }

        public EnumStrategy Strategy()
        {
            return _strategy;
        }
    }
}
