using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AsteroidManagment : MonoBehaviour
{
    public int asteroides;
    public int asteroids_min = 2;
    public int asteroids_max = 3;
    public float limitX = 12F;
    public float limitY = 7F;
    public GameObject[] asteroidesPrefabs;
    public GameObject particulaAsteroide;


    // Start is called before the first frame update
    void Start()
    {
        Instanciar();
    }

    // Update is called once per frame
    void Update()
    {
        if(asteroides <= 0)
        {
            asteroids_min += 2;
            asteroids_max += 2;
            Instanciar();
        }
    }

    public void Instanciar()
    {
        int asteroiedesInGame = Random.Range(asteroids_min, asteroids_max);

        for (int i = 0; i < asteroiedesInGame; i++)
        {
            for (int x = 0; x < asteroidesPrefabs.Length; x++)
            {
                Vector3 position = new Vector3(Random.Range(-limitY, limitX), Random.Range(limitY, -limitX));

                while (Vector3.Distance(position, new Vector3(0,0)) < 2)
                {
                    position = new Vector3(Random.Range(-limitY, limitX), Random.Range(limitY, -limitX));
                }

                Vector3 rotation = new Vector3(0, 0, Random.Range(0f, 360f));
                GameObject clon = Instantiate(asteroidesPrefabs[x], position, Quaternion.Euler(rotation));
                clon.GetComponent<AsteroidControler>().manager = this;
            }
        }
    }
}
