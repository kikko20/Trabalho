using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    private int vidaAtual;

    private int vidaTotal = 500;

    [SerializeField] private BarraDeVida barraDeVida;
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaTotal;
        
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AplicarDano(5);
        }
    }

    private void AplicarDano(int dano)
    {
        vidaAtual -= 10;
        
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);
    }
}
