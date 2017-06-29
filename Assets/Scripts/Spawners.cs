using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Spawners : MonoBehaviour
{

    /// <summary>
    /// dds
    /// </summary>
    [Tooltip("Width between this point and where it's spawning stuff")]
    public float m_Width = 5.0f;

    public List<GameObject> m_SpawnList = new List<GameObject>();
    public float m_spawnInterval = 1.5f;
    public float m_spawnRateIncrease = 0.05f;

    private GameObject m_SpawnedObject = null;
    float m_timer = 0.0f;

    public float m_spawnSpeedIncreaseInterval = 2.0f;
    float m_spawnSpeedIncreaseTimer = 0.0f;

    private float m_origSpawnInterval = 1.5f;
  
    // Use this for initialization
    void Start()
    {
        m_origSpawnInterval = m_spawnInterval;

        if (m_SpawnList.Count == 0)
        {
            return;
        }



    }

    void SpawnObject()
    {
        int randomObjectIndex = Random.Range(0, m_SpawnList.Count);

        m_SpawnedObject = Instantiate(m_SpawnList[randomObjectIndex]);


        Vector3 pos = transform.position;
        float offset = m_Width * 2;
        offset = Random.Range(0, offset);
        offset -= m_Width;

        //print(offset);

        pos.x += offset;


        Transform sOTransform = m_SpawnedObject.transform;

        //sOTransform.parent = transform;
        sOTransform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {

        m_timer += Time.deltaTime * SpeedScale.m_SpeedScale;
        m_spawnSpeedIncreaseTimer += Time.deltaTime * SpeedScale.m_SpeedScale;

        if (m_timer >= m_spawnInterval)
        {
            SpawnObject();
            m_timer = 0.0f;

        }

        if(m_spawnSpeedIncreaseTimer >= m_spawnSpeedIncreaseInterval)
        {
            if (m_spawnInterval > 0.3f)
            {
                m_spawnInterval -= m_spawnRateIncrease;
            }
            m_spawnSpeedIncreaseTimer = 0.0f;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 offset = (transform.rotation * new Vector3(m_Width, 0));
        const float width = 0.5f;

        Gizmos.DrawSphere(transform.position + offset, width);
        Gizmos.DrawSphere(transform.position - offset, width);
    }

    public void Reset()
    {
        m_timer = 0.0f;
        m_spawnSpeedIncreaseTimer = 0.0f;
        m_spawnInterval = m_origSpawnInterval;
    }

}
