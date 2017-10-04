//Presentación
TODO: Acaba con esto
->Start
=== Start ===
"Hola"
->Presentacion

=== Presentacion ===
VAR conocer = ->Nombre
{Nombre:
    ~conocer = ->No_escuchas
}
*   ...
    "¿Me escuchas?"#Mal
    ->Presentacion
*   {Presentacion == 1} Hola
    ->Danyo
*   {Presentacion > 1 && not Danyo} ¿Qué haces aquí?
    "Estaba dando un paseo y vi como tropezabas."
    ->Danyo
*   {Danyo} En realidad si que necesito tu ayuda.
    "¿Nos movemos?"
    ->Ayuda
+   [{&¿Quién eres?|¿Cómo te llamas?}] ->conocer
*   No quiero hablar []contigo.
    ->Fin
->DONE

=== Romance ===
Que hay?
->DONE

=== Nombre ===
"Me llamo Saphire."
"Entantada de conocerte."
->Presentacion

=== No_escuchas ===
Ya he respondido esa pregunta.
¿Acaso me prestas atención?
->Presentacion

=== Danyo ===
"¿Te encuetras bien? Ha sido una gran caida."
*   No es nada. 
    "Me alegro" ->Presentacion
*   Me duele. 
    "¿Quieres que busquemos ayuda?"
    ->Ayuda
*   Ni me hables. ->Fin

=== Ayuda ===
*   Si
    "Creo que hay un hospital aquí cerca."
    "Deja que te ayude a levantarte."
    ->Irse
*   No
    "¿Y que quieres que hagamos entonces?"
    ->Quedarse

=== Fin ===
"Pues adios."
->END

=== Irse ===
{Nombre: Saphire |La chica desconocida }<>
me ayudó a ponerme en pie y empezamos a caminar hacia el...
*   Claro -> Direcciones.Claro
*   Camino -> Direcciones.Camino
*   Bosque -> Direcciones.Bosque
*   Luz -> Direcciones.Luz

->DONE

=== Direcciones ===
= Claro
    ->DONE
= Camino
    ->DONE
= Bosque
    ->DONE
= Luz
    ->DONE

=== Quedarse ===
->DONE
