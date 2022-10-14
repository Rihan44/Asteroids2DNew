using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsLife : MonoBehaviour
{
    public TextMeshProUGUI puntosVida;
    public int puntajeVida = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntosVida.text = puntajeVida.ToString("0");
    }

    public int RestaPuntos()
    {
        return puntajeVida -= 1;
    }
}
