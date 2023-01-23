using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCtrl : MonoBehaviour
{
    private Vector2 playerPos = new Vector2(0f, -4.16f); // Paddle의 초기 위치

    // Update is called once per frame
    void Update()
    {
        // 마우스 위치 받아오기
        Vector3 cameraPosition = Input.mousePosition;

        // Paddle x 값 받아오기
        float xPos = Camera.main.ScreenToWorldPoint(cameraPosition).x;

        // Paddle 이동 제한
        playerPos = new Vector2(Mathf.Clamp(xPos, -3.66f, 3.66f), -4.16f);
        transform.position = playerPos;
    }
}
