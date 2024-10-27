using UnityEngine;
using Utils.Singleton;
using Player;
using Events;
namespace Camera
{
    public class CameraHolder : DontDestroyMonoBehaviourSingleton<CameraHolder> 
    {
        [SerializeField] private UnityEngine.Camera mainCamera;

        public UnityEngine.Camera MainCamera => mainCamera;

        private Vector3 Origin;
        private Vector3 Difference;
        private Vector3 ResetCamera;

        private bool drag = false;
        public float cameraBorderWidth;

        private void Start()
        {
            EventsController.Subscribe<EventModels.Game.TargetColorNodesFilled>(this, OnTargetColorNodesFilled);
            ResetCamera = mainCamera.transform.position;
        }
        private void CameraStandartPosition()
        {
            mainCamera.transform.position = ResetCamera;
        }
        private void OnTargetColorNodesFilled(EventModels.Game.TargetColorNodesFilled e)
        {
            CameraStandartPosition();
        }
        private void LateUpdate()
        {
            
            if (PlayerController.PlayerState == PlayerState.Connecting)
                return;

            if (Input.GetMouseButton(0))
            {
                Difference = (mainCamera.ScreenToWorldPoint(Input.mousePosition)) - mainCamera.transform.position;
                if (drag == false)
                {
                    drag = true;
                    Origin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            else
            {
                drag = false;
            }

            if (drag)
            {
                mainCamera.transform.position = Origin - Difference;
                mainCamera.transform.position = new Vector3(
                Mathf.Clamp(mainCamera.transform.position.x, -cameraBorderWidth, cameraBorderWidth),
                Mathf.Clamp(mainCamera.transform.position.y, 0, 0), transform.position.z); ;
            }

            if (Input.GetMouseButton(1)) 
                CameraStandartPosition();
        }
    }
}