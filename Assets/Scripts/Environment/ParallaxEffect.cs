using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    Material mat;
    float distance;

    public float speed = 0f;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void FixedUpdate()
    {

        distance += Time.deltaTime * speed;
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
