using UnityEngine;
public class ParallaxCenario : MonoBehaviour
{
    public Transform floor;
    public Transform Fundo;
    public float floorSpeed = 2f;
    public float FundoSpeed = 0.5f;

    void Update()
    {
        Vector3 deslocamentofloor = Vector3.back * floorSpeed * Time.deltaTime;
        Vector3 deslocamentoFundo = Vector3.back * FundoSpeed * Time.deltaTime;

        floor.position += deslocamentofloor;
        Fundo.position += deslocamentoFundo;
    }
}
