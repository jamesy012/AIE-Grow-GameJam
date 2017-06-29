using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IReset : MonoBehaviour {

    private Vector3 m_StartPos;

    void Awake() {
        m_StartPos = transform.position;
    }

    virtual public void reset() {
        transform.position = m_StartPos;
    }

}
