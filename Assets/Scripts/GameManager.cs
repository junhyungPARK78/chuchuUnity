using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 남은 생명력
    public int lives = 3;

    // 벽돌 갯수
    public int bricks = 32;

    // 게임 재시작 시간
    public float resetDelay;

    public Text txtLives = null;
    public GameObject gameOver = null;
    public GameObject success = null;
    public GameObject bricksPrefab;
    public GameObject paddle = null;
    public GameObject DeathParticles = null;
    public static GameManager Instance = null;

    private GameObject clonePaddle = null;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(GameObject);
        }

        SetUp();
    }

    // 게임 시작 시 패들과 벽돌을 불러온다
    public void SetUp()
    {
        if (paddle != null)
        {
            clonePaddle = Instantiate(paddle, paddle.transform.position, Quaternion.identity) as GameObject;
        }

        if (bricksPrefab != null)
        {
            Instantiate(bricksPrefab, bricksPrefab.transform.position, Quaternion.identity);
        }
    }

    // 게임 재시작 설정
    void CheckGameOver()
    {
        // 작성중
    }
}
