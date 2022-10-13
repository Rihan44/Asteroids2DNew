using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    public int puntaje = 3;

    //public TextMeshProUGUI puntosAsteroid;
    //public int puntajeAsteroid = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntos.text = puntaje.ToString("0");
        //puntosAsteroid.text = puntajeAsteroid.ToString("0");
    }

    public int RestaPuntos()
    {
        return puntaje -= 1;
    }
    //public int SumaPuntos()
    //{
    //    return puntajeAsteroid += 1;
    //}
}
