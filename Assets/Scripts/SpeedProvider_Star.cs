using UnityEngine;

public class SpeedProvider_Star : SpeedProviderBase
{
    [SerializeField] StarDataSO starData;

    public override float GetSpeed()
    {
        return starData.RotationSpeed;
    }
}
