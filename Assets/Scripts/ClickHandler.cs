using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClickHandler : MonoBehaviour
{
  public int size;
  List<bool> isActive = new List<bool>();

  void Start()
  {
    isActive.AddRange(Enumerable.Repeat(true, size));
  }

  void Update()
  {
    if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
      RaycastHit hitInfo;

      if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == "button")
      {
        int index = int.Parse(hitInfo.collider.gameObject.name.Split(' ')[1]) - 1;

        isActive[index] = !isActive[index];
        GameObject.Find("popup " + (index + 1).ToString()).GetComponent<Renderer>().enabled = isActive[index];
      }
    }
  }
}
