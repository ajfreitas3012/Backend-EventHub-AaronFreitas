# Backend EventHub - Aaron Freitas

Este repositorio contiene el **backend completo** del proyecto académico **EventHub**, desarrollado como parte de la materia de Ingeniería Informática en UCAB.  
Incluye la lógica de negocio para **Usuarios, Eventos y Pagos**, implementada en un único microservicio (`UsersService`) con persistencia en **PostgreSQL** y documentación automática con **Swagger**.

---

## 🚀 Tecnologías utilizadas

- **C# .NET 8** – Framework principal para el backend
- **ASP.NET Core Web API** – Exposición de endpoints REST
- **Entity Framework Core** – ORM para acceso a datos
- **PostgreSQL** – Base de datos relacional
- **Swagger / Swashbuckle** – Documentación y pruebas de API
- **Docker** – Contenedores para despliegue
- **Axios (frontend de compañero)** – Consumo de endpoints desde React/Vite

---

## 📂 Estructura del proyecto

Backend/ └── UsersService/ ├── Controllers/ │ ├── UsersController.cs │ ├── EventsController.cs │ └── PaymentsController.cs ├── Domain/ │ ├── User.cs │ ├── Event.cs │ └── Payment.cs ├── Repositories/ │ ├── IUserRepository.cs │ ├── IEventRepository.cs │ ├── IPaymentRepository.cs │ └── EfUserRepository.cs ├── Infrastructure/ │ └── AppDbContext.cs ├── Program.cs └── Startup.cs

Código

---

## 🔗 Endpoints principales

### Usuarios

- `POST /api/users` → Crear usuario
- `GET /api/users` → Listar usuarios
- `GET /api/users/{id}` → Obtener usuario por ID
- `PUT /api/users/{id}` → Actualizar usuario
- `DELETE /api/users/{id}` → Eliminar usuario

### Eventos

- `POST /api/events` → Crear evento
- `GET /api/events` → Listar eventos
- `GET /api/events/{id}` → Obtener evento por ID
- `PUT /api/events/{id}` → Actualizar evento
- `DELETE /api/events/{id}` → Eliminar evento

### Pagos

- `POST /api/payments` → Registrar pago
- `GET /api/payments` → Listar pagos
- `GET /api/payments/{id}` → Obtener pago por ID

---

## ⚙️ Configuración y ejecución

### 1. Clonar el repositorio

```bash
git clone https://github.com/ajfreitas3012/Backend-EventHub-AaronFreitas.git
cd Backend-EventHub-AaronFreitas/Backend/UsersService
2. Configurar PostgreSQL
Crea una base de datos llamada eventhub y ajusta la cadena de conexión en appsettings.json:

json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=eventhub;Username=postgres;Password=tu_password"
}
3. Ejecutar migraciones
bash
dotnet ef database update
4. Levantar el servidor
bash
dotnet run
El backend estará disponible en:

Código
http://localhost:5000
Swagger en:

Código
http://localhost:5000/swagger
🧪 Pruebas rápidas
Crear usuario:

json
POST /api/users
{
  "name": "Aaron",
  "email": "aaron@example.com"
}
Crear evento:

json
POST /api/events
{
  "title": "Concierto UCAB",
  "date": "2025-12-01T20:00:00",
  "location": "Caracas"
}
Registrar pago:

json
POST /api/payments
{
  "userId": 1,
  "eventId": 1,
  "amount": 50.00
}
👥 Autores
Aaron Freitas – Backend completo (Usuarios, Eventos, Pagos)

Víctor Paredes – Frontend + módulos de Auth, Reservas y Asientos

📌 Notas
Este backend está diseñado para integrarse fácilmente con el frontend desarrollado por Víctor Paredes.

Swagger expone todos los endpoints para pruebas rápidas.

El proyecto puede desplegarse en Docker junto con PostgreSQL para mayor portabilidad.
```
