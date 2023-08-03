using mvc.controlador;
using mvc.vista;
using mvc.modelo;

namespace dominio
{
    class Principal
    {
        static void Main(String[] args)
        {

            Controlador controlador = new(new Menu(), new Accion());
            controlador.IniciarPrograma();

        }
    }
}