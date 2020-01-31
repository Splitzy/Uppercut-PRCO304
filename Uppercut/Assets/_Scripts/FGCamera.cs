using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FGCamera : MonoBehaviour
{
    public Transform[] targets;

    public Vector3 offset;

    public float smoothTime = 0.5f;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimit = 50f;

    private Vector3 vel;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (targets.Length == 0)
        {
            return;
        }

        Move();
        Zoom();

    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPos = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref vel, smoothTime);
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimit);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    Bounds GetEncapsulatingBounds(Bounds b, Transform[] t)
    {
        for (int i = 0; i < t.Length; i++)
        {
            b.Encapsulate(t[i].position);
        }

        return b;
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        GetEncapsulatingBounds(bounds, targets);

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Length == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        GetEncapsulatingBounds(bounds, targets);

        return bounds.center;
    }
}
