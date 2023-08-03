using mvc.vista;
using mvc.modelo;

namespace mvc.controlador
{
    class Controlador
    {

        private Menu menu;
        private Accion accion;

        internal Controlador(Menu menu, Accion accion) =>
        (this.menu, this.accion) = (menu, accion);

        internal void IniciarPrograma()
        {
            int opcion = 0;
            string mensaje = "";
            bool mostrarCompletadas = false;

            do
            {
                Console.Clear();
                accion.EstablecerId(accion.ObtenerTareas());
                menu.MostrarEncabezado();
                menu.MostrarTareas(accion.ObtenerTareas(), mostrarCompletadas);
                menu.MostrarOpcionesMenu(mostrarCompletadas);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(mensaje);
                Console.ResetColor();

                opcion = accion.SolicitarOpcion("Digite una opción valida: ");

                switch (opcion)
                {
                    case 1:
                        mensaje = accion.AgregarTarea(accion.SolicitarTarea());
                        break;
                    case 2:
                        mensaje = accion.MarcarTarea(accion.SolicitarOpcion("Digite el Id de la tarea que desea cambiar el estado: "));
                        break;
                    case 3:
                        mensaje = "Vista cambiada";
                        mostrarCompletadas = !mostrarCompletadas;
                        break;
                    case 4:
                        mensaje = accion.BorrarTarea(accion.SolicitarOpcion("Digite el Id de la tarea que desea eliminar: "));
                        break;
                    case 5:
                        mensaje = "Opción seleccionada: 5";
                        break;
                    default:
                        mensaje = "Opción invalida";
                        opcion = 0;
                        break;
                }

            } while (opcion != 5);
        }
    }
}