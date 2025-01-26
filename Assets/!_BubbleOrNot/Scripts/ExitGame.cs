
using UnityEngine;
using JetBrains.Annotations;

namespace BubbleOrNot.Runtime
{
    [AddComponentMenu("")]
    public class ExitGame : MonoBehaviour
    {
        [PublicAPI]
        public void QuitGame()
        {
            Debug.Log("Bye Bye!");
            Application.Quit();
        }
    }
}