using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnWater : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colidiu com: " + collision.gameObject.name);

        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Debug.Log("Tocou na água! Reiniciando...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
