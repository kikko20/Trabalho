using UnityEngine;
using UnityEngine.UI;

public class VidaBossUI : MonoBehaviour
{
    public Text textoVida;
    public BossScript boss; // Referência ao script do boss

    void Update()
    {
        // Atualiza o texto com a vida do boss
        textoVida.text = "Vida do Boss: " + boss.vida.ToString();
    }
}