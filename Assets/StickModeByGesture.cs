using UnityEngine;
using System;

public class StickModeByGesture : MonoBehaviour
{
    public StickModeToggle stickToggle;

    public OVRHand leftHand;
    public OVRHand rightHand;

    private bool wasDoingPinch = false;

    void Update()
    {
        bool leftPinch = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        bool rightPinch = rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        bool isPinchingBoth = leftPinch && rightPinch;

        // Detecta início do gesto (apenas quando começa, não a cada frame)
        if (isPinchingBoth && !wasDoingPinch)
        {
            stickToggle.ToggleStickMode();
        }

        wasDoingPinch = isPinchingBoth;
    }
}
