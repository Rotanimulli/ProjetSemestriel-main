using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematiqueManager : MonoBehaviour
{
   public static CinematiqueManager instance;
    private int counter;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
