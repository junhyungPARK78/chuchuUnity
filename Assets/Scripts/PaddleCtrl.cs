using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCtrl : MonoBehaviour
{
    private Vector2 playerPos = new Vector2(0f, -3.94f); // Paddle의 초기 위치
    private Vector2 cursorParticlePos = new Vector2(0f, -5.27f); // cursorParticle의 초기 위치
    private Vector3 mousePosition = new Vector2(0f, 0f); // 마우스 위치 초기화

    public GameObject cursorParticlePrefab = null;
    private GameObject cursorParticle;

    void Start()
    {
        cursorParticle = Instantiate(cursorParticlePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 위치 받아오기
        mousePosition = Input.mousePosition;

        // Paddle x 값 받아오기
        float xPosPaddle = Camera.main.ScreenToWorldPoint(mousePosition).x;

        float yMousePosition = Camera.main.ScreenToWorldPoint(mousePosition).y;

        // 이동 제한
        // Paddle
        playerPos = new Vector2(Mathf.Clamp(xPosPaddle, -3.52f, 3.52f), -3.94f);
        // cursorParticle
        // cursorParticlePos = new Vector2(playerPos.x, -5.27f);
        cursorParticlePos = new Vector2(playerPos.x, Mathf.Clamp(yMousePosition, -5.9f, -4.64f));

        transform.position = playerPos;
        cursorParticle.transform.position = cursorParticlePos;
    }
}
