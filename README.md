# Practica final

## Cómo jugar
Para esta última práctica hemos hecho un juego libre. Al decidir qué hacer a pocos días de Navidad, nos hemos inspirado en una fábrica de juguetes para el diseño del juego.

En La Máquina de Juguetes, el jugador deberá completar los 14 juguetes pedidos en las cartas que se han recibido. Para ello, deberá meter las diferentes partes de los juguetes en la máquina para crear el juguete pedido. Pero deberá hacerlo antes de que se acabe el tiempo.

En cada carta hay una combinación aleatoria de las seis partes de los juguetes, cabeza, cuerpo, brazos y piernas, de entre cuatro tipos de juguete, muñeca, robot, conejo y osito de peluche. Para mezclar las piezas, el jugador deberá arrastrar, desde las cajas correspondientes, las piezas correctas a la máquina. Una vez estan todas las piezas en la máquina, deberá pulsar el botón de creación de juguetes. Con el juguete creado, deberá ponerlo sobre el papel de regalo y envolverlo, usando el botón de envolver. Si el juguete era el correcto, se abrirá la siguiente carta. Si no, habrá que volver a hacer el juguete. Si en algún momento el jugador se equivoca de pieza o completa un juguete equivocado, puede lanzar ambos a la papelera.

## Estructura e implementación
La implementación del juego se puede dividir en dos partes diferenciadas, aunque conectadas: el sistema de drag y drop y la creación y comparación de los juguetes.

Para el primero, creamos dos clases base, DropPoint y Draggable. Estas se encargarán de definir qué objetos se pueden arrastrar y cuáles son puntos en los que afecta soltar un objeto. En el caso de los DropPoint, comprobamos cuando un objeto de tipo Draggable entra en su Collider2D para avisar al Draggable de que puede soltar el objeto y de dónde lo está soltando. Además, se definen dos métodos abstractos que definirán qué debe pasar cuando un item o un juguete se sueltan sobre dicho DropPoint. Cabe destacar que no todos los DropPoints aceptarán tanto items como juguetes. Draggable, por su parte, se encarga de saber si puede ser soltado y dónde y de qué hacer cuando es soltado.

Tenemos tres clases que heredan de DropPoint: Trash, ToyMachineOpenPoint y WrapPoint. El primero simplemente destruye el elemento que ha sido lanzado y guarda el número de objetos tirados a la papelera. El segundo se encarga de guardar en ToyMachine el item que ha recibido. El último es el punto en el que el jugador dejará el juguete antes de envolverlo. Esta última clase también es importante para la comparación de juguetes, de la que hablaremos más adelante.

Draggable es una clase utilizada por otros tres elementos: la clase Box, el prefab DraggableItem y la clase ToyObject. Los dos primeros están relacionados, ya que Box detectará los clics de ratón sobre las cajas y creará un DraggableItem que será el Draggable que los DropPoints detectarán, correspondiente a las piezas de juguetes. Será Box, además, quién se encargue de mover el item y de detectar cuando ha sido soltado. La clase ToyObject, por su parte, hereda de Draggable, pero será ella misma la que detecte los clics del ratón que definirán si se mueve o se suelta el juguete.

Además, usamos una clase MouseControl a la que le pediremos la posición del ratón y que determinará si se deben detectar los clics en nuestro sistema de drag y drop o no.

El sistema de creación y comparación de juguetes tiene cinco clases esenciales: ItemSO, Letter, ToyMachine, Toy y WrapPoint.

ItemSO es un ScriptableObject con el que definimos todas las partes de los juguetes, definiendo qué parte del cuerpo son, qué tipo de juguete son y qué sprite se debe usar para representarlas. Toy, por su parte, define lo que es un juguete, es decir, un conjunto de lo que hemos llamado ToyParts. Una ToyPart se compone de tipo de juguete y parte del cuerpo. Con estas dos clases podremos comparar para cada parte utilizada para crear un juguete cuáles son iguales y cuáles no.

Letter, por su parte, se encarga de randomizar un nuevo juguete y mostrarlo cada vez que se abre una carta nueva. Esto se hará desde la clase LettersBox a la que llamaremos si el juguete anterior ha sido completado correctamente. Esta clase, además, sabrá cuando hemos completado todos los juguetes y se encargará de finalizar el juego cuando ocurra.

La clase ToyMachine tiene dos métodos importantes: AddPart y MakeToy. El primero, como ya hemos comentado, es llamado por ToyMachineOpenPoint cuando se suelta un item sobre la máquina, y simplemente guarda el ItemSO correspondiente al elemento añadido a la máquina. MakeToy, en cambio, se encarga de crear el juguete. Este será llamado por el botón de creación de juguete de la interfaz. Para la creación del juguete tendremos en cuenta la parte del cuerpo de cada item añadido y las colocaremos en la posición correcta, usando un prefab en el que determinamos la posición de cada parte del cuerpo. Si se añaden partes de más, se crearán en la misma posición con una rotación aleatoria. En el caso de los brazos y las piernas, comprobaremos si alguna de las dos extremidades usa el tipo de juguete correcto para que visualmente se vea que el juguete está bien hecho.

Finalmente, WrapPoint será quién se encargue de comparar el juguete a crear, guardado en la clase Letter, y el juguete creado en la clase ToyMachine. Este método, WrapToy, será llamado con el botón de envolver, que además solo activaremos si hay un juguete sobre este DropPoint. WrapToy, por tanto, comparará los dos juguetes, teniendo en cuenta el número de partes, que ninguna se repita y que sean del tipo de juguete correcto. Además, será quién llame a LettersBox para abrir una nueva carta si el juguete creado es correcto.

El proyecto se compone por otras clases con poca funcionalidad, como son OpenLetter, que detecta el clic sobre la carta abierta y activa la carta para ver el juguete a crear; o Timer, que se encarga de la cuenta atrás y que determinará cuando el jugador pierde la partida.

Por otro lado tenemos los llamados "Managers". Para los cambios entre escenas, usamos el MenuManager. El menú de pausa está controlado por la clase PauseManager, que además, controla la parada del tiempo. MusicManager se encarga de que la música sea continua entre todas las escenas, mientras que OptionsManager se encarga del volumen tanto de la música como de los efectos de sonido, que pueden ser editados desde el menú de opciones. GameManager, por su parte, sirve de conexión entre el juego y el MenuManager, además de almacenar datos sobre la partida: el tiempo utilizado, el número de juguetes completados y el número de items desperdiciados. Y EndCanvasManager utiliza los datos almacenados en PlayerPrefs, desde el GameManager, para actualizar el canvas y las estadísticas del fin del juego.

## Sprites y sonidos
Para esta PAC hemos elaborado todos los Sprites mediante el programa Inkscape.

Los efectos de sonido se han hecho mediante el programa Bfxr o se han encontrado en OpenGameArt, [Metal interactions](https://opengameart.org/content/metal-interactions) y [Sound Effects Pack](https://opengameart.org/content/sound-effects-pack).

La música de fondo es el [Wintery Loop](https://opengameart.org/content/wintery-loop) de [Emma_MA](https://opengameart.org/users/emmama).

## Builds
Se han hecho builds tanto para Windows, como para WebGL y Android.

Los builds se pueden encontrar [aquí]().

## Dificultades y problemas
Las mayores dificultades encontradas durante el proyecto han sido a la hora de crear los juguetes y compararlos, teniendo en cuenta todos los factores.

En cuanto al mayor problema, podemos destacar la falta de tiempo y la mala organización propia al estar realizando otras asignaturas a la vez. Quedan pendientes varias cosas que me gustaría haber hecho, como un tutorial antes de empezar la partida.

## Vídeo
![](PracticaFinal_video.mp4)





