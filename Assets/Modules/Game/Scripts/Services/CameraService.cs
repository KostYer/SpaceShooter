using UnityEngine;

namespace Game.GamePlay
{
    public class CameraService
    {
        public Camera MainCamera { get; }

        public CameraService(Camera mainCamera)
        {
            MainCamera = mainCamera;
        }



        public bool IsVisibleToCamera(Collider col)
        {

            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(MainCamera);
            if (GeometryUtility.TestPlanesAABB(planes, col.bounds)) {  return true; }

            return false;

        }

    }
}
 
