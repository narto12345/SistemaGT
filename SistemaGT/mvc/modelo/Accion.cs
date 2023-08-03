using System.IO;

namespace mvc.modelo
{
    class Accion
    {

        internal string AgregarTarea(Tarea tarea)
        {
            string respuesta = "No fue posible crear la tarea";

            try
            {
                StreamWriter sw = new StreamWriter("Tareas.txt", true);
                sw.WriteLine(tarea.Id);
                sw.WriteLine(tarea.Nombre);
                sw.WriteLine(tarea.Descripcion);
                sw.WriteLine(tarea.Completada);

                sw.Close();

                respuesta = "Tarea creada";
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return respuesta;
        }

        private bool ReescribirTareas(List<Tarea> tareas)
        {
            bool respuesta = false;

            File.Delete("Tareas.txt");

            StreamWriter sw = new StreamWriter("Tareas.txt", true);

            try
            {
                tareas.ForEach(tarea =>
                {
                    sw.WriteLine(tarea.Id);
                    sw.WriteLine(tarea.Nombre);
                    sw.WriteLine(tarea.Descripcion);
                    sw.WriteLine(tarea.Completada);
                });

                respuesta = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                sw.Close();
            }

            return respuesta;
        }

        internal int SolicitarOpcion(string mensaje)
        {
            int respuesta = 0;

            try
            {
                Console.WriteLine();
                Console.Write(mensaje);
                respuesta = Int32.Parse(Console.ReadLine() ?? "0");
            }
            catch (FormatException)
            {
            }
            catch (OverflowException)
            {
            }

            return respuesta;
        }

        internal Tarea SolicitarTarea()
        {
            Console.Write("\nDigite el nombre de la tarea*: ");
            string nombre = Console.ReadLine() ?? "";

            while (nombre == "")
            {
                Console.Write("La tarea es obligatoria...");
                Console.Write("Por favor digite el nombre de la tarea*: ");
                nombre = Console.ReadLine() ?? "";
            }

            Console.Write("Digite la descripción de la tarea:\nNota: Si no desea agregar una descripción, presione ENTER: ");
            string descripcion = Console.ReadLine() ?? "";
            if (descripcion == "")
            {
                descripcion = "ninguna";
            }

            return new(nombre.Replace("\t", " ").Trim(), descripcion.Replace("\t", " ").Trim());
        }

        internal List<Tarea> ObtenerTareas()
        {
            List<Tarea> tareas = new List<Tarea>();

            String? line;

            try
            {

                StreamReader sr = new StreamReader("Tareas.txt");
                line = sr.ReadLine();

                while (line != null)
                {
                    int id = Int32.Parse(line);
                    line = sr.ReadLine();
                    string? nombre = line ?? "";
                    line = sr.ReadLine();
                    string? descripcion = line == "ninguna" ? "" : line;
                    line = sr.ReadLine();
                    string lineBoolean = line == "False" ? "false" : "true";
                    bool completa = bool.Parse(lineBoolean ?? "false");
                    line = sr.ReadLine();

                    tareas.Add(new(id, nombre, descripcion ?? "", completa));
                }


                sr.Close();
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {

            }

            return tareas;
        }

        internal void EstablecerId(List<Tarea> tareas)
        {
            Tarea.EstablecerContador(tareas.Count == 0 ? 0 : tareas[tareas.Count - 1].Id);
        }

        internal string BorrarTarea(int Id)
        {
            string respuesta = "La tarea no existe";
            Tarea tareaEliminar = new Tarea();
            Tarea tareaAux = tareaEliminar;
            List<Tarea> tareas = this.ObtenerTareas();

            tareas.ForEach(x =>
            {
                if (x.Id == Id)
                {
                    tareaEliminar = x;
                }
            });

            if (tareas.Remove(tareaEliminar))
            {
                respuesta = this.ReescribirTareas(tareas) ? "La Tarea fue eliminada" : "Error en la eliminación";
            }

            return respuesta;
        }

        internal string MarcarTarea(int Id)
        {
            string respuesta = "La tarea no existe";
            List<Tarea> tareas = this.ObtenerTareas();

            tareas.ForEach(x =>
            {
                if (x.Id == Id)
                {
                    x.Completada = !x.Completada;
                    respuesta = "La Tarea fue marcada como " + (x.Completada ? "Completada" : "Pendiente");
                }
            });

            respuesta = this.ReescribirTareas(tareas) ? respuesta : "Error en la marcación";

            return respuesta;
        }

    }
}