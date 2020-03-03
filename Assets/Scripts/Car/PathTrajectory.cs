using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PathTrajectory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private MeshCollider _meshCollider;
    [SerializeField] private CarBacklight _carBacklight;

    public void Init(Car car, List<Vector3> trajectoryPositions)
    {
        SetTrajectory(trajectoryPositions);
        SetMesh();
        SetTransform(car);
    }

    private void SetTrajectory(List<Vector3> trajectoryPositions)
    {
        _lineRenderer.positionCount = trajectoryPositions.Count;
        _lineRenderer.SetPositions(trajectoryPositions.ToArray());
    }

    private void SetMesh()
    {
        Mesh trajectoryMesh = new Mesh();
        _lineRenderer.BakeMesh(trajectoryMesh);
        _meshCollider.sharedMesh = trajectoryMesh;
    }

    private void SetTransform(Car car)
    {
        transform.position = transform.TransformVector(transform.localPosition);
        transform.localRotation = Quaternion.Inverse(car.transform.rotation);
        transform.localScale = new Vector3(1 / car.transform.localScale.x, 1 / car.transform.localScale.y, 1 / car.transform.localScale.z);
    }

    public void OnPointerEnter(PointerEventData eventData) { }

    public void OnPointerExit(PointerEventData eventData) { }

    public void OnPointerDown(PointerEventData eventData)
    {
        _carBacklight.SetBacklightState(!_carBacklight.Backlight);
    }
}
