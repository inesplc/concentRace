using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public float Damping = 5.0f;
    public float Distance = 3.0f;
    public float Height = 3.0f;
    public float RotationDamping = 10.0f;
    public Transform Target;

    private void Update()
    {
        Vector3 wantedPosition = Target.TransformPoint(0, Height, -Distance);
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime*Damping);

        Quaternion wantedRotation = Quaternion.LookRotation(Target.position - transform.position, Target.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime*RotationDamping);
    }
}