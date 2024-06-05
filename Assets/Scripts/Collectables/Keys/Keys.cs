using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CountDownTimer;

public class Keys : MonoBehaviour , IKey
{
    [field: SerializeField] public int keyColorID { get; set; } // 0 = Red Key , 1 = Blue Key
    [field: SerializeField] public int keyAnimationSpeed { get; set; } 
    [field: SerializeField] public Vector3 keyAnimationVector { get; set; }
    public bool isTaken { get; set; } = false;

    [Header("Timer")]
    public Timer flyTimer;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    public void Update()
    {
        transform.Rotate(keyAnimationVector * keyAnimationSpeed * Time.deltaTime);

        if (isTaken)
        {
            flyTimer.UpdateTimer();
            if (flyTimer.Done())
            {
                KeyCollector.instance.AddKey(keyColorID);
                Destroy(this.gameObject);
            }
            this.gameObject.transform.position = Vector3.Lerp(startPos, KeyCollector.instance.GetIconPosition(startPos), flyTimer.NormalizedTime);
        }
    }

    public void SetTaken()
    {
        SFXController.instance.PlayLevelUpSound();
        isTaken = true; 
    }  
}
