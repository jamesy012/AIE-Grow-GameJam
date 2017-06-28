using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CameraModes {
    Debug,
    DontMove,
    SideMove
}

public class CameraScript : MonoBehaviour {

    public CameraModes m_CameraMode;

    private Transform m_PlayerTransform;

    [Header("a")]
    [Range(0.0f,1.0f)]
    public float m_VerticalRatio = 0.25f;

    // Use this for initialization
    void Start() {
        Player player = FindObjectOfType<Player>();

        if(player == null) {
            Debug.LogError(GetType().ToString() + ": " + transform.name + " cant find Player script");
            return;
        }

        m_PlayerTransform = player.transform;
    }

    // Update is called once per frame
    void LateUpdate() {
        moveCamera();
    }

    private void moveCamera() {
        switch (m_CameraMode) {
            case CameraModes.Debug:
                cameraDebug();
                break;
            case CameraModes.SideMove:
                cameraDebug();
                break;
            case CameraModes.DontMove:
            default:
                break;
        }
    }

    private void cameraDebug() {
        Vector3 pos = transform.position;
        pos.x = m_PlayerTransform.position.x;
        pos.y = m_PlayerTransform.position.y;

        transform.position = pos;
    }
}
