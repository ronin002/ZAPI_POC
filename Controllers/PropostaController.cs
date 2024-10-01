using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZurichAPI.Model.Dto;
using ZurichAPI.Model.Entity;
using ZurichAPI.Repository;
using ZurichAPI.Utils;

namespace ZurichAPI.Controllers
{
    [ApiController]
    public class PropostaController : BaseController
    {
        private readonly ILogger<PropostaController> _logger;


        public PropostaController(ILogger<PropostaController> logger,
                                IUserRepository userRepository,
                                IRoleRepository roleRepository) : base( userRepository,
                                                                        roleRepository)
        {
            _logger = logger;
        }

        [HttpGet("api/v1/proposta/cpf")]
        public Proposta GetPropostaByCPF([FromBody] GetPropostaByCpfDto getPropostaByCpfDto)
        {
            throw new NotImplementedException();
        }

        [HttpGet("api/v1/proposta/")]
        public Proposta GetPropostaById([FromBody] GetPropostaByIdDto getPropostaByIdDto)
        {
            throw new NotImplementedException();
        }

        [HttpGet("api/v1/proposta/pendentes")]
        public List<Proposta> GetPropostasPendentes()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("api/v1/proposta")]
        public bool Remove([FromBody] GetPropostaByIdDto getPropostaByIdDto)
        {
            throw new NotImplementedException();
        }

        [HttpPost("api/v1/proposta")]
        public bool Save(Proposta proposta)
        {
            throw new NotImplementedException();
        }

        [HttpPut("api/v1/proposta")]
        public Proposta UpdateProposta(Proposta proposta)
        {
            throw new NotImplementedException();
        }
    }
}
