using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppUtil
{
    private static Vector3 TouchPosition = Vector3.zero;

    /// <summary>
    /// タッチ情報を取得(エディタと実機を考慮)
    /// </summary>
    /// <returns>タッチ情報。タッチされていない場合は null</returns>
    public static TouchInfo GetTouch()
    {
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount > 0)
            {
                return (TouchInfo)((int)Input.GetTouch(0).phase);
            }            
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) { return TouchInfo.Began; }
            if (Input.GetMouseButton(0)) { return TouchInfo.Moved; }
            if (Input.GetMouseButtonUp(0)) { return TouchInfo.Ended; }
        }
        return TouchInfo.None;
    }

    /// <summary>
    /// タッチポジションを取得(エディタと実機を考慮)
    /// </summary>
    /// <returns>タッチポジション。タッチされていない場合は (0, 0, 0)</returns>
    public static Vector3 GetTouchPosition()
    {
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                TouchPosition.x = touch.position.x;
                TouchPosition.y = touch.position.y;
                return TouchPosition;
            }            
        }
        else
        {
            TouchInfo touch = AppUtil.GetTouch();
            if (touch != TouchInfo.None) { return Input.mousePosition; }
        }
        return Vector3.zero;
    }

    /// <summary>
    /// タッチワールドポジションを取得(エディタと実機を考慮)
    /// </summary>
    /// <param name='camera'>カメラ</param>
    /// <returns>タッチワールドポジション。タッチされていない場合は (0, 0, 0)</returns>
    public static Vector3 GetTouchWorldPosition(Camera camera)
    {
        return camera.ScreenToWorldPoint(GetTouchPosition());
    }

    //벡터를 각도로 변환
    public static double VectorToDegree(Vector2 vector)
    {
        float radian = Mathf.Atan2(vector.y, vector.x);
        return (radian*180.0/Mathf.PI);
    }

    //벡터를 라디안으로 변환
    public static double VectorToRadian(Vector2 vector)
    {
        return Mathf.Atan2(vector.y, vector.x);
    }

    //라디안을 각도로 변환
    public static double RadianToDegree(double radian)
    {
        return (radian * 180.0 / Mathf.PI);
    }

    //각도를 라디안으로 변환
    public static double DegreeToRadian(double degree)
    {
        return (Mathf.PI / 180.0) * degree;
    }

    
}

/// <summary>
/// タッチ情報。UnityEngine.TouchPhase に None の情報を追加拡張。
/// </summary>
public enum TouchInfo
{
    /// <summary>
    /// タッチなし
    /// </summary>
    None = 99,

    // 以下は UnityEngine.TouchPhase の値に対応
    /// <summary>
    /// タッチ開始
    /// </summary>
    Began = 0,
    /// <summary>
    /// タッチ移動
    /// </summary>
    Moved = 1,
    /// <summary>
    /// タッチ静止
    /// </summary>
    Stationary = 2,
    /// <summary>
    /// タッチ終了
    /// </summary>
    Ended = 3,
    /// <summary>
    /// タッチキャンセル
    /// </summary>
    Canceled = 4,
}