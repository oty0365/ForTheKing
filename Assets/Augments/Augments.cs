using UnityEngine;

public enum AugmentType
{
    SpinSpeedUp,
    DamageUp,
    HpUp
}
public class Augments : MonoBehaviour
{
    public AugmentType type;
    public string augmentName;
    public Sprite sprite;
    [TextArea] public string description;
    public virtual void ActiveAugment()
    {
        
    }
}
