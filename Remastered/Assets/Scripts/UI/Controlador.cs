using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour {

    public int CantidadRecogida = 0;

    public void RecogerObjeto(int cantidad)
    {
        CantidadRecogida += cantidad;
    }

}

