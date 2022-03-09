using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_turnSpeed;
    [SerializeField] private float m_jumpSpeed;
    
    private Animator m_robotAnim;
    private Rigidbody m_rb;
    private Vector3 m_originalPosition; 
    
    

    

    // private bool m_jumping  = false;

    // will be triggered when the object is instantiated 
    private void OnEnable()
    {
        AudioManager.instance.Play("robot-bleep");
        
        m_robotAnim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody>();

        m_originalPosition = transform.position;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        
       // Debug.Log(transform.position.y);
        // Debug.Log("123");
        // hamdling movements - Joystick magnitude > dead zone
        // if (m_joystick.Direction.magnitude > m_deadZone)
        if (true)
        {
            //Debug.Log(transform.position.y);
            m_rb.AddForce(transform.forward * m_moveSpeed);
            m_robotAnim.SetBool("Walk_Anim", true);
            AudioManager.instance.PlayOnce("robot-walk");
        }
        else
        {
            m_robotAnim.SetBool("Walk_Anim", false);
            AudioManager.instance.Stop("robot-walk");
        }

        // handling rotation
        Vector3 m_targetDirection = new Vector3(
            0, //m_joystick.Direction.x, 
            0,
            0 //m_joystick.Direction.y 
        );

        Vector3 m_direction = Vector3.RotateTowards(
            transform.forward, 
            m_targetDirection, 
            Time.deltaTime * m_turnSpeed,
            0.0f
        );
        
        transform.rotation = Quaternion.LookRotation(m_direction);


    }


    public void Jump()
    {
        //DebugManager.Instance.Echo("jump button was pressed");
        
        // DebugManager.Instance.Echo("jumping");
        m_rb.AddForce(transform.up * m_jumpSpeed, ForceMode.Impulse);
    }

}
