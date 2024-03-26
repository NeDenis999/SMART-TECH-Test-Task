using UnityEngine.SceneManagement;

namespace Game
{
    public class ResetButton : BaseButton
    {
        protected override void OnClick()
        {
            SceneManager.LoadScene(0);
        }
    }
}