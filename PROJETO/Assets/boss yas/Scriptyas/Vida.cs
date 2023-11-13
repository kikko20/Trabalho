using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    private int vidaAtual;

    private int vidaTotal = 600;

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
        
    }

    public void AplicarDano(int dano)
    {
        vidaAtual -= dano;
        
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);
    }
}
