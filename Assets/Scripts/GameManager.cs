using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        // // 게임 표시 방향 조정
        // // Screen.orientation = ScreenOrientation.Portrait;
        // Screen.autorotateToPortrait = true;
        // Screen.autorotateToPortraitUpsideDown = true;
        // Screen.autorotateToLandscapeLeft = false;
        // Screen.autorotateToLandscapeRight = false;
        // Screen.orientation = ScreenOrientation.AutoRotation;
        
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
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
        // 벽돌을 다 깼을 때
        if (bricks < 1)
        {
            if (success != null)
            {
                success.SetActive(true);
                // 시간을 2.5배로
                Time.timeScale = 2.5f;
                Invoke("Reset", resetDelay);
            }
        }

        // 생명력을 소진했을 때
        if (lives < 1)
        {
            if (gameOver != null)
            {
                gameOver.SetActive(true);
                // 시간을 0.25배로
                Time.timeScale = 0.25f;
                Invoke("Reset", resetDelay);
            }
        }
    }

    private void Reset()
    {
        // 평균 타임을 설정
        Time.timeScale = 1f;

        // 현재 열려있는 scene을 다시 연다
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 생명력을 잃게 되면 발생
    public void LoseLife()
    {
        lives--;

        if (txtLives != null)
        {
            txtLives.text = "LIFE : " + lives;
        }

        // 파티클 발생
        if (DeathParticles != null)
        {
            Instantiate(DeathParticles, clonePaddle.transform.position, Quaternion.identity);
        }

        // 패들 없애기
        Destroy(clonePaddle.gameObject);

        // 딜레이 시간만큼 지나면 패들 생산
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    // 패들 생산
    private void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }
}
