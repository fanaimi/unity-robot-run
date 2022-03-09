using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private InputManager m_inputManager;
    [SerializeField] private Transform target; 	// the transform to follow
    [SerializeField] Vector3 offset;		// x, y, z, offset, distance from target

    private void Start()
    {
        m_inputManager = FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        // transform.LookAt(target);
        // handling rotation
        Vector3 m_targetDirection = new Vector3(
            m_inputManager.m_horizontal, 
            0,
            m_inputManager.m_vertical
        );

        Vector3 m_direction = Vector3.RotateTowards(
            transform.forward, 
            m_targetDirection, 
            Time.deltaTime * 5,
            0.0f
        );
        
        transform.rotation = Quaternion.LookRotation(m_direction);
        
        transform.LookAt(target);
    }
    
}