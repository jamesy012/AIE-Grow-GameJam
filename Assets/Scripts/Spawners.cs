﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Spawners : MonoBehaviour {

    /// <summary>
    /// dds
    /// </summary>
    [Tooltip("Width between this point and where it's spawning stuff")]
    public float m_Width = 5.0f;

    public List<GameObject> m_SpawnList = new List<GameObject>();

    private GameObject m_SpawnedObject = null;

    // Use this for initialization
    void Start() {

        if(m_SpawnList.Count == 0) {
            return;
        }

        int randomObjectIndex = Random.Range(0, m_SpawnList.Count);

        m_SpawnedObject = Instantiate(m_SpawnList[randomObjectIndex]);


        Vector3 pos = transform.position;
        float offset = m_Width * 2;
        offset = Random.Range(0, offset);
        offset -= m_Width;

        print(offset);

        pos.x += offset;


        Transform sOTransform = m_SpawnedObject.transform;

        sOTransform.parent = transform;
        sOTransform.position = pos;

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

    void OnBecameInvisible() {
        if (m_SpawnedObject != null) {
            Destroy(m_SpawnedObject);
        }
        Destroy(gameObject);
    }

}
