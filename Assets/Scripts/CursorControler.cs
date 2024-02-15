using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Transform _camera; 
    [SerializeField] private Image _cursorImage; 

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = _camera.GetComponent<Camera>().ScreenToWorldPoint(mousePosition);
        _cursorImage.rectTransform.position = worldPosition;
    }
}
