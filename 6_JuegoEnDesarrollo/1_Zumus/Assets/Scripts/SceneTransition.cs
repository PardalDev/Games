using System.Collections;
using UnityEngine;
//using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    private Animator transitionAnim;
    // Start is called before the first frame update
    
    public AudioClip MainMenu;
    public AudioClip BaseAudio;
    public AudioClip looseAudio;
    private AudioSource music;
    void Start()
    {
        music = GameObject.Find("Music").GetComponent<AudioSource>();
        transitionAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void LoadScene(string sceneName)
    {
        if (sceneName=="MainMenu"){
            music.clip = MainMenu;
            music.Play();
        }
        if (sceneName=="Game"){
            music.clip = BaseAudio;
            music.Play();
        }     
        if (sceneName=="lose"){
            music.clip = looseAudio;
            music.Play();
        }           
        StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName) {
       // transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1); //tiempo de animacion de salida
       /* if(Advertisement.IsReady("video")){
                Advertisement.Show("video");
        }*/
        SceneManager.LoadScene(sceneName);
    }
}
