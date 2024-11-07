using System;
using System.Collections;
using System.Collections.Generic;
using Golf;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Stick stick;
        public StoneSpawner stoneSpawner;
        private float m_timer;
        [SerializeField]
        private float m_delay = 2f;
        private int m_score = 0;
        private int m_dif = 0;
        public TMPro.TextMeshProUGUI difficultText;
        private int m_MaxLife = 3;
        public int Life = 3;
        public Slider slider;

        private List<Stone> m_stones = new List<Stone>();

        public event Action<int> onGameOver;
        public event Action<int> onScoreInc;

        public void OnEnable()
        {
            m_timer = Time.time - m_delay;
            stick.onCollisionStone += OnCollisionStick;

            m_score = 0;

            ClearStones();
            Life = 3;
            slider.value = Life;
            m_delay = 2f;
            m_dif = 0;
            difficultText.text = $"EASY";
        }

        private void OnDisable()
        {
            if (stick)
            {
                stick.onCollisionStone -= OnCollisionStick;
            }
        }

        private void ClearStones()
        {
            foreach (var stone in m_stones)
            {
                Destroy(stone.gameObject);
            }

            m_stones.Clear();
        }

        private void Update()
        {
            if (Time.time > m_timer + m_delay)
            {
                m_dif += 1;
                m_timer = Time.time;
                var go = stoneSpawner.Spawn();
                var stone = go.GetComponent<Stone>();
                HardChenge(m_dif);
                stone.onCollisionStone += OnCollisionStone;

                m_stones.Add(stone);
            }

        }

        private void HardChenge(int count)
        {
            if (count < 20)
            {
                m_delay -= 0.05f;
            }
            if (count == 5)
            {
                m_delay -= 0.2f;
                difficultText.text = $"MEDIUM";
                Debug.Log($"dif: medium");
            }
            if (count == 10)
            {
                m_delay -= 0.2f;
                difficultText.text = $"HARD";
                Debug.Log($"dif: hard");
            }
            if (count == 15)
            {
                m_delay -= 0.2f;
                difficultText.text = $"IMPOSSIBLE";
                Debug.Log($"dif: impossible");
            }
        }

        private void OnCollisionStick()
        {
            m_score++; 
            Debug.Log($"score: {m_score}");
            onScoreInc?.Invoke(m_score);
        }

        private void OnCollisionStone()
        {
            Life -= 1;
            slider.value = Life;
            Debug.Log("Hit");
            if (Life == 0)
            {
            onGameOver?.Invoke(m_score);
            }
        }
    }
}