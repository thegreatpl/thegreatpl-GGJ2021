using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [Serializable]
    public class MusicObj
    {
        public string Name;

        public string[] Tags; 

        public AudioClip AudioClip; 
    }
}
