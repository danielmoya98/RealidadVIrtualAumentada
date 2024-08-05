public class Movimiento
{
    public int ID { get; set; }
    public double EjeX { get; set; }
    public double EjeY { get; set; }
    public double EjeZ { get; set; }
    public DateTime Fecha { get; set; }

    public Movimiento(int id, double ejeX, double ejeY, double ejeZ, DateTime fecha)
    {
        ID = id;
        EjeX = ejeX;
        EjeY = ejeY;
        EjeZ = ejeZ;
        Fecha = fecha;
    }

    public override string ToString()
    {
        return $"ID: {ID}, EjeX: {EjeX}, EjeY: {EjeY}, EjeZ: {EjeZ}, Fecha: {Fecha}";
    }
}

public class MovimientoManager
{
    private List<Movimiento> movimientos = new List<Movimiento>();
    private int nextId = 1;

    // Crear un nuevo movimiento
    public void CrearMovimiento(double ejeX, double ejeY, double ejeZ, DateTime fecha)
    {
        var movimiento = new Movimiento(nextId++, ejeX, ejeY, ejeZ, fecha);
        movimientos.Add(movimiento);
        Console.WriteLine("Movimiento creado: " + movimiento);
    }

    // Leer (listar) todos los movimientos
    public void ListarMovimientos()
    {
        if (movimientos.Count == 0)
        {
            Console.WriteLine("No hay movimientos disponibles.");
            return;
        }

        foreach (var movimiento in movimientos)
        {
            Console.WriteLine(movimiento);
        }
    }

    // Actualizar un movimiento existente
    public void ActualizarMovimiento(int id, double ejeX, double ejeY, double ejeZ, DateTime fecha)
    {
        var movimiento = movimientos.FirstOrDefault(m => m.ID == id);
        if (movimiento != null)
        {
            movimiento.EjeX = ejeX;
            movimiento.EjeY = ejeY;
            movimiento.EjeZ = ejeZ;
            movimiento.Fecha = fecha;
            Console.WriteLine("Movimiento actualizado: " + movimiento);
        }
        else
        {
            Console.WriteLine("Movimiento no encontrado.");
        }
    }

    // Eliminar un movimiento
    public void EliminarMovimiento(int id)
    {
        var movimiento = movimientos.FirstOrDefault(m => m.ID == id);
        if (movimiento != null)
        {
            movimientos.Remove(movimiento);
            Console.WriteLine("Movimiento eliminado: " + movimiento);
        }
        else
        {
            Console.WriteLine("Movimiento no encontrado.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var manager = new MovimientoManager();

        while (true)
        {
            Console.WriteLine("\nGestión de Movimientos:");
            Console.WriteLine("1. Crear Movimiento");
            Console.WriteLine("2. Listar Movimientos");
            Console.WriteLine("3. Actualizar Movimiento");
            Console.WriteLine("4. Eliminar Movimiento");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Eje X: ");
                    var ejeX = double.Parse(Console.ReadLine());
                    Console.Write("Eje Y: ");
                    var ejeY = double.Parse(Console.ReadLine());
                    Console.Write("Eje Z: ");
                    var ejeZ = double.Parse(Console.ReadLine());
                    Console.Write("Fecha (YYYY-MM-DD): ");
                    var fecha = DateTime.Parse(Console.ReadLine());
                    manager.CrearMovimiento(ejeX, ejeY, ejeZ, fecha);
                    break;
                case "2":
                    manager.ListarMovimientos();
                    break;
                case "3":
                    Console.Write("ID del Movimiento a actualizar: ");
                    var idActualizar = int.Parse(Console.ReadLine());
                    Console.Write("Nuevo Eje X: ");
                    ejeX = double.Parse(Console.ReadLine());
                    Console.Write("Nuevo Eje Y: ");
                    ejeY = double.Parse(Console.ReadLine());
                    Console.Write("Nuevo Eje Z: ");
                    ejeZ = double.Parse(Console.ReadLine());
                    Console.Write("Nueva Fecha (YYYY-MM-DD): ");
                    fecha = DateTime.Parse(Console.ReadLine());
                    manager.ActualizarMovimiento(idActualizar, ejeX, ejeY, ejeZ, fecha);
                    break;
                case "4":
                    Console.Write("ID del Movimiento a eliminar: ");
                    var idEliminar = int.Parse(Console.ReadLine());
                    manager.EliminarMovimiento(idEliminar);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
