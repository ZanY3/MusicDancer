using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    public float sensitivity;
    public float maxSize;
    public float volumeForBass;
    public GameObject bassParticle;
    public float rotationSpeed;
    public bool isRotating;

    private void Update()
    {
        if(isRotating) transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    public void Dance(float volume)
    {
        volume -= 0.05f;
        if (volume < 0) volume = 0f;
        if(volume > volumeForBass)
        {
            Instantiate(bassParticle, transform.position, Quaternion.identity);
        }
        transform.localScale = Vector3.one * (0.5f + Mathf.Pow(volume, sensitivity)) * maxSize;
    }
}