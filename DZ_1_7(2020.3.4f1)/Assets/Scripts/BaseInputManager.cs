using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class BaseInputManager : MonoBehaviour
    {
        protected void PlayLevel(int sceneNumber)
        {
            SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
        }
    }
}