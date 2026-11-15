using System;
using System.Collections;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject[] rotationObjects;
    private Vector3 startAngle;


    private void Start()
    {
        startAngle = transform.eulerAngles;
        for(int i = 0; i < rotationObjects.Length; i++){
            if (i == 1)
            {
                StartCoroutine(Rotate(rotationObjects[i], false, 1));
                break;
            }
            StartCoroutine(Rotate(rotationObjects[i], true, 1));
        }
        
    }

    private IEnumerator Rotate(GameObject obj, bool rotateRight, float rotateTime)
    {
        Vector3 currentAngle = obj.transform.eulerAngles;
        Vector3 targetAngle = startAngle;

        if (rotateRight)
        {
            targetAngle = new Vector3(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z + 30);
        }
        else
        {
            targetAngle = new Vector3(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z - 30);
        }
        
        float time = 0;

        while (time < rotateTime)
        {
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));

            obj.transform.eulerAngles = currentAngle;
            time += Time.deltaTime;
            yield return null;
        }

        

        StartCoroutine(Rotate(obj, !rotateRight, 1));
    }
}