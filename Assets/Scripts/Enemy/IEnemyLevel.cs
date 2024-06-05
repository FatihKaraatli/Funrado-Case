using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyLevel
{
    public int enemyLevelCount { get; set; }

    public void LevelColorChange(int playerLevel);
}
