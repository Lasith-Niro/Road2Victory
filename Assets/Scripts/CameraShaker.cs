using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public float power = 0.7f;      // effect of the shake
    public float duration = 1.0f;   // how long the animation
    public Transform camera;
    public float slowdownAmount = 1.0f; //how quickly shake calm down
    public bool shouldShake = false;

    private Vector3 startPosition;
    private float initialDuration;

    // Start is called before the first frame update
    void Start()
    {
        //camera = Camera.main.transform;
        startPosition = camera.transform.localPosition;
        initialDuration = duration;
    }

    public void Shake()
    {
        shouldShake = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            if (duration > 0)
            {
                camera.transform.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowdownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                camera.localPosition = startPosition;
            }
        }
    }
}
