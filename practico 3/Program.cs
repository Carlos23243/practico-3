using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PracticaEstructuraDatos
{
        class Libro
    {
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public required string Categoria { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, Libro> mapaLibros = new Dictionary<string, Libro>();
            
            // CONJUNTO: Almacena categorías únicas (sin duplicados)
            HashSet<string> categoriasUnicas = new HashSet<string>();

            // Para medir el tiempo de ejecución (Análisis de rendimiento)
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // 1. Registro de datos
            RegistrarLibro(mapaLibros, categoriasUnicas, "978-01", "Cien años de soledad", "García Márquez", "Realismo Mágico");
            RegistrarLibro(mapaLibros, categoriasUnicas, "978-02", "Don Quijote", "Miguel de Cervantes", "Clásico");
            RegistrarLibro(mapaLibros, categoriasUnicas, "978-01", "Error Duplicado", "Anonimo", "Clásico"); // Prueba de ISBN repetido

            sw.Stop();

            // 2. Reportería (Visualizar y consultar elementos)
            MostrarReporte(mapaLibros, categoriasUnicas);

            // 3. Análisis de tiempo (Requisito de la guía)
            Console.WriteLine($"\n[ANÁLISIS]: Tiempo de ejecución: {sw.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static void RegistrarLibro(Dictionary<string, Libro> mapa, HashSet<string> conjunto, string isbn, string titulo, string autor, string cat)
        {
            if (mapa.ContainsKey(isbn))
            {
                Console.WriteLine($"(!) Error: El ISBN {isbn} ya existe en el sistema.");
                return;
            }

            // Inserción en Mapa: O(1)
            mapa.Add(isbn, new Libro { Titulo = titulo, Autor = autor, Categoria = cat });
            
            // Inserción en Conjunto: O(1) - Ignora duplicados automáticamente
            conjunto.Add(cat);
            
            Console.WriteLine($"(+) Libro '{titulo}' registrado correctamente.");
        }

        static void MostrarReporte(Dictionary<string, Libro> mapa, HashSet<string> conjunto)
        {
            Console.WriteLine("\n--- REPORTE GENERAL DE LIBROS (MAPA) ---");
            foreach (var item in mapa)
            {
                Console.WriteLine($"ISBN: {item.Key} | Título: {item.Value.Titulo} | Autor: {item.Value.Autor}");
            }

            Console.WriteLine("\n--- CATEGORÍAS EN LA BIBLIOTECA (CONJUNTO) ---");
            foreach (var cat in conjunto)
            {
                Console.WriteLine($"- {cat}");
            }
        }
    }
}