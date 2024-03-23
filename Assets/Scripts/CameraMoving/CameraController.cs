using Cinemachine;
using UnityEngine;

namespace CameraMoving
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float speed = 5;
        private CinemachineVirtualCamera cinemachine;

        [SerializeField] private float OrthographicSize = 5;

        private Vector2 mousePos;

        private void Awake()
        {
            cinemachine = GetComponent<CinemachineVirtualCamera>();
        }


        private void Update()
        {
            MoveInUpdate();
            ZoomInUpdate();
        }

        private void MoveInUpdate()
        {
            Vector3 moveVector = Vector3.zero;
            if (Input.GetMouseButtonDown(2))
            {
                mousePos = Input.mousePosition;
            }

            if (Input.GetMouseButton(2))
            {
                Vector2 curMousePos = Input.mousePosition;
                Vector2 move = Camera.main.ScreenToWorldPoint(mousePos) - Camera.main.ScreenToWorldPoint(curMousePos);
                moveVector.x = move.x;
                moveVector.y = move.y;
                mousePos = curMousePos;
            }
            else
            {
                moveVector.x = Input.GetAxis("Horizontal");
                moveVector.y = Input.GetAxis("Vertical");
                moveVector *= speed * Time.deltaTime;
            }

            transform.position += moveVector;
        }

        private void ZoomInUpdate()
        {
            OrthographicSize -= Input.GetAxis("Mouse ScrollWheel");
            cinemachine.m_Lens.OrthographicSize = Mathf.Lerp(cinemachine.m_Lens.OrthographicSize, OrthographicSize, 0.2f);
        }

        public void Follow(Transform target)
        {
            cinemachine.Follow = target;
        }
    }
}