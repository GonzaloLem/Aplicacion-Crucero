# Aplicacion de Viajes en Crucero 🚢

# Sobre Mí 🙋‍♂️
Hola, buenas! Me Llamo Gonzalo Lemiña, tengo 21 años y estoy estudiando para Técnico superior en Programación.Cree esta aplicación con el fin de mostrar mis capacidades en el entorno de desarrolló .NET en el lenguaje C# y Base de datos en SQL Server
# Resumen de la Aplicación 💻
Esta aplicación consta en la venta de pasajes en cruceros a destinos puntos del mundo, los puntos de partidas son en argentina y los destinos están divididos en destinos Regionales o Extra regionales.

Al iniciar la aplicación se carga el formulario principal en cuál va a listar los viajes actuales que todavía no comenzaron/están en viaje y este formulario cuenta con los distintos botones que llevan a todas estas funciones mencionadas.

La idea de esta aplicación es aplicar todas las herramientas que ofrece el lenguaje y exprimirlas asi poder mostrar los conocimientos de este.
La aplicación actualmente cuenta con:

Un crud de Personas: Para agregar al sistema, ya sean clientes, empleados, capitanes de barcos.

Un crud de Cruceros: En el cual se va a poder elegir su capacidad de bodega, cantidad de camarotes, salones, etc.

Un crud de Viajes: En el cual se va a poder elegir los destinos, la fecha en el cual comenzara el viaje(Para crearlo tiene que ser con 16 días de anticipación no puede ser el mismo día y como fecha limite se pueden programar viajes con un año de anticipación) y el crucero que va a realizar el viaje. Al crear el viaje automaticamente se calcularan los datos necesarios para este como por ejemplo la cantidad de camarotes que se le asignara a la clase Turista y la Premium(35% de los camarotes para los premiums), el costo del pasaje turista y premium, este va a depender del destino y por ultimo se calculara la duracion del viaje.

Agregar persona al Viaje: Esta funcion permite agregar ya sea un empleado, capitan o cliente, este ultimo lo va a agregar si el crucero del viaje cumple con los requisitos del cliente

Estadísticas Históricas: Donde se puede ver las ganancias totales de los viajes, las horas de viaje de los cruceros y los destinos mas populares