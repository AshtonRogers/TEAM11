using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy //Enemy Interface for the Factory Desgin Pattern - PG 
{
    //Interface Varibles
    public string EnemyType { get; set; }
    public int Value { get; set; }
    public int Health { get; set; }
    public float Speed { get; set; }
    public int Damage { get; set; }

    //Interface Functions
    public int DealDamage(); //Enemy Dealing Dmg
    public int UpdateHealth(int _IncomingDmg); //Enemy Helth Update
    public void MoveCharacter(); //Enemy Movement 
    public void Initialize(); //Enemy Initilisation 
}
