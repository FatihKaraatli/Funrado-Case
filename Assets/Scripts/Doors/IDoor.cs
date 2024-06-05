using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDoor
{
    public int doorColorID { get; set; }
    public bool isLockedOn { get; set; }
    public void SetLockOn();
}
