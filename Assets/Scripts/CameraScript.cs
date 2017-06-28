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

    [Header("Side move varaibles")]
    [Range(0.0f, 0.5f)]
    public float m_VerticalRatio = 0.25f;
    [Range(0.0f, 0.5f)]
    public float m_HorizontalRatio = 0.25f;

    public Vector2 m_CameraMoveSpeed = Vector2.one * 0.05f;

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
                sideMove();
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

    private void sideMove() {
        Vector3 pos = transform.position;
        Vector2 playerScreenPos = Camera.main.WorldToScreenPoint(m_PlayerTransform.position);

        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenSizeRatio = new Vector2();
        playerScreenPos -= screenSize / 2;

        screenSizeRatio.x = screenSize.x * m_HorizontalRatio;
        screenSizeRatio.y = screenSize.y * m_VerticalRatio;

        

        if (screenSizeRatio.x < playerScreenPos.x) {
            float moveRatio = calcRatioFromSideOfScreen(screenSize.x, playerScreenPos.x,true);
            pos.x += m_CameraMoveSpeed.x * moveRatio;
        }
        if (-screenSizeRatio.x > playerScreenPos.x) {
            float moveRatio = calcRatioFromSideOfScreen(screenSize.x, -playerScreenPos.x,true);
            pos.x -= m_CameraMoveSpeed.x * moveRatio;
        }
        if (screenSizeRatio.y < playerScreenPos.y) {
            float moveRatio = calcRatioFromSideOfScreen(screenSize.y, playerScreenPos.y,false);
            pos.y += m_CameraMoveSpeed.y * moveRatio;
        }
        if (-screenSizeRatio.y > playerScreenPos.y) {
            float moveRatio = calcRatioFromSideOfScreen(screenSize.y, -playerScreenPos.y,false);
            pos.y -= m_CameraMoveSpeed.y * moveRatio;
        }

        //print(screenSize.x + " - " + playerScreenPos.x);

        transform.position = pos;
    }

    private float calcRatioFromSideOfScreen(float a_ScreenSize, float a_PlayerPos,bool a_Horizontal) {
        float ratio = a_Horizontal ? m_HorizontalRatio : m_VerticalRatio;
        return (a_PlayerPos / (a_ScreenSize / 2) - (ratio * 2.0f)) * 2;
    }
}
