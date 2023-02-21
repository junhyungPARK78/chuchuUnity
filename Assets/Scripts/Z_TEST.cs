using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_TEST : MonoBehaviour
{
    // private List<int> nums = new List<int>();
    // private int sampleNum = 90;
    private Vector3 ballReflectVector;
    
    // 두 vector의 각도 구하기 START
    public float testAngle;
    private Vector2 vector1;
    private Vector2 vector2;
    private Vector2 vector3;
    // 두 vector의 각도 구하기 END

    void Start()
    {
        // 두 vector의 각도 구하기 START
        testAngle = 0.0f;
        vector1 = Vector2.right;
        vector2 = new Vector2(-1, 1);
        int testCount = 100000;

        // System.Diagnostics.Stopwatch watch1 = new System.Diagnostics.Stopwatch();
        // watch1.Start();
        // watch1.Stop();
        // Debug.Log($"Vector2.SignedAngle : {watch1.ElapsedMilliseconds} ms");


        System.Diagnostics.Stopwatch watch1 = new System.Diagnostics.Stopwatch();
        watch1.Start();
        for (int i = 0; i < testCount; ++i)
        {
            testAngle = Vector2.SignedAngle(vector1, vector2) + i;            
        }
        watch1.Stop();
        Debug.Log($"Vector2.SignedAngle : {watch1.ElapsedMilliseconds} ms");

        System.Diagnostics.Stopwatch watch2 = new System.Diagnostics.Stopwatch();
        watch2.Start();
        for (int i = 0; i < testCount; ++i)
        {
            testAngle = Mathf.Atan2(vector2.y, vector2.x) * Mathf.Rad2Deg + i;
        }
        watch2.Stop();
        Debug.Log($"Mathf.Atan2 : {watch2.ElapsedMilliseconds} ms");


        
        

        // testAngle = Vector2.SignedAngle(vector1, vector2);
        // testAngle = Mathf.Atan2(vector2.y, vector2.x) * Mathf.Rad2Deg;
        // Debug.Log($"testAngle : {testAngle}");
        // 두 vector의 각도 구하기 END





        // for (int i = sampleNum * -1; i <= sampleNum; i++)
        // {
        //     nums.Add(i);
        // }        

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
        // 두 vector의 각도 구하기 START
        vector2 = Quaternion.AngleAxis(testAngle, Vector3.forward) * vector1;
        vector3 = Quaternion.AngleAxis(testAngle * -1f, Vector3.forward) * vector1;
        Debug.DrawLine(Vector2.zero, vector1 * 10, Color.red);
        Debug.DrawLine(Vector2.zero, vector2 * 10, Color.green);
        Debug.DrawLine(Vector2.zero, vector3 * 10, Color.blue);
        // 두 vector의 각도 구하기 END
        
        // Debug.DrawLine(Vector2.zero, Vector2.right * 10, Color.red);
        // // Debug.DrawLine(Vector2.zero, ballReflectVector * 10, Color.blue);

        // foreach (int numX in nums)
        // {
        //     // foreach (int numY in nums)
        //     // {
        //     //     Debug.DrawLine(Vector2.zero, new Vector2(numX, numY), Color.red);
        //     //     Debug.DrawLine(Vector2.zero, new Vector2(numX, numY).normalized, Color.green);
        //     // }
        //     ballReflectVector = Quaternion.AngleAxis(numX + 90, Vector3.forward) * Vector2.right;
        //     Debug.DrawLine(Vector2.zero, ballReflectVector, Color.green);
        // }

        

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