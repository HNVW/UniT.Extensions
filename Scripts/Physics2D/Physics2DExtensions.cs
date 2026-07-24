#nullable enable
namespace UniT.Extensions
{
    using System.Diagnostics.Contracts;
    using UnityEngine;

    public static class Physics2DExtensions
    {
        [Pure]
        public static T? Overlap2D<T>(this Camera camera, Vector3 screenPosition, LayerMask? layerMask = null) where T : notnull
        {
            var collider = Physics2D.OverlapPoint(camera.ScreenToWorldPoint(screenPosition.WithZ(Mathf.Abs(camera.transform.position.z))), layerMask ?? Physics2D.DefaultRaycastLayers);
            if (!collider) return default;
            if (collider.attachedRigidbody) return collider.attachedRigidbody.GetComponentOrDefault<T>();
            return collider.GetComponentInParentOrDefault<T>();
        }
    }
}