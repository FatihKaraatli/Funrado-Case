using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Books : MonoBehaviour, IBook
{
    [field: SerializeField] public int bookLevelIncreaseCount { get; set; }
    [field: SerializeField] public int bookAnimationSpeed { get; set; }
    [field: SerializeField] public Vector3 bookAnimationVector { get; set; }
    public bool isTaken { get; set; }

    public void Update()
    {
        transform.Rotate(bookAnimationVector * bookAnimationSpeed * Time.deltaTime);
    }


    public void SetTaken()
    {
        SFXController.instance.PlayLevelUpSound();

        PlayerLevelController.instance.SetLevel(bookLevelIncreaseCount);
        Destroy(gameObject);
    }
}
