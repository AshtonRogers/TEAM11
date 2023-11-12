using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefault : MonoBehaviour, Enemy
{
    //Enemy Varibles - PG
    public string EnemyName = "Enemy Default";
    public int m_Value = 1;
    public int m_Health = 6;
    public float m_Speed  = 1;
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
        throw new System.NotImplementedException(); //Damage Here
    }

    public void Initialize()
    {
        //m_TowerRef = GameObject.Find("TownTower"); //Setting the tower refrence 
        gameObject.tag = "Enemies"; //Setting the Gameobject Tag
        gameObject.name = EnemyName; //Setting the GameObject Name
        isActive = true;
    }

    public void MoveCharacter() 
    {
        transform.position = Vector2.MoveTowards(transform.position, m_TowerRef.transform.position, m_Speed * Time.deltaTime); //Moving the Enemy towarads the tower 
    }


    public int UpdateHealth() 
    {
        if (m_Health > 0)
        {
            Debug.Log(m_Health - 1);
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
        if (isActive == true)
        {
            MoveCharacter();
        }
    }
}
