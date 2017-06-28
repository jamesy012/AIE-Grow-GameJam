using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {

    /// <summary>
    /// dds
    /// </summary>
    [Tooltip("Width between this point and where it's spawning stuff")]
    public float m_Width = 5.0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;

        Vector3 offset = (transform.rotation * new Vector3(m_Width, 0));
        const float width = 0.5f;

        Gizmos.DrawSphere(transform.position + offset, width);
        Gizmos.DrawSphere(transform.position - offset, width);
    }

}
