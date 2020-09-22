using System;
using System.Collections.Generic;
using System.Linq;
using Game.Bot.Strategy.interfaces;
using Game.Bot.Utils;

namespace Game.Bot.Strategy
{
    internal sealed class PullMoveStrategy
    {
        private readonly IList<KeyValuePair<EnumStrategy, Type>> _strategyPull;

        public PullMoveStrategy()
        {
            _strategyPull = new List<KeyValuePair<EnumStrategy, Type>>();

            AddToken(EnumStrategy.Default, typeof(DefaultMove));
            AddToken(EnumStrategy.Random, typeof(RandomMove));
        }

        public IMoveStrategy GetMoveStrategy(EnumStrategy key)
        {
            Type strategyType = _strategyPull.FirstOrDefault(x => x.Key.Equals(key))
                                          .Value;

            return (IMoveStrategy)Activator.CreateInstance(strategyType);
        }

        private void AddToken(EnumStrategy key
                              , Type strategy)
        {
            KeyValuePair<EnumStrategy, Type> token = new KeyValuePair<EnumStrategy, Type>(key, strategy);

            _strategyPull.Add(token);
        }
    }
}
