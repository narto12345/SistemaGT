namespace mvc.modelo
{
    class Tarea
    {

        private static int contador = 0;
        private int id;
        private string? nombre;
        private string? descripcion;
        private bool completa;

        public Tarea() { }

        public Tarea(int id, string nombre, string descripcion, bool completa) =>
        (this.id, this.nombre, this.descripcion, this.completa) =
        (id, nombre, descripcion, completa);

        public Tarea(string nombre, string descripcion) =>
        (this.id, this.nombre, this.descripcion, this.completa) = (++Tarea.contador, nombre, descripcion, false);

        public int Id { get { return this.id; } }
        public string? Nombre { get { return this.nombre; } }
        public string? Descripcion { get { return this.descripcion; } }
        public bool Completada { get { return this.completa; } set { this.completa = value; } }

        public static void EstablecerContador(int valor)
        {
            Tarea.contador = valor;
        }

        public override string ToString() => $"Tarea[id={this.id},nombre={this.nombre},descripción={this.descripcion},completada={this.completa}]";

    }
}