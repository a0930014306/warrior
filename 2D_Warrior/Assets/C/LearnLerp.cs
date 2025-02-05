﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    public float a = 0;
    public float b = 100;

    public Vector2 v2A = new Vector2(0,0);
    public Vector2 v2B = new Vector2(100,100);

    private void Start()
    {
        //差值結果 = 數學.差值( a , b ,百分比);
        float result = Mathf.Lerp(0, 50, 0.55f);
        print("差值結果:" + result);

    }

    private void Update()
    {
        a = Mathf.Lerp(a, b, 0.5f);

        v2A = Vector2.Lerp(v2A, v2B, 0.2f);
    }
}
