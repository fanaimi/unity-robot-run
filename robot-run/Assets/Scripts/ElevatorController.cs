using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    private float m_TimeFromStart = 0f;
    private float m_Interval = 3f;
    private float m_Speed = 5f;

    // Update is called once per frame
    void Update()
    {
        m_TimeFromStart += Time.deltaTime;

        if (m_TimeFromStart > m_Interval)
        {
            m_TimeFromStart = 0;
            m_Speed = -m_Speed;
        }
        else
        {
            transform.Translate(0, m_Speed* Time.deltaTime,0);
        }
    }
    // just a comment for testing
}
