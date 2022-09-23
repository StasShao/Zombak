using UnityEngine;
[CreateAssetMenu(menuName ="Raysettings",fileName ="Raysettings/Data")]
public class RaySettings : ScriptableObject
{
    [SerializeField] [Range(0.0f, 1000.0f)] private float rayDist;
    [SerializeField] [Range(-360.0f, 360.0f)] private float offSet;
    [SerializeField] [Range(0.0f, 5000.0f)] private float navDist;
    [SerializeField] [Range(0.0f, 5000.0f)] private float navMaxDist;
    [SerializeField] private LayerMask mask;
    [SerializeField] private Color rayColor;

    public float RayDist { get { return rayDist; } }
    public float OffSet { get { return offSet; } }
    public float NavDist { get { return navDist; } }
    public float NavMaxDist { get { return navMaxDist; } }
    public LayerMask Mask { get { return mask; } }
    public Color RayColor { get { return rayColor; } }
}
