using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefault : Enemy
{
    public float m_Health = 5;
    public float m_Speed  = 1;
    public float m_Damage = 5;

    public float DealDamage()
    {
        throw new System.NotImplementedException();
    }

    public void MoveCharacter()
    {
        throw new System.NotImplementedException();
    }

    public float UpdateHealth()
    {
        return m_Health - 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
