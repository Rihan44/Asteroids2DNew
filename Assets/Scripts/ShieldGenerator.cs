using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGenerator : MonoBehaviour
{
    public static int shield_min = 2;
    public static int shield_max = 3;
    public static float limitX = 12F;
    public static float limitY = 7F;
    void Start()
    {
    }

    void Update()
    {
        
    }

    public static void GeneradorEscudo(GameObject shield)
    {
        int shieldInGame = Random.Range(shield_min, shield_max);

        for (int i = 0; i < shieldInGame; i++)
        {
              Vector3 position = new Vector3(Random.Range(-limitY, limitX), Random.Range(limitY, -limitX));
              Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 0f));
              Instantiate(shield, position, Quaternion.Euler(rotation));
        }
    }
}
