
using UnityEngine;
using UnityEngine.SceneManagement;

using JetBrains.Annotations;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class SceneLoader : MonoBehaviour
    {
        [PublicAPI]
        public void LoadScene(string nameOfSceneToLoad)
        {
            Debug.Log("Loading scene: " + nameOfSceneToLoad);
            SceneManager.LoadScene(nameOfSceneToLoad);
        }
    }
}