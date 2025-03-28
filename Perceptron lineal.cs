using System;
class Perceptron
{
    static void Main(string[] args)
    {
        // Variables climáticas (fijas en cada iteración)
        double T = 21.0;   // Temperatura
        double HR = 65.0;  // Humedad Relativa
        double P = 1010;   // Presión Atmosférica
        double V = 3.5;    // Velocidad del Viento
        double D = 90;     // Dirección del Viento
        double Prec = 0.2; // Precipitación
        double N = 50;     // Nubosidad
        // Pesos iniciales
        double[] W = new double[7] { 0.30, -0.50, 0.15, -0.20, 0.40, -0.60, 0.10 };
        double theta = 0.40; // Umbral inicial
        double alpha = 0.00001; // Tasa de aprendizaje (más estable)
        // Simulación de 15 iteraciones
        for (int iter = 1; iter <= 15; iter++)
        {
            // Propagación hacia adelante (cálculo de Y)
            double Y = (T * W[0]) +
                       (HR * W[1]) +
                       (P * W[2]) +
                       (V * W[3]) +
                       (D * W[4]) +
                       (Prec * W[5]) +
                       (N * W[6]) - theta;
            // Se limita el valor de Y a dos decimales
            Y = Math.Round(Y, 2);


            // Error (suponiendo que el valor deseado sea 0 para este ejemplo)
            double error = 0 - Y;
            // Actualización de los pesos y theta
            W[0] += alpha * error * T;
            W[1] += alpha * error * HR;
            W[2] += alpha * error * P;
            W[3] += alpha * error * V;
            W[4] += alpha * error * D;
            W[5] += alpha * error * Prec;
            W[6] += alpha * error * N;
            theta -= alpha * error;
            // Mostrar los resultados de la iteración
            Console.WriteLine($"Iteración {iter}:");
            Console.WriteLine($"Peso 1 = {Math.Round(W[0], 2)}");
            Console.WriteLine($"Peso 2 = {Math.Round(W[1], 2)}");
            Console.WriteLine($"Peso 3 = {Math.Round(W[2], 2)}");
            Console.WriteLine($"Peso 4 = {Math.Round(W[3], 2)}");
            Console.WriteLine($"Peso 5 = {Math.Round(W[4], 2)}");
            Console.WriteLine($"Peso 6 = {Math.Round(W[5], 2)}");
            Console.WriteLine($"Peso 7 = {Math.Round(W[6], 2)}");
            Console.WriteLine($"Theta = {Math.Round(theta, 2)}");
            Console.WriteLine($"Salida Activación = {Y}");
            Console.WriteLine($"Error = {Math.Round(error, 2)}");
            Console.WriteLine("---------------------------------");
        }
    }
}