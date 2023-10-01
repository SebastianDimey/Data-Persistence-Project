using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NamePicker : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        // Agrega un Listener al evento "EndEdit" del InputField para detectar cuando se completa la edición.
        //inputField.onEndEdit.AddListener(ObtenerTexto);

        // También puedes obtener el texto inicial si es necesario.
        string textoInicial = inputField.text;
        Debug.Log("Texto inicial del InputField: " + textoInicial);
    }

     public void ObtenerTexto(string textoIngresado)
    {
        Debug.Log("Texto ingresado en el InputField: " + textoIngresado);

        // Puedes hacer algo con el texto ingresado aquí
    }

}
