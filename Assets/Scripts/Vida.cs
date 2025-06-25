using UnityEngine;

public class Vida : MonoBehaviour
{

    void Start()
    {
        
    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisão detectada com " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("player"))
        {
         Destroy(gameObject); // Destroi a vida
        }
    }

    void Update()
    {
        
    }
}

