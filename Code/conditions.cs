using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conditions
{
    public struct doorType
    {
        public bool Hot;
        public bool Noisy;
        public bool Safe;
        public float probability;
        public Vector2 range;

        public void assign(bool a_Hot, bool a_Noisy, bool a_Safe, float a_probability)
        {
            Hot = a_Hot;
            Noisy = a_Noisy;
            Safe = a_Safe;
            probability = a_probability;
        }
    }

}
