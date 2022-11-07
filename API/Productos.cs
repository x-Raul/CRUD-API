namespace API
{
    public class Productos
    {
        public int Id { get; set; }
        public string Prod_Nom { get; set; }
        public string Prod_Desc { get; set; } = String.Empty;
        public int Cat_Fk { get; set; }
    }
}
