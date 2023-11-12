using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy //Enemy Interface for the Factory Desgin Pattern - PG 
{
    public string EnemyType { get; set; }
    public int Value { get; set; }
    public int Health { get; set; }
    public float Speed { get; set; }
    public int Damage { get; set; }

    public int DealDamage(); 
    public int UpdateHealth();
    public void MoveCharacter();
    public void Initialize();
}
