using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Crosshair : MonoBehaviour
{
	private InputReceivedSignal _inputReceivedSignal;
	private Canvas _canvas;
	private Image _cursorImage;
	
	[Inject]
	public void Construct(InputReceivedSignal inputReceivedSignal)
	{
		_inputReceivedSignal = inputReceivedSignal;
		_cursorImage = GetComponent<Image>();
		_canvas = GetComponentInParent<Canvas>();
	}

	private void Start()
	{
		Cursor.visible = false;
	}

	private void OnReceiveInput(InputDataWrapper inputDataWrapper)
	{
		var inputData = inputDataWrapper;

		var screenToWorldPointMousePosition = inputData.MousePositionRay.GetPoint(_canvas.planeDistance);

		_cursorImage.rectTransform.position = screenToWorldPointMousePosition;
	}
	
	private void OnEnable()
	{
		_inputReceivedSignal += OnReceiveInput;
	}

	private void OnDisable()
	{
		_inputReceivedSignal -= OnReceiveInput;
		Cursor.visible = true;
	}
}
