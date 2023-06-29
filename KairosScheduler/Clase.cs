namespace KairosScheduler
{
    public class Clase
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public ClaseData[] Horarios { get; set; }
        public byte Creditos { get; set; }

        public Clase()
        {
            Horarios = new ClaseData[0];
        }

    }

}