using System;
using System.Collections.Generic;
using Game.Bot.Strategy.interfaces;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Bot.Strategy
{
    internal sealed class RandomMove : IMoveStrategy
    {
        private readonly IList<Func<float, Vector2>> _vectors;

        private Func<float, Vector2> _currentMove;

        private IDisposable _disposableTimer;

        private Transform _transform;

        public RandomMove()
        {
            _vectors = new List<Func<float, Vector2>>()
            {
                MoveLeft
                , MoveRight
                , MoveBottom
            };

            _currentMove = MoveBottom;
        }

        public void Move(Transform transform
                         , float move)
        {
            if (_disposableTimer == null)
            {
                UpdateVector();
            }                

            _transform = transform;

            Vector2 position = _currentMove.Invoke(move);

            _transform.localPosition = position;
        }
       
        private Vector2 MoveLeft(float move)
        {
            return MoveX(-1, move);
        }

        private Vector2 MoveRight(float move)
        {
            return MoveX(1, move);
        }

        private Vector2 MoveX(int vector
                              , float move)
        {
            float x = _transform.localPosition.x + move * vector;

            return new Vector2(x, _transform.localPosition.y);
        }
        
        private Vector2 MoveBottom(float move)
        {
            return MoveY(-1, move);
        }

        private Vector2 MoveY(int vector
                              , float move)
        {
            float y = _transform.localPosition.y + move * vector;

            return new Vector2(_transform.localPosition.x, y);
        }

        private void UpdateVector()
        {
            float from = Random.Range(100f, 1000f);
            float to = Random.Range(100f, 1000f);

            float timeToUpdate = Random.Range(from, to);

            _disposableTimer = Observable.Timer(TimeSpan.FromMilliseconds(timeToUpdate))
                                         .Subscribe(_ =>
                                          {
                                              int i = Random.Range(0, _vectors.Count);
                                              _currentMove = _vectors[i];

                                              _disposableTimer = null;
                                          });
        }
    }
}
