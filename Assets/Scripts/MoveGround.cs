using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    private Vector3 pointB = Vector3.left;
    public Transform targetTransform;
    public float reverseSpeed = 3f;

    IEnumerator Start()
    {
        pointB = targetTransform.position;
        Vector3 pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform,pointA,pointB,reverseSpeed));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, reverseSpeed));
        }
    }

    IEnumerator MoveObject(Transform transform, Vector3 pointA, Vector3 pointB, float reverseSpeed)
    {
        float i = 0;
        float rate = 1.0f / reverseSpeed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(pointA,pointB, i);
            yield return null;
        }

    }
}
