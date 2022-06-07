using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    [SerializeField] TextMeshPro m_Object;
    [SerializeField] TextMeshPro l_Object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeRound(int round)
    {
        m_Object.text = "WAVE: " + round.ToString();
    }

    public void changeLives(int lives)
    {
        l_Object.text = "LIVES: " + lives.ToString();
    }

}
