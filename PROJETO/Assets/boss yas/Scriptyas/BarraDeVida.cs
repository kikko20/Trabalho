using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
   [SerializeField] private Image barradeVidaImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlterarBarraDeVida(int vidaAtual, int vidaMaxima)
    {
        barradeVidaImage.fillAmount = (float) vidaAtual / vidaMaxima;
    }
}
