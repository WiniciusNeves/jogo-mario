using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            string cenaAtual = SceneManager.GetActiveScene().name;

            switch (cenaAtual)
            {
                case "Fase1":
                    SceneManager.LoadScene("Fase2");
                    break;
                case "Fase2":
                    SceneManager.LoadScene("Fase3");
                    break;
                case "Fase3":
                    SceneManager.LoadScene("Menu"); 
                    break;
                default:
                    StartCoroutine(EsperarEFinalizar());
                    Debug.LogWarning("Cena atual n�o reconhecida.");
                    break;
            }
        }
    }

    private IEnumerator EsperarEFinalizar()
    {
        Destroy(this.gameObject);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
    }
}
