using System.Collections.Generic;
using System.Linq;
using Assets.src.ScrObj.Bots.interfaces;
using UnityEngine;

namespace Assets.src.ScrObj.Bots
{
    [CreateAssetMenu(fileName = "Bots Settings", menuName = "ScriptableObjects/BotsSettings")]
    public class BotsSettingsCollection : ScriptableObject, IBotsSettingsCollection
    {
        [Header("Bots")]
        [SerializeField]
        private List<BotSettings> _bots;

        public List<BotSettings> GetBotsSettings()
        {
            return _bots;
        }
    }
}
