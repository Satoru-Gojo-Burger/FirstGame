using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class View : MonoBehaviour
    {
        public float maxAngle = 30f;
        public float speed = 360f;
        public float power = 100f;
        [SerializeField]
        private Transform point;

        private Vector3 m_lastPointPosition;
        private Vector3 m_dir;
        private bool m_isDown = false;
        private Rigidbody m_rigidbody;
        private float m_angle = 0;


        private void Awake()
        {
            m_angle = maxAngle;
            m_rigidbody = GetComponent<Rigidbody>();
        }

        public void Down()
        {
            m_isDown = true;
        }

        public void Up()
        {
            m_isDown = false;
        }

        private void FixedUpdate()
        {
            if (m_isDown)
            {   
                m_angle = Mathf.MoveTowards(m_angle, -maxAngle, speed * Time.deltaTime);
            }
            else
            {
                m_angle = Mathf.MoveTowards(m_angle, maxAngle, speed * Time.deltaTime);
            }

            Vector3 localEulerAngles = transform.localEulerAngles;
            localEulerAngles.z = m_angle;
            transform.localEulerAngles = localEulerAngles;

            m_dir = (point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = point.position;
        }
    }
}
