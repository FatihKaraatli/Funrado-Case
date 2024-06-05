using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CountDownTimer;

public class Doors : MonoBehaviour , IDoor
{
    [field: SerializeField] public int doorColorID { get; set; } // 0 = Red Door , 1 = Blue Door
    public bool isLockedOn { get; set; } = false;

    [Header("Timer")]
    public Timer scaleEffectTimer;

    private void Update()
    {
        if (isLockedOn)
        {
            this.gameObject.GetComponent<Collider>().enabled = false;  
            scaleEffectTimer.UpdateTimer();
            if (scaleEffectTimer.Done())
            {
                Destroy(this.gameObject);
            }
            transform.localScale = Vector3.Lerp(transform.localScale , Vector3.zero, scaleEffectTimer.NormalizedTime);
        }
    }

    public void SetLockOn()
    {
        SFXController.instance.PlayLevelUpSound();
        isLockedOn = KeyCollector.instance.UseKey(doorColorID);
    }


}
