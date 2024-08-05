#include <iostream>
#include <list>
#include <string>

using namespace std;

class Usuario {
public:
    int id;
    string nombre;
    string usuario;

    Usuario(int id, string nombre, string usuario) : id(id), nombre(nombre), usuario(usuario) {}
};

class CRUD {
private:
    list<Usuario> usuarios;

public:
    void crearUsuario(int id, string nombre, string usuario) {
        usuarios.push_back(Usuario(id, nombre, usuario));
    }

    void leerUsuarios() {
        for (const auto& usuario : usuarios) {
            cout << "ID: " << usuario.id << ", Nombre: " << usuario.nombre << ", Usuario: " << usuario.usuario << endl;
        }
    }

    void actualizarUsuario(int id, string nombre, string usuario) {
        for (auto& usr : usuarios) {
            if (usr.id == id) {
                usr.nombre = nombre;
                usr.usuario = usuario;
                return;
            }
        }
        cout << "Usuario con ID " << id << " no encontrado." << endl;
    }

    void eliminarUsuario(int id) {
        for (auto it = usuarios.begin(); it != usuarios.end(); ++it) {
            if (it->id == id) {
                usuarios.erase(it);
                return;
            }
        }
        cout << "Usuario con ID " << id << " no encontrado." << endl;
    }
};

int main() {
    CRUD crud;

    int opcion;
    while (true) {
        cout << "\n1. Crear usuario\n2. Leer usuarios\n3. Actualizar usuario\n4. Eliminar usuario\n5. Salir\n";
        cout << "Selecciona una opción: ";
        cin >> opcion;

        if (opcion == 5) break;

        int id;
        string nombre, usuario;

        switch (opcion) {
            case 1:
                cout << "Ingrese ID: ";
                cin >> id;
                cout << "Ingrese nombre: ";
                cin >> nombre;
                cout << "Ingrese usuario: ";
                cin >> usuario;
                crud.crearUsuario(id, nombre, usuario);
                break;
            case 2:
                crud.leerUsuarios();
                break;
            case 3:
                cout << "Ingrese ID del usuario a actualizar: ";
                cin >> id;
                cout << "Ingrese nuevo nombre: ";
                cin >> nombre;
                cout << "Ingrese nuevo usuario: ";
                cin >> usuario;
                crud.actualizarUsuario(id, nombre, usuario);
                break;
            case 4:
                cout << "Ingrese ID del usuario a eliminar: ";
                cin >> id;
                crud.eliminarUsuario(id);
                break;
            default:
                cout << "Opción no válida." << endl;
                break;
        }
    }

    return 0;
}
