using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeModesс : MonoBehaviour
{
    public KEK modeToChange;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponentInParent<XROrigin>(out var xrOrigin))
        {
            if(modeToChange == KEK.Turning 
                && xrOrigin.gameObject.TryGetComponent<ActionBasedSnapTurnProvider>(out var snapTurnProvider) 
                && xrOrigin.gameObject.TryGetComponent<ActionBasedContinuousTurnProvider>(out var continTurnProvider))
            {
                snapTurnProvider.enabled = !snapTurnProvider.enabled;
                continTurnProvider.enabled = !continTurnProvider.enabled;
            }
            if(modeToChange == KEK.Moving 
                && xrOrigin.gameObject.TryGetComponent<ActionBasedContinuousMoveProvider>(out var contMoveProvider))
            {
                contMoveProvider.enabled = !contMoveProvider.enabled;
            }
        }
    }
}

public static class Extention
{
    public static bool TryGetComponentInParent<T>(this GameObject self, out T component) where T : Component
    {
        component = self.GetComponentInParent<T>();
        return component != null;
    }
}

public enum KEK
{
    None =0,
    Moving = 1,
    Turning = 2
}
