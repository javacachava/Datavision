# Datavision

Aplicación de consola en C# para la gestión de datasets de Machine Learning: alta, consulta y actualización de estado, con validación de entradas.

## Requisitos

- .NET SDK 10.0+

## Uso

```bash
dotnet run
```

## Funcionalidades

- **Registrar dataset**: código (único), nombre, área de aplicación, cantidad de registros/variables, tipo de aprendizaje (Supervisado, No supervisado, Reforzamiento). El estado inicial siempre es "Sin procesar".
- **Consultar dataset**: busca por código y muestra toda su información.
- **Actualizar estado**: avanza el estado de un dataset en el orden Sin procesar → En preparación → Listo para entrenamiento.
- **Listar datasets**: muestra todos los datasets registrados.
- **Buscar por área de aplicación**: filtra los datasets que pertenecen a un área dada.
- **Mostrar estadísticas**: total de datasets, cantidad por tipo de aprendizaje, promedio de registros, dataset con más registros, dataset con más variables y cantidad de datasets listos para entrenamiento.

Toda la información se almacena en arreglos paralelos (máximo 100 datasets), sin usar clases ni estructuras propias — solo arreglos, funciones y estructuras de control.

## Estructura

- [Program.cs](Program.cs) — lógica principal y menú interactivo.
- [Datavision.csproj](Datavision.csproj) — configuración del proyecto .NET.
