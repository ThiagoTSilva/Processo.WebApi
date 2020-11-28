namespace Processo.WebApi.Model
{
    public class Documento
    {
        public int Id { get; set; }
        public byte[] Arquivo { get; set; }
        public Beneficiario Beneficiario { get; set; }
    }
}
