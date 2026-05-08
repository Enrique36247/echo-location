# Echo-Labyrinth 🌀

**Echo-Labyrinth** es una experiencia de exploración atmosférica y navegación técnica en primera persona desarrollada en Unity. El jugador se encuentra atrapado en un laberinto de dimensiones masivas sumido en la oscuridad absoluta, donde el sonido es la única herramienta para revelar el entorno.

---

## 🌌 Concepto del Juego
En este proyecto, la luz no es una constante, sino un recurso activo. Utilizando la **ecolocalización**, el jugador debe emitir pulsos de sonido que iluminan momentáneamente las paredes y el suelo, permitiéndole memorizar la ruta y avanzar hacia la salida antes de que la oscuridad regrese.

## 🛠️ Mecánicas Principales

*   **Sistema de Eco (Ecolocalización):**
    *   Al activar el pulso, se genera una onda de luz radial que se expande por el escenario.
    *   La intensidad y el alcance disminuyen con el tiempo, creando una ventana limitada de visibilidad que desafía la memoria a corto plazo del jugador.
*   **Generación Procedural de Laberintos:**
    *   Mapas masivos (desde 30x30 hasta 60x60) generados aleatoriamente en cada ejecución.
    *   Algoritmo de **"Drunken Walk"** (Camino Borracho) que garantiza que siempre exista una ruta válida desde el punto de inicio hasta la meta.
*   **Navegación Técnica:**
    *   Experiencia centrada en la orientación espacial sin elementos de combate, priorizando la inmersión y la percepción sensorial.

## 🚀 Estructura del Proyecto

El flujo del juego se gestiona a través de tres escenas principales:
1.  **MainMenu:** Pantalla de inicio con opciones para iniciar la partida o salir del juego.
2.  **GameScene:** El núcleo del juego donde se genera el laberinto procedural y el jugador explora.
3.  **WinScene:** Escena de victoria que se activa automáticamente al alcanzar el objetivo.

## 📁 Scripts Clave

*   `MazeGenerator.cs`: Gestiona la creación del laberinto, los muros perimetrales y el camino garantizado.
*   `EchoSystem.cs`: Controla la emisión de ondas de luz, la progresión de la intensidad y los efectos de audio.
*   `PlayerMovement.cs`: Maneja el control del personaje y la cámara utilizando el *Unity Input System*.
*   `Goal.cs`: Gestiona la detección de victoria y la transición a la escena final.
*   `MenuManager.cs`: Administra la navegación entre menús y el estado del cursor (bloqueo/visibilidad).

## 🎮 Controles

| Acción | Tecla / Input |
| :--- | :--- |
| **Moverse** | `W`, `A`, `S`, `D` / Flechas |
| **Mirar** | Movimiento del Ratón |
| **Lanzar Eco** | `Clic Izquierdo` / `E` |
| **Interactuar Menú** | Ratón (Cursor desbloqueado) |

## 🛠️ Instalación y Configuración

1.  Clona este repositorio en tu máquina local.
2.  Abre el proyecto con **Unity 2022.3 LTS** o superior.
3.  Asegúrate de tener instalado el paquete **Input System** desde el *Package Manager*.
4.  Configura las escenas en el **Build Settings** (`File > Build Settings`) en el siguiente orden:
    *   `MainMenu` (Index 0)
    *   `GameScene` (Index 1)
    *   `WinScene` (Index 2)

