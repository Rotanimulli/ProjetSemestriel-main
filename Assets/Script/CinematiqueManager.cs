using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematiqueManager : MonoBehaviour
{
   public static CinematiqueManager instance;
    private int counter;
    

    [SerializeField]
    int pyloneNb;
    int currentPylone;

    public void AddCounter()
    {
        currentPylone++;
        if (currentPylone >= pyloneNb)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    } 
}
