using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        public Stick stick;
        public View view;

        private void FixedUpdate()
        {
            // if (Input.GetMouseButton(0))
            // {   
            //     PointerDown();
            // }
            // else
            // {
            //     PointerUp();
            // }
        }

        public void PointerDown()
        {
            stick.Down();
        }

        public void PointerUp()
        {
            stick.Up();
        }

        public void ViewDown()
        {
            view.Down();
        }

        public void ViewUp()
        {
            view.Up();
        }
    }
}