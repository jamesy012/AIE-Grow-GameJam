using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    public float m_lifeTime = 10.0f;
    public float m_startScale = 0.1f;
    public float m_endScale = 5.0f;
    public Vector3 m_scaleVector = Vector3.one;
    public AnimationCurve m_curve;

    private float m_timer = 0.0f;
    private float m_scaleDiff = 0.0f;
    private float m_scaleInterval = 0.0f;
    private float m_currScale = 0.0f;
    private float m_ratio = 0.0f;

    // Use this for initialization
    void Start()
    {
        m_ratio = 0.0f;
        m_scaleDiff = m_endScale - m_startScale;
        m_scaleInterval = m_scaleDiff / m_lifeTime;

        this.transform.localScale = m_scaleVector * m_startScale;
        m_currScale = m_startScale;
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        m_ratio = m_timer / m_lifeTime;
        m_currScale = m_curve.Evaluate(m_ratio) * m_endScale;

        this.transform.localScale = m_scaleVector * m_currScale;


        if(m_timer >= m_lifeTime)
        {

            m_timer = 0.0f;
            m_currScale = m_startScale;
            this.transform.localScale = m_scaleVector * m_startScale;
            this.gameObject.SetActive(false);
        }
    }

    //void OnBecameInvisible()
    //{
    //    m_timer = 0.0f;
    //    this.gameObject.SetActive(false);
    //}

}
