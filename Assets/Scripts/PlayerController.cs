using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 startPos;

    //Animation const string
    const string ON_THE_GROUND = "isOnTheGround";
    const string IS_ALIVE = "isAlive";

    [SerializeField]
    private float distanceRay = 1f;
    
    public float jumpForce = 0.6f;

    //Speed
    public float speedPlayer = 2.0f;

    //Components
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
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame) {
            //Input.GetButtonDown("Jump")
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {            
                Jump();  
            }

            m_Animator.SetBool(ON_THE_GROUND, isOnTheGround());
        }
         
        
        //Debug RayCast
        Debug.DrawRay(this.transform.position, Vector2.down * distanceRay, Color.green);
    }

    //Se usa cuando el movimiento es por físicas 
    void FixedUpdate() 
    {
        // Hacer que corra todo el tiempo
        if (GameManager.sharedInstance.currentGameState == GameState.inGame) {
            if (m_Rigidbody.velocity.x < speedPlayer) {
                m_Rigidbody.velocity = new Vector2(speedPlayer, m_Rigidbody.velocity.y);
            }
        } else {
            m_Rigidbody.velocity = new Vector2(0, m_Rigidbody.velocity.y);
        }

    }

    /* ----------------------- */
    /* Functions */

    //StartGame - Restart the game with initial params.
    public void StartGame() {
        m_Animator.SetBool(ON_THE_GROUND, true);
        m_Animator.SetBool(IS_ALIVE, true);

        /* Resuelve el problema de que al reiniciar el primer frame muestra al player 
        en su animación de muerte cuando desde un inicio debe aparecer vivo por eso se tarda 0.2 seg y ya resetea la posición*/ 
        Invoke("ResetPosition", 0.2f);
    }

    void ResetPosition() {
        this.transform.position = startPos;
        this.m_Rigidbody.velocity = Vector2.zero;
    }

    //Jump
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

    public void Die() {
        m_Animator.SetBool(IS_ALIVE, false);
        GameManager.sharedInstance.GameOver();
    }

}
