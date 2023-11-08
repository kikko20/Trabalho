using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TemporizadorBoss : MonoBehaviour
{
    public BossScript boss; // Referência ao script do boss
    public float tempoParaDestruirBoss = 20.0f; // Tempo em segundos para destruir o boss
    public float tempoParaResetarFase = 40.0f; // Tempo em segundos para resetar a fase

    private bool temporizadoresAtivos = false;

    private void Update()
    {
        if (boss.vida <= 0 && !temporizadoresAtivos)
        {
            StartCoroutine(DestruirBossDepoisDe(tempoParaDestruirBoss));
            StartCoroutine(ResetarFaseDepoisDe(tempoParaResetarFase));
            temporizadoresAtivos = true;
        }
    }

    private IEnumerator DestruirBossDepoisDe(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        Destroy(boss.gameObject);
    }

    private IEnumerator ResetarFaseDepoisDe(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        // Adicione aqui a lógica para resetar a fase, como recarregar a cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena atual
    }
}