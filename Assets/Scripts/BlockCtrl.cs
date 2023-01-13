using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCtrl : MonoBehaviour
{
    public GameObject brickParticle;

    // 공과 블럭이 충돌할 때
    private void OnCollisionEnter2D(Collision2D other)
    {
        // 블럭에 접촉한 공의 정보 가져오기
        Rigidbody2D ballRigidBody = other.collider.gameObject.GetComponent<Rigidbody2D>();

        if (brickParticle != null)
        {
            Vector2 blockPos = gameObject.transform.position;
            
            Debug.Log ("Break Block");
            Debug.Log ($"ballRigidBody Block Vector = {ballRigidBody.GetVector(blockPos)}");
            // 이펙트를 발생시킨다
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            
            GameManager.Instance.DestroyBrick();
            Destroy(gameObject);
        }
    }
}
