using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    public float BallInitialVelocity; // 볼의 가속 속도
    private Vector2 ballVector;
    private float timer;
    private int waitTime;
    
    // 리지드 바디
    private Rigidbody2D ballRigidBody = null;

    // 볼 플레이 선택 여부
    private bool isBallInPlay = false;

    void Start()
    {
        ballVector = new Vector2(1f, 2f).normalized;

        timer = 0.0f;
        waitTime = 5;
    }

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
            ballRigidBody.velocity = ballDirection * BallInitialVelocity;
        }

        if (other.tag == "DeadZone")
        {
            // ball 반사
            ballVector = ballRigidBody.GetVector(gameObject.transform.position);
            ballVector.y *= -1f;
            BallVelocityPlus(-2.0f);
            ballRigidBody.velocity = ballVector.normalized * BallInitialVelocity;

            // debug 정보 모음
            Debug.Log (@$"
            ====== Ball과 DeadZone 관련 Log 시작 ======
            ・DeadZone에 접촉했습니다.
            ・ball의 반사 vector : {ballVector}
            ====== Log 종료 ======");
            
            // ball speed LOG
            Debug.Log ($"BallInitialVelocity : {BallInitialVelocity}");

            GameManager.Instance.LoseLife();
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
        // ball speed 시간으로 증가
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            BallVelocityPlus(0.3f);
            Debug.Log ($"BallInitialVelocity : {BallInitialVelocity}");
            
            timer = 0.0f;
        }
        
        TouchInfo touchInfo = AppUtil.GetTouch();

        // 마우스 왼쪽 키를 누르면 볼에 가속도를 준다
        if (touchInfo == TouchInfo.Ended)
        {
            BallInitialVelocity = 4.0f;
            
            Vector2 parentPos = gameObject.transform.parent.transform.position;
            Debug.Log ($"parentPos : {parentPos}");

            transform.parent = null;
            isBallInPlay = true;
            ballRigidBody.isKinematic = false;
            
            ballRigidBody.velocity = ballVector * BallInitialVelocity;
        }        
    }

    void BallVelocityPlus(float speed)
    {
        BallInitialVelocity += speed;
        BallInitialVelocity = Mathf.Clamp(BallInitialVelocity, 4f, 8f); // ball 최저, 최고 속도
    }
}
