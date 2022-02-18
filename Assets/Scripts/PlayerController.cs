using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Animation const string
    const string ON_THE_GROUND = "isOnTheGround";
    const string IS_ALIVE = "isAlive";

    [SerializeField]
    private float distanceRay = 1f;
    
    public float jumpForce = 0.6f;

    //Speed
    public float speedPlayer = 2.0f;

    Rigidbody2D m_Rigidbody;
    Animator m_Animator;

    public LayerMask groundMask; 

    bool isInAir;


    private void Awake() {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Animator.SetBool(ON_THE_GROUND, true);
        m_Animator.SetBool(IS_ALIVE, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {            
            Jump();  
        }

        m_Animator.SetBool(ON_THE_GROUND, isOnTheGround()); 
        
        //Debug RayCast
        Debug.DrawRay(this.transform.position, Vector2.down * distanceRay, Color.green);
    }

    //Se usa cuando el movimiento es por físicas 
    void FixedUpdate() 
    {
        if (m_Rigidbody.velocity.x < speedPlayer) {
            m_Rigidbody.velocity = new Vector2(speedPlayer, m_Rigidbody.velocity.y);
        }    
    }
    void Jump() {

        //Si está en el piso va a saltar 
        if(isOnTheGround()) {
            m_Rigidbody.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        } 
    }

    //Raycast devuelve un booleano
    bool isOnTheGround() {
      
        if (Physics2D.Raycast(this.transform.position, Vector2.down, distanceRay, groundMask)) {

            return true;
        } else {
            return false;
        }
    }


}
