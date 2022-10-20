using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public int vidas;
    public int puntuacion;
    // Esto se ejecuta antes del start
    private void Awake()
    {
        instancia = this;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Pone el juego en pausa
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            UIManager.instancia.paused.gameObject.SetActive(true);
            Botones.botones.boton.gameObject.SetActive(true);
        }
    }
}
