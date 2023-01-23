using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    // 볼의 가속 속도
    public float BallInitialVelocity = 300f;
    private Vector2 startVector = new Vector2(1f, 2f).normalized;
    
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
            float ballPositionOnPaddle = ((gameObject.transform.position.x) - (other.transform.position.x)) * 2f;
            ballPositionOnPaddle = Mathf.Clamp(ballPositionOnPaddle, -1f, 1f);

            // debug 정보 모음
            Debug.Log (@$"
            ====== Ball과 Paddle 관련 Log 시작 ======
            ・Paddle에 접촉했습니다.
            ・paddle Position.x : {other.transform.position.x}
            ・Ball Position.x : {gameObject.transform.position.x}
            ・ball Position on Paddle.x : {ballPositionOnPaddle}
            ・ballRigidBody Vector = {ballRigidBody.GetVector(gameObject.transform.position)}
            ====== Log 종료 ======");

            // 공 반사시키기
            // 공 튀기는 각도의 벡터는 y=1 기준으로 x를 -3.5 ~ 3.5 로 조절하면 될 듯하다.
            Vector2 ballDirection = new Vector2(ballPositionOnPaddle * 3.5f, 1f).normalized;
            ballRigidBody.velocity = ballDirection * BallInitialVelocity * 0.025f;
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
        if (Input.GetButtonUp("Fire1") && !isBallInPlay)
        {
            Vector2 parentPos = gameObject.transform.parent.transform.position;
            Debug.Log ($"parentPos : {parentPos}");

            transform.parent = null;
            isBallInPlay = true;
            ballRigidBody.isKinematic = false;
            // ballRigidBody.AddForce(startVector * BallInitialVelocity);
            ballRigidBody.velocity = startVector * BallInitialVelocity * 0.025f;

            // Debug.Log ($"ballRigidBody Start Vector = {ballRigidBody.GetVector(parentPos)}");
        }
        
    }
}
