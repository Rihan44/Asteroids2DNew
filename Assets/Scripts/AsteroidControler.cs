using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class AsteroidControler : MonoBehaviour
{
    public float speed_min;
    public float speed_max;
    public AsteroidManagment manager;
    Rigidbody2D rb;
    private SoundManager soundManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direcion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direcion = direcion * Random.Range(speed_min, speed_max);
        rb.AddForce(direcion);
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Explota()
    {
        // Asteroide Grande
        if (transform.localScale.x == 2f)
        {
            //Generamos dos asteroides medianos al destruir el grande
            GameObject temp1 = Instantiate(manager.asteroidesPrefabs[1], transform.position, transform.rotation);
            temp1.GetComponent<AsteroidControler>().manager = manager;

            GameObject temp2 = Instantiate(manager.asteroidesPrefabs[1], transform.position, transform.rotation);
            temp2.GetComponent<AsteroidControler>().manager = manager;
            soundManager.SeleccionaAudio(2, 0.5f);
        }

        // Asteroide mediano
        if (transform.localScale.x == 1.5f)
        {
            //Generamos dos asteroides pequeños al destruir el mediano
            GameObject temp1 = Instantiate(manager.asteroidesPrefabs[0], transform.position, transform.rotation);
            temp1.GetComponent<AsteroidControler>().manager = manager;

            GameObject temp2 = Instantiate(manager.asteroidesPrefabs[0], transform.position, transform.rotation);
            temp2.GetComponent<AsteroidControler>().manager = manager;
            soundManager.SeleccionaAudio(2, 0.5f);
        }

        // Asteroide pequeño
        if (transform.localScale.x == 1f)
        {
            //Generamos dos asteroides mas pequeños al destruir el pequeño
            GameObject temp1 = Instantiate(manager.asteroidesPrefabs[0], transform.position, transform.rotation);
            temp1.GetComponent<AsteroidControler>().manager = manager;
            temp1.transform.localScale = transform.localScale * 0.7f;

            GameObject temp2 = Instantiate(manager.asteroidesPrefabs[0], transform.position, transform.rotation);
            temp2.GetComponent<AsteroidControler>().manager = manager;
            temp2.transform.localScale = transform.localScale * 0.7f;
            soundManager.SeleccionaAudio(2, 0.5f);
        }
        soundManager.SeleccionaAudio(2, 0.5f);
        Destroy(gameObject);

    }

    // Destruye la nave
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            int puntos = collision.gameObject.GetComponent<PointsLife>().RestaPuntos();
            if(puntos < 0)
            {
               collision.gameObject.GetComponent<ShipMovement>().Death();
               Muerte.muerteTexto.gameObject.SetActive(true);
               ButtonScript.boton.gameObject.SetActive(true);
               ButtonScript.botonMenu.gameObject.SetActive(true);
            }
            Destroy(gameObject);
        }

        if (collision.tag == "Bala")
        {
            PuntosAsteroides.puntuacion += 1;
            //int puntos = PuntosAsteroides.puntuacion;

            collision.gameObject.GetComponent<BulletController>().DestruyeBala();
            Explota();
        }
    }

}
