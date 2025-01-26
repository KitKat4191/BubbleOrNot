
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string nameOfSceneToLoad)
        {
            SceneManager.LoadScene(nameOfSceneToLoad);
        }
    }
}