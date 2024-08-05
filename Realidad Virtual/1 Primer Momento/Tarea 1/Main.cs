static void Main(string[] args)
    {
        var manager = new PersonajeManager();

        while (true)
        {
            Console.WriteLine("\nGestión de Personajes:");
            Console.WriteLine("1. Crear Personaje");
            Console.WriteLine("2. Listar Personajes");
            Console.WriteLine("3. Actualizar Personaje");
            Console.WriteLine("4. Eliminar Personaje");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Nombre: ");
                    var nombre = Console.ReadLine();
                    Console.Write("Descripcion: ");
                    var descripcion = Console.ReadLine();
                    Console.Write("Tipo: ");
                    var tipo = Console.ReadLine();
                    Console.WriteLine("Ingrese las acciones (separadas por comas): ");
                    var accionesInput = Console.ReadLine();
                    var acciones = accionesInput.Split(',').Select(a => a.Trim()).ToList();
                    manager.CrearPersonaje(nombre, descripcion, tipo, acciones);
                    break;
                case "2":
                    manager.ListarPersonajes();
                    break;
                case "3":
                    Console.Write("ID del Personaje a actualizar: ");
                    var idActualizar = int.Parse(Console.ReadLine());
                    Console.Write("Nuevo Nombre: ");
                    nombre = Console.ReadLine();
                    Console.Write("Nueva Descripcion: ");
                    descripcion = Console.ReadLine();
                    Console.Write("Nuevo Tipo: ");
                    tipo = Console.ReadLine();
                    Console.WriteLine("Ingrese las nuevas acciones (separadas por comas): ");
                    accionesInput = Console.ReadLine();
                    acciones = accionesInput.Split(',').Select(a => a.Trim()).ToList();
                    manager.ActualizarPersonaje(idActualizar, nombre, descripcion, tipo, acciones);
                    break;
                case "4":
                    Console.Write("ID del Personaje a eliminar: ");
                    var idEliminar = int.Parse(Console.ReadLine());
                    manager.EliminarPersonaje(idEliminar);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }