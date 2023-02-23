using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    public float BallInitialVelocity; // 볼의 가속 속도
    public float reflectAngleRangeOnPaddle; // paddle에서 볼이 반사되는 허용 각도
    public float reflectLimitAngle; // 이 각도 이하 벡터일 경우 무조건 이 각도로 튕기게 하기 위한 변수
    private Vector2 startVector;
    private Vector2 ballVector;
    private float ballVectorAngle;
    private float timer;
    private int waitTime;
    private Vector2 hitPos;
    private float ballReflectQuaternion;
    private Vector3 ballReflectVector;
    
    // 리지드 바디
    private Rigidbody2D ballRigidBody = null;

    // 볼 플레이 선택 여부
    private bool isBallInPlay = false;

    private void Awake()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        reflectAngleRangeOnPaddle = 160f;
        startVector = new Vector2(1f, 2f).normalized;

        reflectLimitAngle = 5f;

        timer = 0.0f;
        waitTime = 5;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        hitPos = gameObject.transform.position;
        ballVector = ballRigidBody.velocity;
        
        Debug.DrawLine(hitPos, hitPos + ballVector, Color.yellow, 1.5f, false);
        
        if (other.tag == "Paddle")
        {
            float ballPositionOnPaddle = ((gameObject.transform.position.x) - (other.transform.position.x)) * 2f;
            ballPositionOnPaddle = Mathf.Clamp(ballPositionOnPaddle, -1f, 1f);

            // ballPositionOnPaddle에 의한 반사각 계산
            ballReflectQuaternion = (ballPositionOnPaddle * -1) * (reflectAngleRangeOnPaddle * 0.25f) +90;
            ballReflectVector = Quaternion.AngleAxis(ballReflectQuaternion, Vector3.forward) * Vector2.right;

            // debug 정보 모음
            Debug.Log (@$"
            ====== Ball과 Paddle 관련 Log 시작 ======
            ・Paddle에 접촉했습니다.
            ・paddle Position.x : {other.transform.position.x}
            ・Ball Position.x : {gameObject.transform.position.x}
            ・ball Position on Paddle.x : {ballPositionOnPaddle}
            ・ball 반사 Vector = {ballReflectVector}
            ====== Log 종료 ======");

            // 공 반사시키기
            ballRigidBody.velocity = ballReflectVector * BallInitialVelocity;
        }

        if (other.tag == "Roof")
        {
            // 천장 반사
            ballVector = Vector2.Reflect(ballVector, Vector2.down);
            ballRigidBody.velocity = ballVector.normalized * BallInitialVelocity;
        }

        if (other.tag == "WallLeft")
        {
            // 왼쪽 벽 반사
            ballVector = Vector2.Reflect(ballVector, Vector2.right);
            ballRigidBody.velocity = ballVector.normalized * BallInitialVelocity;
        }

        if (other.tag == "WallRight")
        {
            // 규정 반사 각도 이하인지 체크해서 규정 반사 각도로 조정하기
            ballVectorAngle = Mathf.Atan2(ballVector.y, ballVector.x) * Mathf.Rad2Deg;
            if (0f <= ballVectorAngle && ballVectorAngle < reflectLimitAngle)
            {
                ballVector = Quaternion.AngleAxis(reflectLimitAngle, Vector3.forward) * Vector2.right;
            }
            else if (reflectLimitAngle * -1 < ballVectorAngle && ballVectorAngle <= 0f)
            {
                ballVector = Quaternion.AngleAxis(reflectLimitAngle * -1, Vector3.forward) * Vector2.right;
            }

            // 오른쪽 벽 반사
            ballVector = Vector2.Reflect(ballVector, Vector2.left);
            ballRigidBody.velocity = ballVector.normalized * BallInitialVelocity;
        }

        if (other.tag == "DeadZone")
        {
            // ball 반사
            // ballVector = new Vector2(Random.Range(-1.5f, 1.5f), 1f);
            ballVector.y *= -1;
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
        // foreach (ContactPoint2D contact in other.contacts)
        // {
        //     Debug.DrawLine(contact.point, contact.point + contact.normal, Color.yellow, 2, false);
        // }

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
        if (touchInfo == TouchInfo.Ended && isBallInPlay == false)
        {
            BallInitialVelocity = 4.0f;
            
            Vector2 parentPos = gameObject.transform.parent.transform.position;
            Debug.Log ($"parentPos : {parentPos}");

            transform.parent = null;
            isBallInPlay = true;
            ballRigidBody.isKinematic = false;
            
            ballRigidBody.velocity = startVector * BallInitialVelocity;
        }        
    }

    void BallVelocityPlus(float speed)
    {
        BallInitialVelocity += speed;
        BallInitialVelocity = Mathf.Clamp(BallInitialVelocity, 4f, 10f); // ball 최저, 최고 속도
    }
}
