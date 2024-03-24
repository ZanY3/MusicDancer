using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDancer : MonoBehaviour
{
    public int count = 1;
    public float radius = 5;
    public float rotateSpeed = 100;
    public float minScale;
    public float boost;
    public GameObject prefab;

    private void Start()
    {
        for (float i = 0; i < 10; i++)
        {
            var angle = i/count * Mathf.PI * 2;
            var pos = new Vector3();
            pos.x = Mathf.Cos(angle);
            pos.y = Mathf.Sin(angle);
            pos.y += 0.3f;
            pos *= radius;
            var obj = Instantiate(prefab, pos, Quaternion.identity, transform); //transform - to parent to this
            obj.transform.LookAt(transform);
        }
        Analyzer.onVolumeChanged.AddListener(Dance);
    }
    public void Dance(float volume)
    {
        volume *= boost;
        transform.Rotate(0,0,volume * rotateSpeed * Time.deltaTime);
        transform.localScale = Vector3.one * (minScale + volume);
    }
}
