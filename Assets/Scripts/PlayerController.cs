using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float forceAmount = 1000f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {    
          
    if (Input.GetKey(KeyCode.A))    
        {         
        rb.AddForce(Vector3.left * forceAmount * Time.deltaTime);     
        }   
    if (Input.GetKey(KeyCode.D))
        {      
         rb.AddForce(Vector3.right * forceAmount * Time.deltaTime);    
        }   
    }
}
