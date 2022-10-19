using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    public static Botones botones;
    public Button boton;
    private void Awake()
    {
        botones = this;
    }
    void Start()
    {
        boton = GetComponent<Button>();
        boton.gameObject.SetActive(true);
    }

    void Update()
    {

 
    }

    public void CargarEscena()
    {
        // Esto vuelve a poner el juego en marcha y vuelve a quitar el boton y el texto para que no se vean
        if (boton.name.Equals("paused"))
        {
            boton.gameObject.SetActive(false);
            Time.timeScale = 1;
            UIManager.instancia.paused.gameObject.SetActive(false);
        }

        if (boton.name.Equals("play"))
        {
            SceneManager.LoadScene("PantallaInicio");
            Time.timeScale = 1;
        }

        if (boton.name.Equals("start"))
        {
            SceneManager.LoadScene("Game");
            Debug.Log("EY");
        }
    }
}
