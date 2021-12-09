using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour,ICollsionHandler
{
  
    public Animator transition;

    [SerializeField]
    public float waitTime = 1f;

    IEnumerator LoadLevel(int LevelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(LevelIndex);

    }

    public void CollisionEnter(string colliderName, GameObject other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public void CollisionExit(string colliderName, GameObject other)
    {
        throw new System.NotImplementedException();
    }
}
