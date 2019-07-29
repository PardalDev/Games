using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchFunctions : MonoBehaviour
{
    public AudioSource[] teclas;
    public AudioClip[] animals;
    public AudioClip[] notas;
    public AudioClip[] letras;
    public Dropdown d;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (d.value == 0)
        {
            switchToAnimals();
        }
        else {
            if (d.value == 1)
            {
                switchToNotes();
            }
            else {
                switchToLetras();
            }
        }
        
    }
    public void switchToAnimals() {
        teclas[0].clip = animals[0];
        teclas[1].clip = animals[1];
        teclas[2].clip = animals[2];
        teclas[3].clip = animals[3];
        teclas[4].clip = animals[4];
        teclas[5].clip = animals[5];
        teclas[6].clip = animals[6];
        teclas[7].clip = animals[7];
    }
    public void switchToNotes()
    {
        teclas[0].clip = notas[0];
        teclas[1].clip = notas[1];
        teclas[2].clip = notas[2];
        teclas[3].clip = notas[3];
        teclas[4].clip = notas[4];
        teclas[5].clip = notas[5];
        teclas[6].clip = notas[6];
        teclas[7].clip = notas[7];
    }
    public void switchToLetras()
    {
        teclas[0].clip = letras[0];
        teclas[1].clip = letras[1];
        teclas[2].clip = letras[2];
        teclas[3].clip = letras[3];
        teclas[4].clip = letras[4];
        teclas[5].clip = letras[5];
        teclas[6].clip = letras[6];
        teclas[7].clip = letras[7];
    }
}
