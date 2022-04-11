using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTest : MonoBehaviour
{
    [SerializeField] float m_distance;
    [SerializeField] float m_speed;
    Vector3 m_startPos;

    // Start is called before the first frame update
    void Start()
    {
        m_startPos = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = m_startPos;

        pos.x = m_distance * Mathf.Sin(Time.time * m_speed);
        transform.position = pos;
    }
}
