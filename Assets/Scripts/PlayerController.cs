using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            jump();  
        }
    }

    void jump() {

        if(isInTheGround()) {
            m_Rigidbody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
        
    }

    //Raycast devuelve un booleano
    bool isInTheGround() {
        float distanceRay = 1f;
        if (Physics2D.Raycast(this.transform.position, Vector2.down, distanceRay, groundMask)) {
            return true;
        } else {
            return false;
        }
    }


}
