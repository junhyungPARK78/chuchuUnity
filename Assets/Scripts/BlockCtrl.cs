using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCtrl : MonoBehaviour
{
    public GameObject brickParticle;

    // 공과 블럭이 충돌할 때
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (brickParticle != null)
        {
            // 이펙트를 발생시킨다
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            
            // GameManager의 DestroyBrick 함수 실행
            GameManager.Instance.DestroyBrick();
            
            // block Game Object 제거
            Destroy(gameObject);
        }
    }
}
