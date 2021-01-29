using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [Serializable]
    public class AnimationLayerObj
    {
        public string Name;

        public string layer;

        public List<AnimationObj> Animations; 
    }

    [Serializable]
    public class AnimationObj
    {
        public string Name;

        public Sprite[] Sprites; 
    }
}
