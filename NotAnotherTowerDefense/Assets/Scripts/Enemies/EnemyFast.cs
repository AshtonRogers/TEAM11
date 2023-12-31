using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFast : MonoBehaviour, Enemy
{
    //Enemy Varibles - PG
    public string EnemyName = "Enemy Fast";
    public int m_Value = 2;
    public int m_Health = 3;
    public float m_Speed = 1.5f;
    public int m_Damage = 5;
    private bool isActive = false;
    [SerializeField] private GameObject m_TowerRef;
    [SerializeField] private Transform m_Transform;

    public int Value { get => m_Value; set => m_Value = value; }
    public int Health { get => m_Health; set => m_Health = value; }
    public float Speed { get => m_Speed; set => m_Speed = value; }
    public int Damage { get => m_Damage; set => m_Damage = value; }
    public string EnemyType { get => EnemyName; set => EnemyName = value; }

    public int DealDamage()
    {
        return m_Damage;
    }

    public void MoveCharacter()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_TowerRef.transform.position, m_Speed * Time.deltaTime); //Moving the Enemy towarads the tower - PG
    }

    public void Initialize()
    {
        //m_TowerRef = GameObject.Find("TownTower"); //Setting the tower refrence 
        gameObject.tag = "Enemies"; //Setting the Gameobject Tag
        gameObject.name = EnemyName; //Setting the GameObject Name
        isActive = true;
    }

    public int UpdateHealth(int _IncomingDmg)
    {
        if (m_Health > 0)
        {
            Debug.Log(m_Health - _IncomingDmg);
            return m_Health - _IncomingDmg;
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
        if (isActive == true)
        {
            MoveCharacter();
        }

        if (m_Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
