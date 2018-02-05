using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Zenject;

public class InputListener : ITickable
{
    private InputReceivedSignal _inputReceivedSignal;

    private float _xThrow;
    private float _yThrow;
    private Ray _mousePositionRay;
    private float _timeSinceLastButtonPress;

    [Inject]
    public void Construct(InputReceivedSignal inputReceivedSignal)
    {
        _inputReceivedSignal = inputReceivedSignal;
    }
    
    public void Tick()
    {
        GetHorizontalAndVerticalInputs();
        GetMousePositionRay();
        var rollButtonPressed = GetRollButton();

        // Package and send input event.
        var inputReceivedWrapper = new InputDataWrapper
        {
            XThrow = _xThrow,
            YThrow = _yThrow,
            RollButtonPressed = rollButtonPressed,
            MousePositionRay = _mousePositionRay
        };
        _inputReceivedSignal.Fire(inputReceivedWrapper);
    }

    private void GetHorizontalAndVerticalInputs()
    {
        _xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        _yThrow = CrossPlatformInputManager.GetAxis("Vertical");
    }

    private void GetMousePositionRay()
    {
        _mousePositionRay = Camera.main.ScreenPointToRay(
            new Vector3(CrossPlatformInputManager.mousePosition.x, 
                CrossPlatformInputManager.mousePosition.y, 
                Camera.main.farClipPlane));
    }

    private bool GetRollButton()
    {
        return CrossPlatformInputManager.GetButtonDown("Roll");
    }

    private void DrawMousepositionDebugRay()
    {
        Debug.DrawRay(_mousePositionRay.origin, _mousePositionRay.direction * 10, Color.yellow);
    }
}
