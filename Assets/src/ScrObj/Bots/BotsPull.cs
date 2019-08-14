using System.Collections.Generic;
using System.Linq;
using Assets.src.ScrObj.Bots.interfaces;
using UnityEngine;

namespace Assets.src.ScrObj.Bots
{
    [CreateAssetMenu(fileName = "Bots Pull", menuName = "ScriptableObjects/BotsPull")]
    public class BotsPull : ScriptableObject, IBotsPull
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
