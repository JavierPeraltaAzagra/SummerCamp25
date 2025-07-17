internal class Program
{
    private static void Main(string[] args)
    {
        int num = 1;

        while (num != 0) { 
            Console.Write("Introduce un número del 1 al 7 (o 0 para salir): ");

            try { 
                num = int.Parse(Console.ReadLine()); 
            } catch (Exception ex) {
                num = 8;
            }
            
            switch (num)
            {
                case 0:
                    Console.WriteLine("¡Hasta luego!");
                    break;
                case 1:
                    Console.WriteLine("Lunes");
                    break;
                case 2:
                    Console.WriteLine("Martes");
                    break;
                case 3:
                    Console.WriteLine("Miércoles");
                    break;
                case 4:
                    Console.WriteLine("Jueves");
                    break;
                case 5:
                    Console.WriteLine("Viernes");
                    break;
                case 6:
                    Console.WriteLine("Sábado");
                    break;
                case 7:
                    Console.WriteLine("Domingo");
                    break;
                default:
                    Console.WriteLine("Introduce un número válido");
                    break;
            }
        }
    }
}