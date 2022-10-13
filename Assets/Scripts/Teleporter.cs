using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public float limiteX = 12F;
    public float limiteY = 7F;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Esto consigue la posicion del objeto
        if (transform.position.y > limiteY)
        {
            // Le pasamos la posicion para que mantega la que tiene al teleportarse
            transform.position = new Vector3(transform.position.x, -limiteY, 0f);
        }

        if (transform.position.y < -limiteY)
        {
            transform.position = new Vector3(transform.position.x, limiteY, 0f);
        }

        if (transform.position.x > limiteX)
        {
            transform.position = new Vector3(-limiteX, transform.position.y, 0f);
        }

        if (transform.position.x < -limiteX)
        {
            transform.position = new Vector3(limiteX, transform.position.y, 0f);
        }
    }
}
