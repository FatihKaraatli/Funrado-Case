using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterLifeState
{
    public IEnumerator CharacterDead(GameObject character);
    public void CharacterSurvive(GameObject character);
}
