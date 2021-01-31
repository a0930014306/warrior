
using UnityEngine;
using System.Collections;

public class CameraControl2D : MonoBehaviour
{
    [Header("目標物件")]
    public Transform target;
    [Header("追蹤速度"),Range(0,100)]
    public float speed = 20;
    [Header("晃動間隔"), Range(0, 1)]
    public float shake = 0.05f;
    [Header("晃動值"), Range(0, 5)]
    public float shakevalue = 0.5f;
    [Header("晃動次數"), Range(0, 10)]
    public int shakecount = 3;

    /// <summary>
    /// 追蹤目標物件
    /// </summary>
    public void Track()
    {
        //取得玩家座標
        Vector3 posA = target.position;
        //取得攝影機座標
        Vector3 posB = transform.position;
        //Z軸 = -10
        posA.z = -10;

        //差值
        posB = Vector3.Lerp(posB, posA ,speed * Time.deltaTime);
        //更新攝影機座標
        transform.position = posB;


    }

    //延遲更新 : 在Update執行之後才執行, 追蹤
    private void LateUpdate()
    {
        Track();
    }

    /// <summary>
    /// 晃動效果
    /// </summary>
    /// <returns></returns>
    public IEnumerator Shake()
    {
        

        for (int i = 0; i < shakecount; i++)
        {

            
            transform.position += Vector3.up * shakevalue;
            yield return new WaitForSeconds(shake);
            transform.position -= Vector3.up * shakevalue;
            yield return new WaitForSeconds(shake);

        }
        
    }

}
