using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointsLife : MonoBehaviour
{
    public TextMeshProUGUI puntosVida;
    public int puntajeVida = 3;

    void Start()
    {

    }

    void Update()
    {
        puntosVida.text = puntajeVida.ToString("0");
    }

    public int RestaPuntos()
    {
        return puntajeVida -= 1;
    }
}
