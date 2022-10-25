using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public float speed_min;
    public float speed_max;
    //public GameObject bala;
    private SoundManager soundManager;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direcion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direcion = direcion * Random.Range(speed_min, speed_max);
        rb.AddForce(direcion);
        soundManager = FindObjectOfType<SoundManager>();
    }


    void Update()
    {
        //if(Input.GetButtonDown("Jump"))
        //{
        //    soundManager.SeleccionaAudio(0, 0.2f);
        //    GameObject balaDestroy = Instantiate(bala, transform.position, transform.rotation);
        //    Destroy(balaDestroy, 2.8f);
        //}
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bala")
        {
            GameManager.instancia.puntuacion += 100;
            soundManager.SeleccionaAudio(2, 0.5f);
            Destroy(gameObject);
        }

        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<ShipMovement>().Death();
        }
    }
}
