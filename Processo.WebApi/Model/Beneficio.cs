namespace Processo.WebApi.Model
{
    public class Beneficio
    {
        public int Id { get; set; }
        public TipoBeneficio TipoBeneficio { get; set; }
        public Beneficiario Beneficiario { get; set; }
    }
}
