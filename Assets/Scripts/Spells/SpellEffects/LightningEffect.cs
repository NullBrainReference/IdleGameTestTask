
using UnityEngine;

public class LightningEffect : SpellEffect, IDuration
{
    public LightningEffect()
    {
        Duration = 1;
        TimeLeft = Duration;
        DurationType = DurationType.Duration;
    }

    public float Duration { get; set; }
    public float TimeLeft { get; set; }

    public override void OnUpdate()
    {
        TimeLeft -= Time.deltaTime;
    }

    public override void EffectReset()
    {
        TimeLeft = Duration;
    }
}
