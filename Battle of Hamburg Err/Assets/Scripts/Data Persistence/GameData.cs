using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public int Money, playerLevel, playerXP, xpUntilNextLevel;
    public GameData()
    {
        Money = 1000;
        playerXP = 0;
        playerLevel = 1;
        xpUntilNextLevel = 750;
    }

}
