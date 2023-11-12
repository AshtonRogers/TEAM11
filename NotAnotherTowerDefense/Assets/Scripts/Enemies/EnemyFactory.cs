using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyFactory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Enemy getEnemy(string _enemyType) //Get the Object type of the Enemy - PG 
    {

        if (_enemyType == "DEFAULT")
        {
            return new EnemyDefault();
            //return gameObject.AddComponent<EnemyDefault>();
        }
        else if (_enemyType == "FAST")
        {
            return gameObject.AddComponent<EnemyFast>();
        }
        else if (_enemyType == "STRONG")
        {
            return gameObject.AddComponent<EnemyStrong>();
        }
        else
        {
            return null;
        }

    }

    public Enemy getEnemy(string _enemyType) //Get the Object type of the Enemy - PG 
    {

        if (_enemyType == "DEFAULT")
        {
            return new EnemyDefault();
            //return gameObject.AddComponent<EnemyDefault>();
        }
        else if (_enemyType == "FAST")
        {
            return gameObject.AddComponent<EnemyFast>();
        }
        else if (_enemyType == "STRONG")
        {
            return gameObject.AddComponent<EnemyStrong>();
        }
        else
        {
            return null;
        }

    }

}
