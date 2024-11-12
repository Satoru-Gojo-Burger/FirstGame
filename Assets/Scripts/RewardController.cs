using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class RewardController : MonoBehaviour
    {
        public List<GameObject> Rewards;

        public void Zero()
        {
            GameInstance.score = 0;
        }
        public void oerZ()
        {
            GameInstance.score = 30;
        }

        void Update()
        {
            if (GameInstance.score >= 5)
            {
                Rewards[0].SetActive(true);
            }
            else
            {
                Rewards[0].SetActive(false);
            }

            if (GameInstance.score >= 10)
            {
                Rewards[1].SetActive(true);
            }
            else
            {
                Rewards[1].SetActive(false);
            }

            if (GameInstance.score >= 15)
            {
                Rewards[2].SetActive(true);
            }
            else
            {
                Rewards[2].SetActive(false);
            }

            if (GameInstance.score >= 20)
            {
                Rewards[3].SetActive(true);
            }
            else
            {
                Rewards[3].SetActive(false);
            }

            if (GameInstance.score >= 25)
            {
                Rewards[4].SetActive(true);
            }
            else
            {
                Rewards[4].SetActive(false);
            }

            if (GameInstance.score >= 30)
            {
                Rewards[5].SetActive(true);
            }
            else
            {
                Rewards[5].SetActive(false);
            }
        }
    }
}
