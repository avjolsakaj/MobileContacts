using MC.DTO;
using MC.IBLL.IMappers;
using MC.IBLL.IServices;
using MC.IDAL.Repositories;
using MC.IDAL.UOW;
using System.Threading.Tasks;

namespace MC.BLL.Services
{
    public class TestService : ITestService
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly ITestMapper _mapper;

        private readonly ITestRepository _repository;

        //public TestService(IUnitOfWork unitOfWork, ITestMapper mapper)
        //{
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper;
        //}

        public TestService(ITestRepository repository, ITestMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TestDTO?> Get()
        {
            //var testModel = await _unitOfWork.TestRepository.GetFirst().ConfigureAwait(false);
            var testModel = await _repository.GetFirst().ConfigureAwait(false);

            return _mapper.Convert(testModel);
        }
    }
}
