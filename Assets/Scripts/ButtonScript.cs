using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public static Button boton;
    public static Button botonMenu;
    void Start()
    {
        boton = GetComponent<Button>();
        boton.gameObject.SetActive(false);

        botonMenu = GetComponent<Button>();
        botonMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void CargarEscena()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        
    }
    //public void Inicio()
    //{
    //    SceneManager.LoadScene(1);
    //}
}
