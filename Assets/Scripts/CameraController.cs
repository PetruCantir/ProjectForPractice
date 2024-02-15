using UnityEngine;

public class CameraController : MonoBehaviour
{
    private readonly string MouseX = "Mouse X";
    private readonly string MouseY = "Mouse Y";

    [SerializeField] private float _speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;

    private void Update()
    {      
       _camera.Rotate(_speed * Input.GetAxis(MouseY) * Time.deltaTime * -Vector3.right);
       _player.Rotate(_speed * Input.GetAxis(MouseX) * Time.deltaTime * Vector3.up);       
    }
}
