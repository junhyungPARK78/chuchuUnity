using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_TEST : MonoBehaviour
{
    private float q = 0.0f;
    private List<int> nums = new List<int>();
    private int sampleNum = 10;

    void Start()
    {
        for (int i = sampleNum * -1; i <= sampleNum; i++)
        {
            nums.Add(i);
        }
        // Debug.Log (nums[2]);
        
        // draw a 5-unit white line from the origin for 2.5 seconds
        // Debug.DrawLine(Vector3.zero, new Vector3(5, 0, 0), Color.white, 2.5f);
        // Debug.DrawLine(Vector3.zero, new Vector3(5, 3, 0), Color.red);

        // List<int> nums = new List<int>(new int[] {10, 0, -10});
        // foreach (int numX in nums)
        // {
        //     foreach (int numY in nums)
        //     {
        //         // Debug.DrawLine(Vector3.zero, new Vector3(numX, numY, 0), Color.red);
        //         Debug.Log ($"numX = {numX} / numY = {numY}");
        //     }
        // }
        
    }
    
    void FixedUpdate()
    {
        foreach (int numX in nums)
        {
            foreach (int numY in nums)
            {
                Debug.DrawLine(Vector2.zero, new Vector2(numX, numY), Color.red);
                Debug.DrawLine(Vector2.zero, new Vector2(numX, numY).normalized, Color.green);
            }
        }

        

        // // always draw a 5-unit colored line from the origin
        // Color color = new Color(q, q, 1.0f);
        // Debug.DrawLine(Vector3.zero, new Vector3(5, 5, 0), color);
        // q = q + 0.01f;

        // if (q > 1.0f)
        // {
        //     q = 0.0f;
        // }
    }

    // Event callback example: Debug-draw all contact points and normals for 2 seconds.
    // void OnTriggerEnter2D(Collision collision)
    // {
    //     foreach (ContactPoint contact in collision.contacts)
    //     {
    //         Debug.DrawLine(contact.point, contact.point + contact.normal, Color.green, 2, false);
    //     }
    // }
}

// public class Z_TEST : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
//         string text = "";

//         for (int i = 0; i < 100; ++i)
//         {
//             // UnityEngine.Random.Range(0, 10);
//             // 0 ~ 9 정수
//             int result = Random.Range(-10, 11);
//             text += $"Random {i + 1}회 : {result * 0.1}\n";
//         }
        
//         Debug.Log(text);
//     }

//     // // Update is called once per frame
//     // void Update()
//     // {
        
//     // }
// }