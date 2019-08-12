using System.Collections.Generic;
using System.Linq;
using Assets.src.ScrObj.Bots.interfaces;
using UnityEngine;

namespace Assets.src.ScrObj.Bots
{
    [CreateAssetMenu(fileName = "Bots Settings", menuName = "ScriptableObjects/BotsSettings")]
    public class BotsSettings : ScriptableObject, IBotsSettings
    {
        [Header("Bots")]
        [SerializeField]
        private List<Bot> _bots;

        public List<Bot> GetBots()
        {
            return _bots;
        }
    }
}
