using System;

Console.WriteLine("¿Cómo te llamas?");
string nombre = Console.ReadLine(); // Guarda lo que el usuario escriba
Console.WriteLine("Hola, " + nombre);

Console.WriteLine(); // Línea en blanco opcional
Console.WriteLine("=== Reporte de Atención Veterinaria ===");

// Variables de entrada
string especieMascota = "perro";   // "perro", "gato", "conejo", "reptil"
int edadMascota = 7;               // edad en años
double peso = 28.5;                // peso en kilogramos
bool tieneVacunasAlDia = false;
bool esSocio = true;
string motivoConsulta = "cirugia"; // "vacuna", "revision", "cirugia", "urgencia"

// ----------------------------------------------------
// Parte 1 — Clasificación por etapa de vida
// ----------------------------------------------------
// Usamos switch expression con rangos Relacionales ( relational patterns )
string etapaVida = edadMascota switch
{
    < 1 => "Cachorro",
    >= 1 and <= 3 => "Joven",
    >= 4 and <= 8 => "Adulto",
    _ => "Senior" // '_' es el caso por defecto (mayor a 8)
};

Console.WriteLine($"Mascota: {especieMascota} | Edad: {edadMascota} años | Etapa: {etapaVida}");

// ----------------------------------------------------
// Parte 2 — Alerta de vacunación
// ----------------------------------------------------
string alertaVacuna = "";

if ((especieMascota == "perro" || especieMascota == "gato") && !tieneVacunasAlDia) 
{
    alertaVacuna = "ALERTA: vacunación urgente requerida";
} 
else if ((especieMascota == "perro" || especieMascota == "gato") && tieneVacunasAlDia) 
{
    alertaVacuna = "Vacunación al día"; 
} 
else 
{
    alertaVacuna = "Esquema de vacunación no aplica"; 
}

Console.WriteLine($"Estado de vacunación: {alertaVacuna}");

// ----------------------------------------------------
// Parte 3 — Costo base de la consulta
// ----------------------------------------------------
// Usamos un switch tradicional
decimal costoBase = 0m;

switch (motivoConsulta)
{
    case "vacuna":
        costoBase = 35000m;
        break;
    case "revision":
        costoBase = 50000m;
        break;
    case "cirugia":
        costoBase = 280000m;
        break;
    case "urgencia":
        costoBase = 150000m;
        break;
    default:
        costoBase = 0m;
        break;
}

// Usamos el formato de moneda $#,##0 con la cultura de Colombia o reemplazando comas para que imprima con punto
Console.WriteLine($"Motivo: {motivoConsulta} | Costo base: ${costoBase:N0}".Replace(',', '.'));

// ----------------------------------------------------
// Parte 4 — Descuento por membresía y peso
// ----------------------------------------------------
// Operador ternario anidado en una sola expresión
double porcentajeDescuento = esSocio ? (peso > 25.0 ? 15.0 : 10.0) : 0.0;

decimal descuento = costoBase * (decimal)(porcentajeDescuento / 100);
decimal costoFinal = costoBase - descuento;

Console.WriteLine($"Descuento: {porcentajeDescuento}% | Costo final: ${costoFinal:N0}".Replace(',', '.'));

// ----------------------------------------------------
// Parte 5 — Recomendación post-consulta
// ----------------------------------------------------
// Usamos if-else anidado
string recomendacion = "";

if (motivoConsulta == "cirugia")
{
    if (etapaVida == "Senior")
    {
        recomendacion = "Reposo absoluto por 10 días, control post-operatorio obligatorio";
    }
    else
    {
        recomendacion = "Reposo por 5 días, evitar ejercicio intenso";
    }
}
else if (motivoConsulta == "urgencia")
{
    if (!tieneVacunasAlDia)
    {
        recomendacion = "Atender urgencia y programar vacunación inmediata";
    }
    else
    {
        recomendacion = "Seguimiento en 48 horas";
    }
}
else
{
    recomendacion = "Seguimiento en próxima consulta de rutina";
}

Console.WriteLine($"Recomendación: {recomendacion}");