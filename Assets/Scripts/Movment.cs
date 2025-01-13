using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    float rotationDelay = 0.07f;
    float rotationDuration = 1f;
    float angleRange = 45f;

    private void Start()
    {
        Transform parent = GameObject.Find("All Boxes")?.transform;

        if (parent == null || parent.childCount == 0)
        {
            Debug.LogError($"Parent object 'Boxes' not found or has no children.");
            return;
        }

        float delay = 0f;
        foreach (Transform child in parent)
        {
            StartCoroutine(RotateChild(child, delay));
            delay += rotationDelay;
        }
    }

    private IEnumerator RotateChild(Transform child, float delay)
    {
        float startTime = Time.time + delay;
        while (true)
        {
            float elapsedTime = Time.time - startTime;
            float step = Mathf.SmoothStep(0, 1, Mathf.PingPong(elapsedTime / rotationDuration, 1));
            float angleOffset = Mathf.Lerp(-angleRange, angleRange, step);
            child.localRotation = Quaternion.Euler(0, angleOffset, 0);
            yield return null;
        }
        
    }
}