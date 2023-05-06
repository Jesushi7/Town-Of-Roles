using System;
using System.Collections;
using UnityEngine;

namespace TownOfRoles
{
    public class WaitForLerp : IEnumerator
    {
        private readonly Action<float> act;

        private readonly float duration;

        private float timer;

        public WaitForLerp(float seconds, Action<float> act)
        {
            duration = seconds;
            this.act = act;
        }

        public object Current => null;

        public bool MoveNext()
        {
            timer = Mathf.Min(timer + Time.deltaTime, duration);
            act(timer / duration);
            return timer < duration;
        }

        public void Reset()
        {
            timer = 0f;
        }
    }
}