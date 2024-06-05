using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerLevel 
{
    public int playerLevelCount { get; set; }

    public void SetLevel(int increaseCount);
}
