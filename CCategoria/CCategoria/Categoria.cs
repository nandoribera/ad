using System;
namespace CCategoria
{
  public class Categoria
        {
            private ulong id;
            private string nombre;

            //CONSTRUCTOR VACIO
            public Categoria()
            {

            }

            //CONSTRUCTOR CON PARAMETROS
            public Categoria(ulong id, string nombre)
            {
                this.id = id;
                this.nombre = nombre;
            }


            //GET Y SET
            public ulong Id
            {
                get { return id; }
                set { id = value; }
            }

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }
    }
}
