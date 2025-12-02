# Restaurant Ordering System – .NET Web API + Frontend JS

Proyecto fullstack para la gestión de pedidos de un restaurante.  
Incluye:

- **API REST** en `.NET` con **Clean Architecture**  
- **Frontend** en HTML + JavaScript modular (ES Modules)
- Panel de **cliente** y panel de **administrador**

Demuestra experiencia en:

- Clean Architecture
- EF Core + SQL Server
- Diseño de API REST
- Consumo de APIs desde frontend
- Manejo de estados de órdenes

---

## 🧱 Estructura del repositorio

```txt
.
├── RestaurantApi/           # Solución backend (.NET)
│   ├── Application/         # Capa de aplicación (DTOs, servicios, validaciones)
│   ├── Domain/              # Entidades de dominio
│   ├── Infrastructure/      # Persistencia, EF Core, migrations, UoW, queries/commands
│   ├── WebApi/              # API ASP.NET Core (controllers, middlewares, configuración)
│   └── Restaurant.sln       # Solución principal
└── FrontendRestaurant/      # Frontend estático HTML + JS
    ├── index.html           # Pantalla de selección Cliente / Admin
    ├── cliente.html         # UI de cliente (menú + armado de pedido)
    ├── admin.html           # Panel de administración de órdenes
    ├── css/styles.css       # Estilos (Bootstrap + custom)
    └── js/                  # Código JS modular
        ├── core/apiService.js
        ├── menu/menuController.js
        ├── menu/menuView.js
        ├── menu/orderView.js
        ├── admin/adminController.js
        └── main.js
```
# Arrancar el proyecto
- Instancia de SQLServer abierto en localhost Desktop.
- Aplicar Migraciones
- Dotnet Run en WebApi/
- Live Server en index.html