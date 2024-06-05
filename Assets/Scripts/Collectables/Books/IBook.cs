using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBook
{
    public int bookLevelIncreaseCount { get; set; }
    public int bookAnimationSpeed { get; set; }
    public Vector3 bookAnimationVector { get; set; }
    public bool isTaken { get; set; }
    public void SetTaken();
}
