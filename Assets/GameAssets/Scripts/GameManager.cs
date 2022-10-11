using System.Linq;
using GameAssets.Scripts.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameAssets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Manager[] managers;

        private void Awake()
        {
            InitAllManagers();
        }


        private void InitAllManagers()
        {
            for (int i = 0; i < managers.Length; i++)
            {
                managers[i].Initialize();
            }
        }


        public void NextScene()
        {
            var managersReady = managers.All(m => m.IsReady());
            if (managersReady)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}