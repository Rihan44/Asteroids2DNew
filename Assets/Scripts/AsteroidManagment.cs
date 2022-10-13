using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManagment : MonoBehaviour
{
    public int asteroids_min = 2;
    public int asteroids_max = 3;
    public float limitX = 12F;
    public float limitY = 7F;
    public GameObject[] asteroides;

    // Start is called before the first frame update
    void Start()
    {
        int asteroiedes = Random.Range(asteroids_min, asteroids_max);

        for(int i = 0; i < asteroiedes; i++)
        {
            for(int x = 0; x < asteroides.Length; x++)
            {
                Vector3 position = new Vector3(Random.Range(-limitY, limitX), Random.Range(limitY, -limitX));
                Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 360f));
                Instantiate(asteroides[x], position, Quaternion.Euler(rotation));
            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
