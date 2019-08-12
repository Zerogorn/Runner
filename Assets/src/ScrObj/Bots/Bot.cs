using Assets.src.Units.Bot.Utils;
using UnityEngine;

namespace Assets.src.ScrObj.Bots
{
    [CreateAssetMenu(fileName = "Bots Settings", menuName = "ScriptableObjects/Bot")]
    public class Bot : ScriptableObject
    {
        [SerializeField]
        private bool _trap;

        [SerializeField]
        public int _trigger;

        [SerializeField]
        public GameObject _botObj;

        [SerializeField]
        public EnumStrategy _strategy;
    }
}
