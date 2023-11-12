using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrong : Enemy
{
    //Enemy Varibles - PG
    public int m_Health = 15;
    public float m_Speed = 0.7f;
    public int m_Damage = 10;
    private GameObject m_TowerRef;
    private Transform m_Transform;

    public int DealDamage()
    {
        throw new System.NotImplementedException();
    }

    public void MoveCharacter()
    {
        m_Transform.position = Vector2.MoveTowards(m_Transform.position, m_TowerRef.transform.position, m_Speed * Time.deltaTime); //Moving the Enemy towarads the tower - PG
    }

    public void SetTowerRef()
    {
        m_TowerRef = GameObject.Find("PlayerTower"); //Setting the tower refrence 
    }

    public int UpdateHealth()
    {
        if (m_Health > 0)
        {
            return m_Health - 1;
        }
        else
        {
            return 0;
        }
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
