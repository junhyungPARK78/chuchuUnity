using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        Debug.Log ("Death Zone");
        GameManager.Instance.LoseLife();
    }
}
