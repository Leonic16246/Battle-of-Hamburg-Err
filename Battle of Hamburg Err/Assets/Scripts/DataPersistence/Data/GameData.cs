using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public int health, moneyCount;

    public GameData()
    {
        this.health = 10;
        this.moneyCount = 1000;
    }

}
