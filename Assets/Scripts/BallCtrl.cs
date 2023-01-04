using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    // 볼의 가속 속도
    public float BallInitialVelocity = 300f;

    // 리지드 바디
    private Rigidbody2D ballRigidBody = null;

    // 볼 플레이 선택 여부
    private bool isBallInPlay = false;

    private void Awake()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 오른쪽 키를 누르면 볼에 가속도를 준다
        if (Input.GetButtonDown("Fire1") && !isBallInPlay)
        {
            transform.parent = null;
            isBallInPlay = true;
            ballRigidBody.isKinematic = false;
            ballRigidBody.AddForce(new Vector2(BallInitialVelocity, BallInitialVelocity));
        }
        
    }
}
