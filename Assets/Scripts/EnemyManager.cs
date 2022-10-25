using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static float limitX = 12F;
    public static float limitY = 7F;
    public static int enemy_min = 1;
    public static int enemy_max = 2;
    GameObject enemigos;
    public static EnemyManager manager;

    void Start()
    {


    }

    void Update()
    {

    
    }

    public static void InstanciarEnemy(GameObject enemy)
    {
        int enemyInGame = Random.Range(enemy_min, enemy_max);

        for (int i = 0; i < enemyInGame; i++)
        {
            Vector3 position = new Vector3(Random.Range(-limitY, limitX), Random.Range(limitY, -limitX));

            Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 360f));
            Instantiate(enemy, position, Quaternion.Euler(rotation));
        }
    }
}
