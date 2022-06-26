using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct TargetingComponent
{
    public float aimMaxRange;
    public RectTransform aimRectTransform;
    public Image aimImage;
    public AimColorsSO aimColors;
    public Vector3 RaycastOffset;

    public RaycastHit HitInfo { get; set; }
    public IDamageable CurrentTarget { get; set; }
}