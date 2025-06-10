using UnityEngine;

public class BolaDeFogo : MonoBehaviour
{
    public float amplitude = 4f;  
    public float velocidade = 4f; 

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        float deslocamentoY = Mathf.Sin(Time.time * velocidade) * amplitude;
        transform.position = posicaoInicial + new Vector3(0, deslocamentoY, 0);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            Player player = outro.GetComponent<Player>();
            if (player != null)
            {
                player.Damage(); 
            }
        }
    }
}
