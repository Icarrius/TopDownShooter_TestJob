using UnityEngine;

[CreateAssetMenu(fileName = "Aim colors data", menuName = "Colors/Aim Colors", order = 1)]
public class AimColorsSO : ScriptableObject
{
    public Color neutralColor;
    public Color collidedColor;
    public Color aimedColor;
}