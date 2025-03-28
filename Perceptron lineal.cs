using System;

class Perceptron
{
    static void Main(string[] args)
    {
        // Rango mínimo y máximo de los datos climáticos (para normalización)
        double minT = -10.0, maxT = 40.0;     // Rango típico de temperatura
        double minHR = 0.0, maxHR = 100.0;    // Humedad relativa en porcentaje
        double minP = 900.0, maxP = 1100.0;   // Presión atmosférica en hPa
        double minV = 0.0, maxV = 20.0;       // Velocidad del viento en m/s
        double minD = 0.0, maxD = 360.0;      // Dirección del viento en grados
        double minPrec = 0.0, maxPrec = 100.0; // Precipitación en mm
        double minN = 0.0, maxN = 100.0;      // Nubosidad en porcentaje

        // Datos climáticos normalizados
        double T = (21.0 - minT) / (maxT - minT);   // Temperatura en rango 0-1
        double HR = (65.0 - minHR) / (maxHR - minHR); // Humedad Relativa en rango 0-1
        double P = (1010.0 - minP) / (maxP - minP); // Presión Atmosférica en rango 0-1
        double V = (3.5 - minV) / (maxV - minV);    // Velocidad del Viento en rango 0-1
        double D = (90.0 - minD) / (maxD - minD);   // Dirección del Viento en rango 0-1
        double Prec = (0.2 - minPrec) / (maxPrec - minPrec); // Precipitación en rango 0-1
        double N = (50.0 - minN) / (maxN - minN);   // Nubosidad en rango 0-1

        // Pesos iniciales más pequeños
        double[] W = new double[7] { 0.01, -0.01, 0.01, -0.01, 0.01, -0.01, 0.01 };
        double theta = 0.05; // Umbral inicial
        double alpha = 0.001; // Tasa de aprendizaje reducida para mayor estabilidad

        // Valor deseado para la salida (por ejemplo, si es lluvia o no, en este caso 0 o 1)
        double desiredOutput = 0; // 0 -> no lluvia, 1 -> lluvia (para simplificar)

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
            Y = Math.Round(Y, 4); // Se limita el valor de Y a cuatro decimales

            // Error (valor deseado es 0 en este ejemplo)
            double error = desiredOutput - Y;

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
            Console.WriteLine($"Predicción (Y) = {Y}");
            Console.WriteLine($"Peso 1 = {Math.Round(W[0], 4)}");
            Console.WriteLine($"Peso 2 = {Math.Round(W[1], 4)}");
            Console.WriteLine($"Peso 3 = {Math.Round(W[2], 4)}");
            Console.WriteLine($"Peso 4 = {Math.Round(W[3], 4)}");
            Console.WriteLine($"Peso 5 = {Math.Round(W[4], 4)}");
            Console.WriteLine($"Peso 6 = {Math.Round(W[5], 4)}");
            Console.WriteLine($"Peso 7 = {Math.Round(W[6], 4)}");
            Console.WriteLine($"Theta = {Math.Round(theta, 4)}");
            Console.WriteLine($"Error = {Math.Round(error, 4)}");
            Console.WriteLine("---------------------------------");

            // Condición de parada si el error es suficientemente pequeño
            if (Math.Abs(error) < 0.01)
            {
                Console.WriteLine("Error suficientemente pequeño, el modelo ha convergido.");
                break;
            }
        }
    }
}
