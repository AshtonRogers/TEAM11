using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform m_EnemySpawn;
    [SerializeField] EnemyFactory[] m_EnemyFactories;
    private EnemyFactory m_CurrentFactory;

    public int m_StartWave = 1;
    public int m_CurrentWave;
    public int m_ObjectiveHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentWave = m_StartWave;
        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWave()
    {
        
        //if (GameObject.FindGameObjectsWithTag("Enemies") == null)
        //{
            Debug.Log("SPAWN");
            for (int i = 0; i != m_CurrentWave; i++)
            {
                m_CurrentFactory = m_EnemyFactories[Random.Range(0, m_EnemyFactories.Length)];

                m_CurrentFactory.GetEnemy();

            }
        //} 
    }

    public void TakeDamage(int damage)
    {
        m_ObjectiveHealth -= damage;

        if(m_ObjectiveHealth <= 0)
        {
            //endgame
        }
    }

    void SetEnemyPath()
    {

    }
}
