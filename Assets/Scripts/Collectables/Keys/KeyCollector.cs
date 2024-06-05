using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyCollector : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI redKeyCountText;
    public TextMeshProUGUI blueKeyCountText;

    [Header("Transform")]
    public Transform iconPos;

    private Camera cam;


    private List<int> keys = new List<int>();
    private int redKeyCounter = 0;
    private int blueKeyCounter = 0;

    public static KeyCollector instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        cam = Camera.main;   
    }

    public void AddKey(int keyID)
    {
        if (keyID == 0)
            redKeyCounter++;
        else
            blueKeyCounter++;

        KeyUIController();
        
        keys.Add(keyID);
    }
    public void RemoveKey(int keyID)
    {
        keys.Remove(keyID);
    }
    public bool UseKey(int keyID)
    {
        if (keys.Contains(keyID))
        {
            RemoveKey(keyID);
            
            if (keyID == 0)
                redKeyCounter--;
            else
                blueKeyCounter--;

            KeyUIController();

            return true;
        }
        return false;
    }

    private void KeyUIController()
    {
        redKeyCountText.text = "x" + redKeyCounter;
        blueKeyCountText.text = "x" + blueKeyCounter;
    }

    public Vector3 GetIconPosition(Vector3 target)
    {
        Vector3 uiPos = iconPos.position;
        uiPos.z = (target - cam.transform.position).z;

        Vector3 result = cam.ScreenToWorldPoint(uiPos);

        return result;
    }

}
