using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_TEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string text = "";

        for (int i = 0; i < 100; ++i)
        {
            // UnityEngine.Random.Range(0, 10);
            // 0 ~ 9 정수
            int result = Random.Range(-10, 11);
            text += $"Random {i + 1}회 : {result * 0.1}\n";
        }
        
        Debug.Log(text);
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
