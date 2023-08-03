using mvc.modelo;

namespace mvc.vista
{
    class Menu
    {
        private const string TITULO = "SISTEMA DE GESTIÓN DE TAREAS";
        private const string MENSAJE_BIENVENIDA = "Bienvenido al SistemaGT (Sistema de Gestión de Tareas):";
        private const string OPCIONES_MENU_1 = "1. Agregar tarea\n2. Marcar tarea\n3. Listar tareas completadas\n4. Eliminar tarea\n5. Salir";
        private const string OPCIONES_MENU_2 = "1. Agregar tarea\n2. Marcar tarea\n3. Listar tareas pendientes\n4. Eliminar tarea\n5. Salir";

        internal void MostrarEncabezado()
        {
            Console.WriteLine(Menu.TITULO);
            Console.WriteLine();
            Console.WriteLine(Menu.MENSAJE_BIENVENIDA);
            Console.WriteLine();
        }

        internal void MostrarOpcionesMenu(bool mostrarCompletadas)
        {
            Console.WriteLine();
            Console.WriteLine(mostrarCompletadas ? Menu.OPCIONES_MENU_2 : Menu.OPCIONES_MENU_1);
            Console.WriteLine();
        }

        internal void MostrarTareas(List<Tarea> tareas, bool mostrarCompletadas)
        {
            Console.WriteLine(mostrarCompletadas ? "Tareas completadas:\n" : "Tareas pendientes:\n");
            Console.WriteLine("|-----------------------------------------------------------------------|");
            Console.WriteLine("|  ID  |       NOMBRE         |   ESTADO   |      DESCRIPCIÓN           |");
            Console.WriteLine("|-----------------------------------------------------------------------|");
            tareas.ForEach(x =>
            {
                if (mostrarCompletadas && x.Completada)
                {
                    Console.WriteLine($"|  {this.ObtenerIdVisual(x.Id)}| {this.ObtenerNombreVisual(x.Nombre ?? "")} | {this.ObtenerEstadoVisual(x.Completada)} | {this.ObtenerDescripcionVisual(x.Descripcion ?? "")} |");
                }
                else if (!mostrarCompletadas && !x.Completada)
                {
                    Console.WriteLine($"|  {this.ObtenerIdVisual(x.Id)}| {this.ObtenerNombreVisual(x.Nombre ?? "")} | {this.ObtenerEstadoVisual(x.Completada)} | {this.ObtenerDescripcionVisual(x.Descripcion ?? "")} |");
                }
            });
            Console.WriteLine("|-----------------------------------------------------------------------|");
        }

        private string ObtenerIdVisual(int id)
        {
            string idVisual = $"{id}   ";
            if (id >= 10)
            {
                idVisual = $"{id}  ";
                if (id >= 100)
                {
                    idVisual = $"{id} ";
                }
            }
            return idVisual;
        }

        private string ObtenerNombreVisual(string nombre)
        {
            char[] nombreChar = nombre.ToCharArray();
            int numEspacios = 20 - nombreChar.Length;
            if (numEspacios >= 0)
            {
                for (int i = 0; i < numEspacios; i++)
                {
                    nombre += " ";
                }
            }
            else
            {
                char[] cadena = new char[20];
                for (int i = 0; i < 17; i++)
                {
                    cadena[i] = nombreChar[i];
                }

                cadena[17] = '.';
                cadena[18] = '.';
                cadena[19] = ' ';

                nombre = string.Join("", cadena);
            }

            return nombre;
        }

        private string ObtenerEstadoVisual(bool estado)
        {

            string estadoVisual;

            if (estado)
            {
                estadoVisual = "Completado";
            }
            else
            {
                estadoVisual = "Pendiente ";
            }

            return estadoVisual;
        }

        private string ObtenerDescripcionVisual(string nombre)
        {
            char[] nombreChar = nombre.ToCharArray();
            int numEspacios = 26 - nombreChar.Length;
            if (numEspacios >= 0)
            {
                for (int i = 0; i < numEspacios; i++)
                {
                    nombre += " ";
                }
            }
            else
            {

                char[] cadena = new char[27];
                for (int i = 0; i < 22; i++)
                {
                    cadena[i] = nombreChar[i];
                }

                cadena[23] = '.';
                cadena[24] = '.';
                cadena[25] = '.';
                cadena[26] = ' ';

                nombre = string.Join("", cadena);
            }

            return nombre;
        }
    }
}