using UnityEngine;

public class Walk : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9f;

    //Crouch mechanics
    public float crouchSpeed = 2.5f;
    public float standingHeight = 2f;
    public float crouchingHeight = 1f;
    public Transform cameraTransform;
    public float standingCameraY = 0.9f;
    public float crouchingCameraY = 0.45f;
    private bool isCrouching = false;
    //Transition speed for smoother crouching
    private float crouchTransitionSpeed = 5f;
    private float targetHeight;
    private float targetCameraY;

    private CharacterController controller;
    private float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        targetHeight = standingHeight;
        targetCameraY = standingCameraY;
    }

    void Update()
    {
        //Crouch controls
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;

            // Depending if player's crouching or not, set height and camera Y
            targetHeight = isCrouching ? crouchingHeight : standingHeight;
            targetCameraY = isCrouching ? crouchingCameraY : standingCameraY;
        }

        controller.height = Mathf.Lerp(controller.height, targetHeight, crouchTransitionSpeed);

        Vector3 camPos = cameraTransform.localPosition;
        camPos.y = Mathf.Lerp(camPos.y, targetCameraY, crouchTransitionSpeed * Time.deltaTime);
        cameraTransform.localPosition = camPos;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        move = Vector3.ClampMagnitude(move, 1f);

        if (controller.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }
        verticalVelocity += gravity * Time.deltaTime;

        float currentSpeed = isCrouching ? crouchSpeed : speed;
        Vector3 velocity = move * currentSpeed;
        velocity.y = verticalVelocity;
        controller.Move(velocity * Time.deltaTime);
    }
}
