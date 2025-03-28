using System;


class Perceptron
{
    // Función sigmoidal
    static double Sigmoide(double x)
    {
        return 1 / (1 + Math.Exp(-x));
    }


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


        // Pesos iniciales (aleatorizados para evitar que empiecen ya cerca de una solución)
        Random rand = new Random();
        double[] W = new double[7];
        for (int i = 0; i < W.Length; i++)
        {
            W[i] = rand.NextDouble() - 0.5;  // Pesos iniciales entre -0.5 y 0.5
        }


        double theta = rand.NextDouble() - 0.5; // Umbral inicial aleatorizado
        double alpha = 0.1;  // Tasa de aprendizaje ajustada


        // Valores deseados (supongamos que los tenemos para cada iteración)
        double[] valoresDeseados = new double[] { 0.1, 0.5, 0.2, 0.7, 0.4, 0.6, 0.8, 0.3, 0.5, 0.9, 0.7, 0.6, 0.2, 0.3, 0.8 };


        // Simulación de 15 iteraciones
        for (int iter = 0; iter < 15; iter++)
        {
            // Propagación hacia adelante (cálculo de Y lineal antes de la función sigmoidal)
            double Y = (T * W[0]) +
                       (HR * W[1]) +
                       (P * W[2]) +
                       (V * W[3]) +
                       (D * W[4]) +
                       (Prec * W[5]) +
                       (N * W[6]) - theta;


            // Aplicar la función de activación sigmoidal
            double Y_activacion = Sigmoide(Y);


            // Se limita el valor de Y a dos decimales
            Y_activacion = Math.Round(Y_activacion, 2);


            // Error (en base al valor deseado de la iteración actual)
            double error = valoresDeseados[iter] - Y_activacion;


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
            Console.WriteLine($"Iteración {iter + 1}:");
            Console.WriteLine($"Peso 1 = {Math.Round(W[0], 2)}");
            Console.WriteLine($"Peso 2 = {Math.Round(W[1], 2)}");
            Console.WriteLine($"Peso 3 = {Math.Round(W[2], 2)}");
            Console.WriteLine($"Peso 4 = {Math.Round(W[3], 2)}");
            Console.WriteLine($"Peso 5 = {Math.Round(W[4], 2)}");
            Console.WriteLine($"Peso 6 = {Math.Round(W[5], 2)}");
            Console.WriteLine($"Peso 7 = {Math.Round(W[6], 2)}");
            Console.WriteLine($"Theta = {Math.Round(theta, 2)}");
            Console.WriteLine($"Salida Activación (Sigmoidal) = {Y_activacion}");
            Console.WriteLine($"Error = {Math.Round(error, 2)}");
            Console.WriteLine("---------------------------------");
        }
    }
}
