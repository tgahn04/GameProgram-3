using UnityEngine;
using Photon.Pun;

public class Character : MonoBehaviourPun
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;
    [SerializeField] Rotation rotation;

    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    void Start()
    {
        DisableCamera();
    }

    void Update()
    {
        if(photonView.IsMine)
        {
            Pause();

            Control();

            Move();

            rotation.RotateY();
        }    
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MouseManager.Instance.SetMouse(true);

            PanelManager.Instance.Load(Panel.Pause);
        }
    }

    public void DisableCamera()
    {
        // 현재 플레이어가 나 자신이라면
        if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            Camera eye = transform.GetComponentInChildren<Camera>();

            eye.GetComponent<AudioListener>().gameObject.SetActive(false);

            eye.gameObject.SetActive(false);
        }
    }

    public void Control()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        // direction 방향을 단위 벡터로 설정합니다.
        direction.Normalize();
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
