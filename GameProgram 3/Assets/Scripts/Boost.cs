using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] bool state;
    [SerializeField] float force;
    [SerializeField] Rigidbody rigidbody;

    [Header("Ground Check")]
    [SerializeField] float rayDistance = 0.2f;
    [SerializeField] LayerMask groundLayer;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            state = true;
        }
    }

    private void FixedUpdate()
    {
        if(state)
        {
            Vector3 direction = new Vector3(rigidbody.linearVelocity.x, 0, rigidbody.linearVelocity.z);

            rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);

            state = false;
        }
    }

    bool IsGrounded()
    {
        Vector3 rayOrigin = rigidbody.position + Vector3.up * 0.1f;

        RaycastHit hit;

        bool grounded = Physics.Raycast(rayOrigin, Vector3.down, out hit, rayDistance);

        Debug.DrawRay(rayOrigin, Vector3.down * rayDistance, grounded ? Color.green : Color.red);

        return grounded;
    }
}
