using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 70f;
    public float speedRotate = -100f;
    public int life = 4;

    Rigidbody2D rb2d;
    Animator anim;
    public GameObject bala;
    public GameObject bala2;
    GameObject balaDestroy;
    GameObject bala2Destroy;
    public Collider2D colBala;

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent dice que en el objeto actual tengo x componentes y quiero buscar en este caso el que esta entre <> en este caso RigiBody
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // Desactivo el collider de la bala
        //colBala.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");

        // Este if evita que no puedas ir marcha atrás
        if (vertical > 0)
        {
            //Vector3 movimiento = new Vector3(0, vertical);
            // transform.up pilla el vector verde el que mira hacia arriba donde apunta la nave en este caso
            //transform.position += transform.up * vertical * speed * Time.deltaTime;
            rb2d.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("impulsing", true); // Aqui accedemos al parametro de la animacion 
        }
        else
        {
            anim.SetBool("impulsing", false);
        }

        float horizontal = Input.GetAxis("Horizontal");

        Vector3 moveRote = new Vector3(0, 0, horizontal);
        transform.eulerAngles += moveRote * speedRotate * Time.deltaTime;

        // Disparos
        if (Input.GetButtonDown("Jump"))
        {
            // Aqui hago que los disparos roten al igual que la nave segun su posicion
            Vector3 pos = new Vector3(0, 0, transform.position.x);
            Vector3 shootsRotation = pos + transform.rotation.eulerAngles;
            shootsRotation.x += Time.deltaTime * -100f;

            balaDestroy = Instantiate(bala, new Vector3(transform.position.x + -0.14f, transform.position.y, 0), Quaternion.Euler(shootsRotation));
            bala2Destroy = Instantiate(bala2, new Vector3(transform.position.x + 0.06f, transform.position.y, 0), Quaternion.Euler(shootsRotation));
            colBala.isTrigger = true;
        }

       // colBala.isTrigger = false;

        Destroy(balaDestroy, 2.8f);
        Destroy(bala2Destroy, 2.8f);

        // Si es true es que el collider esta desactivado
        if(colBala.isTrigger == true)
        {
            Debug.Log("Collider de bala desactivado");
            // False activa el collider de bala
            //colBala.isTrigger = false;
        } else
        {
            Debug.Log("Collider de bala ACTIVADA");
        }

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Asteroid"))
    //    {

    //        life--;
    //        Debug.Log(life);
    //        if(life == 0)
    //        {
    //           Destroy(gameObject);
    //        }
    //    }
    //}

}
