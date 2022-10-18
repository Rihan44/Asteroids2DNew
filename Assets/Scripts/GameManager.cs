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
   
    }
}
