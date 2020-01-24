using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ClickHandler : MonoBehaviour
{
  string githubUrl = "https://github.com/akshansh2000";
  string resumeUrl = "https://drive.google.com/open?id=1Fo3DassNroZhyX194y0XnZhFfZDzVvRA";
  public GameObject aboutMe, myHobbies;
  public VideoPlayer videoPlayer;
  bool isAboutMeActive = false, isHobbiesActive = false;

  void Start()
  {
    aboutMe.SetActive(false);
    myHobbies.SetActive(false);

    videoPlayer.Prepare();
  }

  void Update()
  {
    if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
      RaycastHit hitInfo;

      if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == "button")
      {
        switch (hitInfo.collider.gameObject.name)
        {
          case "github":
            Application.OpenURL(githubUrl);
            break;
          case "resume":
            Application.OpenURL(resumeUrl);
            break;
          case "hobbies":
            isHobbiesActive = !isHobbiesActive;
            myHobbies.SetActive(isHobbiesActive);

            if (isHobbiesActive) videoPlayer.Play();
            else videoPlayer.Pause();

            break;
          case "about me":
            isAboutMeActive = !isAboutMeActive;
            aboutMe.SetActive(isAboutMeActive);
            break;
        }
      }
    }
  }
}
