#include <iostream>
#include <list>
#include <string>

using namespace std;

class Puntaje {
public:
    int id;
    string nombre;
    int puntos;

    Puntaje(int id, string nombre, int puntos) : id(id), nombre(nombre), puntos(puntos) {}
};

class CRUD {
private:
    list<Puntaje> puntajes;

public:
    void crearPuntaje(int id, string nombre, int puntos) {
        puntajes.push_back(Puntaje(id, nombre, puntos));
    }

    void leerPuntajes() {
        for (const auto& puntaje : puntajes) {
            cout << "ID: " << puntaje.id << ", Nombre: " << puntaje.nombre << ", Puntos: " << puntaje.puntos << endl;
        }
    }

    void actualizarPuntaje(int id, string nombre, int puntos) {
        for (auto& pnt : puntajes) {
            if (pnt.id == id) {
                pnt.nombre = nombre;
                pnt.puntos = puntos;
                return;
            }
        }
        cout << "Puntaje con ID " << id << " no encontrado." << endl;
    }

    void eliminarPuntaje(int id) {
        for (auto it = puntajes.begin(); it != puntajes.end(); ++it) {
            if (it->id == id) {
                puntajes.erase(it);
                return;
            }
        }
        cout << "Puntaje con ID " << id << " no encontrado." << endl;
    }
};

int main() {
    CRUD crud;

    int opcion;
    while (true) {
        cout << "\n1. Crear puntaje\n2. Leer puntajes\n3. Actualizar puntaje\n4. Eliminar puntaje\n5. Salir\n";
        cout << "Selecciona una opción: ";
        cin >> opcion;

        if (opcion == 5) break;

        int id;
        string nombre;
        int puntos;

        switch (opcion) {
            case 1:
                cout << "Ingrese ID: ";
                cin >> id;
                cout << "Ingrese nombre: ";
                cin >> nombre;
                cout << "Ingrese puntos: ";
                cin >> puntos;
                crud.crearPuntaje(id, nombre, puntos);
                break;
            case 2:
                crud.leerPuntajes();
                break;
            case 3:
                cout << "Ingrese ID del puntaje a actualizar: ";
                cin >> id;
                cout << "Ingrese nuevo nombre: ";
                cin >> nombre;
                cout << "Ingrese nuevos puntos: ";
                cin >> puntos;
                crud.actualizarPuntaje(id, nombre, puntos);
                break;
            case 4:
                cout << "Ingrese ID del puntaje a eliminar: ";
                cin >> id;
                crud.eliminarPuntaje(id);
                break;
            default:
                cout << "Opción no válida." << endl;
                break;
        }
    }

    return 0;
}
