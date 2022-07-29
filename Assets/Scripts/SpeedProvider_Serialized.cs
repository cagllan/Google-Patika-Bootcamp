using UnityEngine;

public class SpeedProvider_Serialized : SpeedProviderBase
{
    [SerializeField] float _speedAmount;


    public override float GetSpeed()
    {
        return _speedAmount;
    }
}
