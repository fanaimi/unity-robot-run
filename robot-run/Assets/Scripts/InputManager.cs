using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public float m_vertical;
    [HideInInspector] public float m_horizontal;
    [HideInInspector] public bool m_jump;
    [HideInInspector] public bool m_fire;



    private void Start() {
        
    }

    private void FixedUpdate () {
        ListenToKeyboard ();
    }

    private void ListenToKeyboard () {
        m_vertical = Input.GetAxisRaw ("Vertical");
        m_horizontal = Input.GetAxisRaw ("Horizontal");
        m_jump = (Input.GetAxis ("Jump") != 0) ? true : false;
        
        // if(Input.GetKeyUp(KeyCode.Space) ) m_jump = false;
        // if(Input.GetKeyDown(KeyCode.Space) ) m_jump = true;
        
        /*if (Input.GetKey (KeyCode.LeftShift)) boosting = true;
        else boosting = false;*/

    } // ListenToKeyboard

}
