using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCtrl_mouse : MonoBehaviour
{
    private Vector2 playerPos = new Vector2(0f, -4f); // Paddle의 초기 위치
    
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        // 마우스 위치 받아오기
        Vector3 cameraPosition = Input.mousePosition;

        // Paddle x 값 받아오기
        float xPos = Camera.main.ScreenToWorldPoint(cameraPosition).x;

        // Paddle 이동 제한
        playerPos = new Vector2(Mathf.Clamp(xPos, -2f, 2f), -4f);
        transform.position = playerPos;
    }
}
