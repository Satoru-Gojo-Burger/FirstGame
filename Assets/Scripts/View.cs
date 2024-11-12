using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class View : MonoBehaviour
    {
        public GameObject MainCamera;
        public Transform View1;
        public Transform View2;

        public void Down()
        {
            MainCamera.transform.rotation = View1.transform.rotation;
        }
        public void Up()
        {
            MainCamera.transform.rotation = View2.transform.rotation;
        }
    }
}
