using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_TEST : MonoBehaviour
{
    void Start()
    {
        // draw a 5-unit white line from the origin for 2.5 seconds
        // Debug.DrawLine(Vector3.zero, new Vector3(5, 0, 0), Color.white, 2.5f);
        Debug.DrawLine(Vector3.zero, new Vector3(-5, -3, 0), Color.red);
    }

    private float q = 0.0f;

    void FixedUpdate()
    {
        // always draw a 5-unit colored line from the origin
        Color color = new Color(q, q, 1.0f);
        Debug.DrawLine(Vector3.zero, new Vector3(5, 5, 0), color);
        q = q + 0.01f;

        if (q > 1.0f)
        {
            q = 0.0f;
        }
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