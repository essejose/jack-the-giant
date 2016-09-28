using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneFader : MonoBehaviour
{

    public static SceneFader instance;

    [SerializeField]
    private GameObject fadePanel;


    [SerializeField]
    private Animator fadeAnim;


    // Use this for initialization
    void Awake()
    {
      MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string level)
    {
        StartCoroutine(fadeInOut(level));
    }

    IEnumerator fadeInOut(string level)
    {
        fadePanel.SetActive(true);
        fadeAnim.Play("fadeIn");

        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));

        SceneManager.LoadScene(level);
        fadeAnim.Play("fadeOut");

        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(.7f));

        fadePanel.SetActive(false);
    }
}
