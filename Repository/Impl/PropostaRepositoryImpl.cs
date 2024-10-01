using ZurichAPI.Data;
using ZurichAPI.Model.Entity;

namespace ZurichAPI.Repository.Impl
{
    public class PropostaRepositoryImpl : IPropostaRepository
    {
        private readonly DataContext _context;
        public PropostaRepositoryImpl(DataContext context)
        {
            _context = context;
        }

        public Proposta GetPropostaByCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public Proposta GetPropostaById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Proposta> GetPropostasPendentes()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Proposta proposta)
        {
            throw new NotImplementedException();
        }

        public bool Save(Proposta proposta)
        {
            throw new NotImplementedException();
        }

        public Proposta UpdateProposta(Proposta proposta)
        {
            throw new NotImplementedException();
        }
    }
}
