using Assets.src.Units.Bot.interfaces;
using Assets.src.Units.Bot.Utils;
using src.Units.Bot;
using UnityEngine;

namespace Assets.src.ScrObj.Bots
{
    [CreateAssetMenu(fileName = "Bots Settings", menuName = "ScriptableObjects/Bot")]
    public class BotSettings : ScriptableObject, IBotSettings
    {
        [SerializeField]
        private bool _trap;

        [SerializeField]
        private int _trigger;

        [SerializeField]
        private Vector3 _localSale;
        
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

        public Vector3 LocalScale()
        {
            return _localSale;
        }

        public Transform Transform()
        {
            return _botObj;
        }

        public EnumStrategy Strategy()
        {
            return _strategy;
        }
    }
}
