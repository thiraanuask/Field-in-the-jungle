using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LastHopeStudio.GameEvent
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listenersList = new List<GameEventListener>();

        public void Raise()
        {
            foreach (var gel in listenersList)
            {
                gel.OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            listenersList.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            listenersList.Remove(listener);
        }
    }
}