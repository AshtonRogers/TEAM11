using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform m_EnemySpawn;
    [SerializeField] EnemyFactory[] m_EnemyFactories;

    public int m_StartWave = 1;
    public int m_CurrentWave;

    //Currency - PG 
    public int m_Gold;
    public int m_Silver;

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
        
        if (GameObject.FindGameObjectsWithTag("Enemies") == null)
        {
            Debug.Log("SPAWN");
            for (int i = 0; i != m_CurrentWave * 10; i++)
            {

                //EnemyFactory.getEnemy()
                //EnemyFactory.getEnemy("DEFAULT")
                //GameObject newEnemy = EnemyFactory.getEnemy("DEFAULT");

                //GameObject newEnemy = Instantiate(m_EmptyEnemyPrefab, m_EnemySpawn.transform.position, m_EnemySpawn.rotation); //Creating the Enemy 
                //newEnemy.tag = "Enemies"; //Setting the New Enemies Tag 

                //newEnemy = EnemyFactory.getEnemy("DEFAULT");
                //newEnemy.AddComponent < EnemyFactory.getEnemy("DEFAULT") >
                //newEnemy.AddComponent<EnemyDefault>();

            }
        } 
    }
    void SetEnemyPath()
    {

    }

    void GenerateCurrency()
    {
        //Changer pet 10 levels 

    }
}
