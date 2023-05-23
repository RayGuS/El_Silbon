using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BaseDatos", menuName = "Inventario/Lista", order = 1)]

public class BaseDatos : ScriptableObject
{

    [System.Serializable]
    public struct ObjetoInvetario
    {
        public string nombre;
        public int ID;
        public Sprite imagen;
        public Tipo tipo;
        public bool acumulable;
        public string descripcion;
        public string vacio;
    }

    public enum Tipo
    {
        Consumible,
        Equipable
    }

    public ObjetoInvetario[] baseDatos;

}
