using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCtrl : MonoBehaviour
{
    public float PaddleSpeed = 1f; // Paddle의 이동 스피드
    private Vector3 playerPos = new Vector3(0f, -4f, 0f); // Paddle의 초기 위치
    
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        // Paddle 좌우 이동
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * PaddleSpeed);

        // Paddle 이동 제한
        playerPos = new Vector3(Mathf.Clamp(xPos, -2f, 2f), -4f, 0f);
        transform.position = playerPos;
    }
}
