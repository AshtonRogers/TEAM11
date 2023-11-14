using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstract Class for the Creation of Enemy Factories

public abstract class EnemyFactory : MonoBehaviour
{
    public abstract Enemy GetEnemy();
}



