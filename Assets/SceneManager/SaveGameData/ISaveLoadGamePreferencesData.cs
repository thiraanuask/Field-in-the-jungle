using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISaveLoadGamePreferencesData
{
 void SaveGamePreferencesData(GamePreferencesData gpd, string location);
 GamePreferencesData LoadGamePreferencesData(string location);
}

