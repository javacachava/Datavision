# Datavision

Aplicación de consola en C# para la gestión de datasets de Machine Learning: alta, consulta y actualización de estado, con validación de entradas.

## Requisitos

- .NET SDK 10.0+

## Uso

```bash
dotnet run
```

## Funcionalidades

- **Agregar dataset**: registra código, nombre, cantidad de registros/variables, tipo de aprendizaje (`supervisado`, `no_supervisado`, `reforzamiento`) y estado (`sin_procesar`, `en_preparacion`, `listo_para_entrenar`).
- **Consultar datasets**: lista los datasets registrados.
- **Actualizar estado de dataset**: cambia el estado de un dataset existente.

## Estructura

- [Program.cs](Program.cs) — lógica principal y menú interactivo.
- [Datavision.csproj](Datavision.csproj) — configuración del proyecto .NET.
