using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    [SerializeField] float _speed;

    private float _inputX;
    private float _inputZ;

    private void FixedUpdate()
    {
        _inputX = Input.GetAxis(HorizontalInput);
        _inputZ = Input.GetAxis(VerticalInput);

        if (_inputX != 0)
            Move(_inputX, Vector3.right);

        if (_inputZ != 0)
            Move(_inputZ, Vector3.forward);
    }

    private void Move(float input, Vector3 duration) =>
        transform.Translate(duration * input * _speed * Time.deltaTime, Space.World);
}
