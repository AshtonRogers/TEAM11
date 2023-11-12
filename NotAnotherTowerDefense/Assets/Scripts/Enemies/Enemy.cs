using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy //Enemy Interface for the Factory Desgin Pattern - PG 
{

    int DealDamage(); 
    int UpdateHealth();
    void MoveCharacter();
    void SetTowerRef();
}
