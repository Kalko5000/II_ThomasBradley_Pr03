# Interfaces Inteligentes - Práctica 03 : Físicas  

- Autor: Thomas Edward Bradley  
- Fecha: 10/10/23  

## Resumen  
Se empieza a trabajar en unity con física (mediante rigidbodies), tambiendo avanzando más en el uso  
de vectores y movimiento. Además se empieza a trabajar con el Input Manager.  
## Tarea 01  
Para este apartado creé el script 'axisVelocity.cs', el cual solo tiene un float público (velocity).  
Tras esto uso GetKeyDown en lugar de GetKey para que no hayan demasiados mensajes en la consola. Hay un  
if que tiene en cuenta todas las inputs posibles, muestra el input por pantalla y luego los valores que  
toman las ejes horizontal y vertical.
## Tarea 02  
Abrí el Input Manager mediante Project Settings y cambie la tecla principal para disparar (shoot) a 'H'.
## Tarea 03  
Creé 'moveVector.cs' y se lo aplique al cubo, dentro de esta tenemos un float público speed (que determina  
la velocidad) y un Vector3 público moveDirection (que determina la dirección). Una vez hecho esto solo hay que  
pasar estos a un transform.Translate dentro del método Update(), multiplicandose junto con Time.DeltaTime (también  
se le pasa la especificacioón de Space). Los resultados de las pruebas son:  
- <u>Duplicar coordenadas de dirección</u> -> El cubo se mueve el doble de rapido
- <u>Duplicar velocidad</u> -> Ocurre lo mismo que en el caso anterior
- <u>Velocidad menor que 1</u> -> Se mueve más lento que si hubiesemos introducido solo la dirección
- <u>Cubo con y>0</u> -> Si movemos solo las coordenadas X/Z con la dirección, el cubo se mantendra flotando en el aire
- <u>Intercambiar movimiento relativo local y global</u> -> Si roto el cubo, con Space.Self sale volando respecto a donde la dirección y donde mira (no solo la primera)
## Tarea 04 
Creé dos scripts: 'controlCube.cs' y 'controlSphere.cs'. Para la segunda de estas tuve un float público  
'speed' que indica la velocidad de movimiento. Tras esto compruebo (mediante Input.GetKey) si se esta  
presionando W|S o A|D (dos posibles casos). Para el primero de estos casos multiplico (dentro de un  
transform.Translate) Vector3.forward por Input.GetAxis("Vertical") (esta sera positiva o negativa dependiendo  
del boton pulsado) por speed. Para los movimientos laterales es igual pero multiplicando por Vector3.right y  
por el eje horizontal. En cuanto al cubo el proceso fue el mismo pero con las flechas de dirección (aseguramos  
los botones dentro de cada script para que no mueva ambas al pusar una de las opciones, funcionan bien  
porque estan mapeadas en el Input Manager).
## Tarea 05  
En los dos scripts de la última tarea, hay que multiplicar el vector dentro del translate por Time.DeltaTime.
## Tarea 06 
Dentro de 'controlCube.cs' añado una referencia publica al GameObject de la esfera y dos Vector3 privados. El  
primero de estos 'direction', lo calculo restando la posición transform del propio objeto del de la esfera (ahora  
tiene la distancia entre estas). Lo normalizamos para obtener la dirección (y minimizar la velocidad de ella que no  
sea a travez de 'speed') y usamos la función Cross (pasandole direccion y Vector3.up) para obtener la dirección perpendicular  
necesaria para tener el movimiento lateral correcto (la cual también normalizamos). Ahora reemplazamos el Vector3.forward con  
direction y el Vector3.right con directionOp (notese que tambien hay que negar el input horizontal para que se comporte como  
esperado).
## Tarea 07  
Lo unico que tenemos que añadir a 'controlCube.cs' es un transform.LookAt justo antes de los translate, de modo que, el cubo  
girará a mirar la esfera cada vez que realizemos un movimiento (permitiendo que este circule a su alrededor).
## Tarea 08  
Aquí trabajamos con 'controlSphere.cs', lo primero que hice fue añadir un pequeño cilindro negro en frente de la esfera para  
saber en que dirección esta mirando. Ahora en el código, añado un nuevo float público para la velocidad de rotación, la cual  
utilizo para reemplazar 'speed' en el Translate para A|D. Dicho Translate lo cambio por transform.Rotate, le quito la especificación  
de Space y sustituyo el Vector3.right por Vector3.up (tambien cambio el Vector3.forward por transform.forward para que el objeto  
siempre mueva hacia su frente). Ahora funciona de manera parecida a un tanque, donde siempre se movera para delante o para detrás  
y se puede cambiar la rotación de la misma con A|D.  
## Tarea 09  
Le agregamos un rigidbody al cilindro, haciendolo físico (el cubo y la esfera ya tienen colliders y no hace falta modificarlos de  
momento). El script 'detectCollision.cs' es bastante simple, creamos una función OnCollisionEnter (donde guardamos con que se colisiono)  
y mediante Debug.Log mostramos el tag de esta por pantalla (junto con un mensaje descriptivo).
## Tarea 10  
Le añadimos el componente rigidbody a la esfera y al cubo, en esta segunda hay que darle tick a la caja isKinematic (lo cual viene a decir que  
al cubo no se le aplicara física). Tras hacer esto, me siguio funcionando igual que en la tarea previa, por lo que no modifique el script. Dicho  
esto, ahora hay que tener cuidado con la esfera ya que esta no se podra controlar correctamente si choca con otro objeto.
## Tarea 11  
Al cambiar el cilindro a un trigger caera al fin del mundo al empezar el juego, por lo que lo hice cinematico para resolver el problema.  
Tras esto hay que modificar 'detectCollsiion.cs' para que el mensaje se muestre ahora con OnTriggerEnter (para ello tambien tenemos que cambiar el tipo  
pasado de Collision a Collider).
## Tarea 12  
Para la última tarea, creé un nuevo cilindro, le puse el mismo tamaño en la eje Y que la esfera, le cambie de posición y le puse de color el negro.  
Tras esto le agregue es script 'controlCylinder.cs' que fue igual que 'controlCube.cs' perso cambiando las teclas de flechas por I|K y J|L. Para que esto  
funcione correctamente, hay que ir al Input Manager y agregar I|K como teclas alternativas para el movimiento vertical y J|L como alternativas para el horizontal.  
También le agregue el componente rigidbody. Los resultados de las pruebas fueron los siguientes:  
- <u>Esfera con x10 masa</u> -> Es mucho más dificil mantener la esfera recta, para poder moverla
- <u>Cilindro con x10 masa</u> -> El cilindro se muevo más lentamente
- <u>Cilindro cinematico</u> -> El cilindro ya no colisiona con el cubo, el cual también es cinematico
- <u>Cilindro como trigger</u> -> El cilindro cae fuera del mundo
- <u>Cilindro con fricción duplicada</u> ->  No note dinguna diferencia distinguible