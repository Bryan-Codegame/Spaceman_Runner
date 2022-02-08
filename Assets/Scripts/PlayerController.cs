using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float distanceRay = 1f;
    
    public float jumpForce = 0.6f;

    Rigidbody2D m_Rigidbody;

    public LayerMask groundMask; 

    bool isInAir;

    private void Awake() {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Debug.Log("Press Space");
            Jump();  
        }

        
        //Debug RayCast
        Debug.DrawRay(this.transform.position, Vector2.down * distanceRay, Color.green);
    }

    void Jump() {

        //Si está en el piso va a saltar 
        if(isInTheGround()) {
            m_Rigidbody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
        
    }

    //Raycast devuelve un booleano
    bool isInTheGround() {
      
        if (Physics2D.Raycast(this.transform.position, Vector2.down, distanceRay, groundMask)) {
            return true;
        } else {
            return false;
        }
    }


}
