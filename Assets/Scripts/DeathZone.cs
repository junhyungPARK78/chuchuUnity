using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnCollisionEnter2D()
    {
        // debug 정보 모음
        Debug.Log (@$"
        ====== Ball과 DeadZone 관련 Log 시작 ======
        ・DeadZone에 접촉했습니다.
        ====== Log 종료 ======");

        GameManager.Instance.LoseLife();
    }
}
