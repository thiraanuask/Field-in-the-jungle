using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LastHopeStudio.Fungus
{
    public class ForceCursorVisible : MonoBehaviour
    {
        public bool CursorLocked = true;

        void Update()
        {
            Cursor.visible = !CursorLocked;
            Cursor.lockState = CursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}