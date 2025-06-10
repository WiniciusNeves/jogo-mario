using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float minX = 2f;
    [SerializeField] private float maxX = 150f;

    private void Start()
    {
        
        if (player == null)
        {
            GameObject obj = GameObject.FindWithTag("Mario");
            if (obj != null) player = obj.transform;
        }
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        
        if (player.position.x >= transform.position.x)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }

        
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            transform.position.z
        );
    }
}
