using UnityEngine;

namespace InfiniteTerrain.Controllers
{
    /// <summary>
    /// A simple implementation of a flying camera.
    /// Uses Mouse Look and acceleration axes to control.
    /// Can lock to terrain below with followTerrain, it will
    /// still fly the set height (above the terrain)
    /// </summary>
    public class FlyCamera : MonoBehaviour
    {
        public float movementSpeed;

        public float height;

        public bool followTerrain;

        public bool autoFly;

        private float sensitivityX = 6f;

        // Update is called once per frame
        private void Update()
        {
            // mouse look rotation
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            transform.localEulerAngles = new Vector3(0, rotationX, 0);

            // keyboard movement
            Vector3 moveVector = Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right;

            // autofly
            if (autoFly)
            {
                // turn off auto fly on key input.
                if (moveVector.magnitude > 0) autoFly = false;

                moveVector = transform.forward;
            }

            transform.Translate(moveVector * movementSpeed * Time.deltaTime, Space.World);
            Vector3 position = transform.position;
            position.y = height;

            if (followTerrain)
            {
                RaycastHit hitInfo;
                Physics.Raycast(new Vector3(transform.position.x, 100f, transform.position.z), -Vector3.up, out hitInfo, 100f);
                position.y = hitInfo.point.y + height;
            }

            transform.position = position;
        }
    }
}