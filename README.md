# Proyecto Cardboard-z
## Autores

- **Javier Garcia Santana**
  - *Rol*: Desarrollador Centrado en Configuraciones Iniciales

- **Ibai Heras Rodrigalvarez**
  - *Rol*: Desarrollador de Interacción

- **Roberto Jesus Perez Medina**
  - *Rol*: Desarrollador de Integración y Pruebas

## Cuestiones importantes para el uso

1. **Requisitos del Sistema**: 
  - Unity 2020.3 o superior.
  - Dispositivo Android con soporte para ARCore.
  - Google Cardboard.

2. **Instalación**:
  - Clona el repositorio en tu máquina local.
  - Abre el proyecto en Unity.
  - Asegúrate de tener instalados los paquetes de AR Foundation y ARCore XR Plugin.
  - Conecta tu dispositivo Android y configura la compilación para Android.

3. **Ejecución**:
  - Compila y despliega la aplicación en tu dispositivo Android.
  - Inserta el dispositivo en el visor Google Cardboard.
  - Sigue las instrucciones en pantalla para iniciar la experiencia de realidad aumentada.

## Hitos de programación logrados

1. **Integración de Cardboard SDK**:
  - Implementación de detección de planos y colocación de objetos virtuales.
  - Uso de GazedAt para interacción con objetos en el entorno.

2. **Interacción Multimodal**:
  - Implementación de controles por mando para moverse.
  - Uso de sensores de movimiento para detección de orientación y posición del dispositivo.

3. **Optimización y Rendimiento**:
  - Optimización de modelos 3D para asegurar un rendimiento fluido.
  - Uso de técnicas de culling y LOD para mejorar la eficiencia gráfica.
  - Implementación de la librería nav mesh para que los zombies establezcan una ruta óptima con AI hacia el jugador

## Aspectos destacados de la aplicación

- **Experiencia Inmersiva**: La aplicación ofrece una experiencia de realidad aumentada inmersiva utilizando Google Cardboard y AR Foundation.
- **Interacción Natural**: Los usuarios pueden interactuar con objetos virtuales utilizando un mando y movimientos del dispositivo.
- **Compatibilidad**: La aplicación es compatible con una amplia gama de dispositivos Android que soportan ARCore.

## Sensores incluidos

- **Giroscopio y Acelerómetro**: Utilizados para detectar la orientación y movimientos del dispositivo, mejorando la interacción y la inmersión.
- **Cámara**: Utilizada para la detección de planos y la superposición de objetos virtuales en el entorno real.

## Acta de los acuerdos del grupo respecto al trabajo en equipo

### Reparto de Tareas

- **Javier Garcia Santana**:
  - Implementación de la detección de planos y colocación y animaciones de objetos virtuales.
  - Integración de AR Foundation y ARCore XR Plugin.
  - Desarrolador de scripts base para el correcto funcionamiento de la aplicación

- **Ibai Heras Rodrigalvarez**:
  - Desarrollo de la interacción con mando y uso de sensores de movimiento.
  - Configuración y despliegue de la aplicación en dispositivos Android.
  - Implementación de la librería Nav Mesh.

- **Roberto Jesus Perez Medina**:
  
  - Optimización de modelos 3D
  - Pruebas de rendimiento y aseguramiento de la compatibilidad con dispositivos.
  - Implementación de interfaz de usuario con escena GameOver


### Tareas Desarrolladas Individualmente

- **Javier Garcia Santana**:
  - Optimización de modelos 3D.
  - Aseguramiento de la compatibilidad con dispositivos.
  

- **Ibai Heras Rodrigalvarez**:
  - Desarrollo de controles por mando.
  - Configuración de la compilación para Android.
  - Implementación de la librería Nav Mesh.

- **Roberto Jesus Perez Medina**:
  - Pruebas de rendimiento.
  - Implementación de interfaz de usuario

### Tareas Desarrolladas en Grupo

- Integración de AR Foundation y ARCore XR Plugin.
- Implementación de la detección de planos y colocación de objetos virtuales.
- Pruebas y optimización de la aplicación para asegurar una experiencia de usuario fluida.
- Revisión y mejora continua del código y la funcionalidad de la aplicación.
- Documentación y preparación de la guía de usuario.

## Scripts Usados

1. **PlayerInterface.cs**:
  - Gestiona la vida del jugador y el estado de invulnerabilidad.
  - Controla la transición a la escena de Game Over cuando las vidas llegan a cero.
  - Implementa efectos visuales como la sangre al recibir daño.
  - Actualiza la interfaz de usuario para reflejar las vidas restantes.

2. **ZombieController.cs**:
  - Controla el comportamiento de los zombies, incluyendo su movimiento y ataques.
  - Utiliza NavMesh para la navegación y detección de colisiones con el jugador.
  - Cambia el material del zombie cuando es observado por la cámara.
  - Activa animaciones de ataque cuando el zombie está cerca del jugador.

3. **CharacterController.cs**:
  - Maneja el movimiento del jugador y la lógica de disparo.
  - Soporta entrada de teclado y gamepad para controlar el personaje.
  - Implementa la funcionalidad de sprint.
  - Calcula la dirección de movimiento relativa a la cámara para una navegación intuitiva.

4. **SpawnPointController.cs**:
  - Genera puntos de aparición para los zombies en intervalos regulares.
  - Controla la cantidad y la distancia entre los puntos de aparición.
  - Utiliza corrutinas para espaciar la generación de puntos de aparición en el tiempo.

5. **GameOverMenu.cs**:
  - Gestiona el menú de Game Over y las opciones de reiniciar o salir del juego.
  - Reinicia el juego cargando la escena principal cuando el jugador elige jugar de nuevo.
  - Evita múltiples reinicios utilizando una bandera de control.
  - Permite salir del juego y muestra un mensaje en la consola para depuración.

## Breve demostración del juego


https://github.com/user-attachments/assets/9e3acbea-6258-4e48-94d4-e6ac684021e5


