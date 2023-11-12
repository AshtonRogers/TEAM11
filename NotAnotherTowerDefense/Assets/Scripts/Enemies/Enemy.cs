using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy
{

    float DealDamage();
    float UpdateHealth();
    void MoveCharacter();
}
