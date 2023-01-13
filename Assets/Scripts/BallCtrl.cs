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
