using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CinemaCamera : MonoBehaviour
{
    [SerializeField] private UnityEngine.Camera mainCamera;
    public UnityEngine.Camera MainCamera => mainCamera;

    public float pos;
    public CinemachineVirtualCamera cinemaCam;
    //public GameObject cinemaCam2;
    public Collider2D cinemaCam2;

    private void Start()
    {
        cinemaCam2 = gameObject.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D;
        //cinemaCam2 = FindObjectOfType<>
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            pos += 0.1f;
            mainCamera.transform.position = new Vector3(pos, 0, -10);
        }
    }

}
