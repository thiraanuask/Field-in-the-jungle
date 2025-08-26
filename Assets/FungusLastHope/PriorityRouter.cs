using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;


namespace LastHopeStudio.Fungus
{
    public class PriorityRouter : MonoBehaviour
    {
        public Behaviour[] componentOutsideFungusPriority;
        public Behaviour[] componentInsideFungusPriority;

        private void OnEnable()
        {
            FungusPrioritySignals.OnFungusPriorityStart += FungusPrioritySignals_Start;
            FungusPrioritySignals.OnFungusPriorityEnd += FungusPrioritySignals_End;
        }


        private void OnDisable()
        {
            FungusPrioritySignals.OnFungusPriorityStart -= FungusPrioritySignals_Start;
            FungusPrioritySignals.OnFungusPriorityEnd -= FungusPrioritySignals_End;
        }

        private void FungusPrioritySignals_End()
        {
            foreach (var item in componentOutsideFungusPriority)
            {
                item.enabled = true;
            }

            foreach (var item in componentInsideFungusPriority)
            {
                item.enabled = false;
            }
        }


        private void FungusPrioritySignals_Start()
        {
            foreach (var item in componentOutsideFungusPriority)
            {
                item.enabled = false;
            }

            foreach (var item in componentInsideFungusPriority)
            {
                item.enabled = true;
            }
        }
    }
}