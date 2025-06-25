using UnityEngine;

public class ColisorPlayer : MonoBehaviour
{
    public float Life = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisao detectada " + collision.gameObject.name);

        if (collision.gameObject.name == "Enemy")
        {
            Life = Life - 1;
        }   
        if (collision.gameObject.name == "Vida")
        {
            Life = Life + 1;
        } 
        if (Life <= 0)
            {
                Destroy(gameObject); // Destroi o player
                Destroy(collision.gameObject); // Destroi o projetil (opcional)
            }
    }
    // Update is called once per frame
    void Update()
    {

    }
}