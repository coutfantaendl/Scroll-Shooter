using UnityEngine;

public class PhysicsRay
{
    private readonly float _rayDistance;
    private readonly LayerMask _hitLayer;

    public PhysicsRay(float rayDistance, LayerMask hitLayer)
    {
        _rayDistance = rayDistance;
        _hitLayer = hitLayer;
    }

    public RaycastHit2D CastRay(Vector2 origin, Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, _rayDistance, _hitLayer);
        return hit;
    }
}
