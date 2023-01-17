using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    // 볼의 가속 속도
    public float BallInitialVelocity = 300f;
    private Vector2 startVector = new Vector2(1f, 1f);
    
    // 리지드 바디
    private Rigidbody2D ballRigidBody = null;

    // 볼 플레이 선택 여부
    private bool isBallInPlay = false;

    private void Awake()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            // debug 정보 모음
            Debug.Log (@$"
            ====== Ball과 Paddle 관련 Log 시작 ======
            ・Paddle에 접촉했습니다.
            ・paddle Position.x : {other.transform.position.x}
            ・Ball Position.x : {gameObject.transform.position.x}
            ・ball Position on Paddle.x : {(gameObject.transform.position.x) - (other.transform.position.x)}
            ・ballRigidBody Vector = {ballRigidBody.GetVector(gameObject.transform.position)}
            ====== Log 종료 ======");

            // 공 반사시키기
            Vector2 inDirection = ballRigidBody.velocity; // 입사 벡터 (속도)
            Vector2 inNormal = transform.up; // 노말 벡터
            Vector2 result = Vector2.Reflect(inDirection, inNormal);

            ballRigidBody.velocity = result;
        }

        if (other.tag == "DeadZone")
        {
            // debug 정보 모음
            Debug.Log (@$"
            ====== Ball과 DeadZone 관련 Log 시작 ======
            ・DeadZone에 접촉했습니다.
            ====== Log 종료 ======");

            // 공 제거하기
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            // debug 정보 모음
            Debug.Log (@$"
            ====== Ball과 Block 관련 Log 시작 ======
            ・Break Block
            ・ballRigidBody Block Vector = {ballRigidBody.GetVector(other.transform.position)}
            ====== Log 종료 ======");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 왼쪽 키를 누르면 볼에 가속도를 준다
        if (Input.GetButtonDown("Fire1") && !isBallInPlay)
        {
            Vector2 parentPos = gameObject.transform.parent.transform.position;
            Debug.Log ($"parentPos : {parentPos}");

            transform.parent = null;
            isBallInPlay = true;
            ballRigidBody.isKinematic = false;
            ballRigidBody.AddForce(startVector * BallInitialVelocity);

            // Debug.Log ($"ballRigidBody Start Vector = {ballRigidBody.GetVector(parentPos)}");
        }
        
    }
}
