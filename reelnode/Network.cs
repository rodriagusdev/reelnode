namespace Reelnode
{
    public class Network
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Network(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
