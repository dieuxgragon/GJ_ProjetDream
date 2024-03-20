using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> monde_1;
    public List<GameObject> monde_2;
    bool OnWorld1;
    bool SwitchPanel;
    public GameObject panel;
    // Start is called before the first frame update
    private void Start()
    {
        OnWorld1 = true;
        SwitchPanel = true;
    }

    public void SwitchWorld()
    {
        for (int i = 0; i < monde_1.Count; i++)
        {
            monde_1[i].SetActive(!OnWorld1);
        }
        for (int i = 0; i < monde_2.Count; i++)
        {
            monde_2[i].SetActive(OnWorld1);
        }
        OnWorld1 = !OnWorld1;
    }
    public void inventaire()
    {
        panel.SetActive(SwitchPanel);
        SwitchPanel = !SwitchPanel;
    }
}
