using Assets.src.Game.Bot.interfaces;
using Assets.src.Game.Bot.Utils;
using UnityEngine;

namespace Assets.src.ScrObj.Bots
{
    [CreateAssetMenu(fileName = "Bots Settings", menuName = "ScriptableObjects/Bot")]
    internal sealed class BotSettings : ScriptableObject
                                        , IBotSettings
    {
        [SerializeField]
        private bool _trap;

        [SerializeField]
        private int _trigger;

        [SerializeField]
        private Transform _botObj;

        [SerializeField]
        private EnumStrategy _strategy;

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
