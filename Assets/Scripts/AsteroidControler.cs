using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControler : MonoBehaviour
{
    public float speed_min;
    public float speed_max;
    public AsteroidManagment manager;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direcion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direcion = direcion * Random.Range(speed_min, speed_max);
        rb.AddForce(direcion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Explota()
    {
        // Asteroide Grande
        if (transform.localScale.x == 1.5f)
        {
            //Generamos dos asteroides medianos al destruir el grande
            GameObject temp1 = Instantiate(manager.asteroidesPrefabs[1], transform.position, transform.rotation);
            temp1.GetComponent<AsteroidControler>().manager = manager;

            GameObject temp2 = Instantiate(manager.asteroidesPrefabs[1], transform.position, transform.rotation);
            temp2.GetComponent<AsteroidControler>().manager = manager;
        }

        // Asteroide mediano
        if (transform.localScale.x == 1f)
        {
            //Generamos dos asteroides pequeños al destruir el mediano
            GameObject temp1 = Instantiate(manager.asteroidesPrefabs[0], transform.position, transform.rotation);
            temp1.GetComponent<AsteroidControler>().manager = manager;

            GameObject temp2 = Instantiate(manager.asteroidesPrefabs[0], transform.position, transform.rotation);
            temp2.GetComponent<AsteroidControler>().manager = manager;
        }

        // Asteroide pequeño
        if (transform.localScale.x == 0.6f)
        {
            //Generamos dos asteroides mas pequeños al destruir el pequeño
            GameObject temp1 = Instantiate(manager.asteroidesPrefabs[0], transform.position, transform.rotation);
            temp1.GetComponent<AsteroidControler>().manager = manager;
            temp1.transform.localScale = transform.localScale * 0.5f;

            GameObject temp2 = Instantiate(manager.asteroidesPrefabs[0], transform.position, transform.rotation);
            temp2.GetComponent<AsteroidControler>().manager = manager;
            temp2.transform.localScale = transform.localScale * 0.5f;

        }

        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<ShipMovement>().Death();
            Destroy(gameObject);
        }
    }
}
