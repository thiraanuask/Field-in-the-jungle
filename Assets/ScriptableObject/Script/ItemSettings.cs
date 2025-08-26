using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LastHopeStudio
{
    [CreateAssetMenu(fileName = "ItemSettings", menuName = "LastHopeStudio/ItemSettings",order = 1)]
    public class ItemSettings : ScriptableObject
    {
        public int ammo;
        public int firstaid;
    }
}