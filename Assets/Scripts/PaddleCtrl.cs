using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCtrl : MonoBehaviour
{
    private Vector2 playerPos = new Vector2(0f, -4f); // Paddle의 초기 위치

    private Rigidbody2D ballRigidBody = null; // 공의 리지드 바디
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log ("Touch Paddle");
        Debug.Log ($"paddle Position.x : {playerPos.x}");
        Debug.Log ($"ball Position on Paddle.x : {(other.transform.position.x) - (playerPos.x)}");
        ballRigidBody = other.GetComponent<Rigidbody2D>();
        Debug.Log ($"ballRigidBody Vector = {ballRigidBody.GetVector(playerPos)}");
        // Debug.Log ($"ballRigidBody Vector = {ballRigidBody.GetVector(other.position)}");

        Vector2 inDirection = ballRigidBody.velocity; // 입사 벡터 (속도)
        Vector2 inNormal = transform.up; // 노말 벡터
        Vector2 result = Vector2.Reflect(inDirection, inNormal);

        ballRigidBody.velocity = result;
    }

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
