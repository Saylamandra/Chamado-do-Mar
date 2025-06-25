using UnityEngine;

public class RotacaoEngrenagem : MonoBehaviour
{
    public float velocidadeRotacao = 50f; 

    void Update()
    {
        transform.Rotate(0f, 0f, velocidadeRotacao * Time.deltaTime);
    }
}
