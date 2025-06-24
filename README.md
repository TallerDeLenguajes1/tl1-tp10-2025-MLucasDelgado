[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/myQ-2FG7)

# Trabajo Práctico N°10 – Taller de Lenguajes I – 2025

**Alumno:** Lucas Delgado  
**Carrera:** Programador Universitario / Licenciatura en Informática  
**Año:** 2025

---

## Descripción

Este repositorio contiene la resolución del Trabajo Práctico N°10 para la materia Taller de Lenguajes I.  
Se desarrollaron aplicaciones de consola en C# que consumen APIs REST, muestran datos en consola y guardan la información en archivos JSON.

Las aplicaciones están organizadas en las siguientes carpetas:

- `Tareas`  
- `Usuarios`  
- `MiWebApi`

---

## Ejercicio 1 – Carpeta: `Tareas`

- Se implementó una aplicación que consume el endpoint:
  
  `https://jsonplaceholder.typicode.com/todos/`

- Se definió la clase `Tarea` acorde a la estructura JSON.
- Se utilizó `HttpClient` para realizar una petición GET asíncrona.
- La respuesta JSON fue deserializada en una lista de objetos `List<Tarea>`.
- Se muestran en consola las tareas con:
  - Título
  - Estado (Pendiente / Completada), mostrando primero las tareas pendientes y luego las completadas.
- La lista completa se serializa y guarda en un archivo `tareas.json`.

---

## Ejercicio 2 – Carpeta: `Usuarios`

- Se implementó una aplicación que consume el endpoint:
  
  `https://jsonplaceholder.typicode.com/users/`

- Se definió la clase `Usuario`, incluyendo la clase `Address` para el domicilio.
- Se utilizó una instancia estática de `HttpClient` para la petición GET.
- La respuesta JSON fue deserializada en `List<Usuario>`.
- Se muestran en consola los datos de los primeros cinco usuarios:
  - Nombre
  - Correo electrónico
  - Domicilio (calle, suite, ciudad, código postal)
- Se guarda la lista completa en el archivo `usuarios.json`.

---

## Ejercicio 3 – Carpeta: `MiWebApi`

- Se implementó una aplicación que consume la API pública de anime:
  
  `https://api.jikan.moe/v4/anime?q=naruto`

- Se definieron las clases `AnimeCaracteristicas` y `AnimeResponse` para mapear la estructura JSON.
- Se utilizó `HttpClient` para obtener los datos de la API.
- Se deserializó la respuesta y se muestran en consola los primeros 10 animes con:
  - Título
  - Episodios
  - Rating
  - Score
  - Año de estreno
  - Sinopsis
- Se implementó manejo de errores con `try-catch`.
- Se guarda la información completa en un archivo `anime.json`.

---

## Tecnologías utilizadas

- Lenguaje: C# (.NET 6.0)
- Librerías:
  - System.Net.Http.HttpClient
  - System.Text.Json
- Herramientas: Visual Studio Code
- APIs públicas REST

---

¡Gracias por revisar!  