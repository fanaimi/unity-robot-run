using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_turnSpeed;
    [SerializeField] private float m_jumpSpeed;
    [SerializeField] private InputManager m_inputManager;
    
    private Animator m_robotAnim;
    private Rigidbody m_rb;
    private Vector3 m_originalPosition;

    private float m_horizontal, m_vertical;
    private bool m_jump;
    

    

    // private bool m_jumping  = false;

    // will be triggered when the object is instantiated 
    private void OnEnable()
    {
        AudioManager.instance.Play("robot-bleep");
        
        m_robotAnim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody>();

        m_originalPosition = transform.position;
    }

    private void Update()
    {
        m_horizontal = m_inputManager.m_horizontal;
        m_vertical = m_inputManager.m_vertical;
        m_jump = m_inputManager.m_jump;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(m_horizontal) > 0 || Mathf.Abs(m_vertical) > 0 )
        {
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
            m_horizontal, 
            0,
            m_vertical
        );

        Vector3 m_direction = Vector3.RotateTowards(
            transform.forward, 
            m_targetDirection, 
            Time.deltaTime * m_turnSpeed,
            0.0f
        );
        
        transform.rotation = Quaternion.LookRotation(m_direction);

        if (m_jump)
        {
            Debug.Log("space");
            Jump();
        }
    }


    public void Jump()
    {
        m_rb.AddForce(transform.up * m_jumpSpeed, ForceMode.Impulse);
    }

}
