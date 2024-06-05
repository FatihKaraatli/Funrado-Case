using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CountDownTimer;

public interface IKey
{
    public int keyColorID { get; set; }
    public int keyAnimationSpeed { get; set; }
    public Vector3 keyAnimationVector { get; set; }
    public bool isTaken { get; set; }
    public void SetTaken();
}
