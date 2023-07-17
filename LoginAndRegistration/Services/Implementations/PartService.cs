using AutoMapper;
using EasyForm.Entities;
using EasyForm.Services.Contracts;
using EasyForm.Stores.Contracts;
using EasyForm.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyForm.Services.Implementations
{
    public class PartService : IPartService
    {
        private readonly IPartStore _partStore;
        private readonly IQuestionStore _questionStore;
        private readonly IMapper _mapper;

        public PartService(IPartStore partStore, IMapper mapper, IQuestionStore questionStore)
        {
            _partStore = partStore;
            _mapper = mapper;
            _questionStore = questionStore;
        }

        public async Task<bool> AddApplicationPartAsync(ApplicationPart applicationPart)
        {
            return await _partStore.AddApplicationPartAsync(applicationPart);
        }

        public async Task<bool> DeleteApplicationPartAsync(int id)
        {
            var hasQuestion = await _questionStore.HasAnyQuestion(id);
            if (!hasQuestion)
            {
                return await _partStore.DeleteApplicationPartAsync(id);
            }
            else
            {
                return false;
            }
        }

        public async Task<ApplicationPart> GetApplicationPartAsync(int id)
        {
            return await _partStore.GetApplicationPartAsync(id);
        }

        public async Task<GetApplicationPartVm> GetApplicationPartsAsync(int applicationId)
        {
            var response = await _partStore.GetApplicationPartsAsync(applicationId);

            var parts = _mapper.Map<List<ApplicationPartVm>>(response);
            return new GetApplicationPartVm { ApplicationId = applicationId, Parts = parts };
        }

        public async Task<GetApplicationPartVm> GetApplicationPartsAsync()
        {
            var response = await _partStore.GetApplicationPartsAsync();
            var parts = _mapper.Map<List<ApplicationPartVm>>(response);
            return new GetApplicationPartVm { ApplicationId = 0, Parts = parts };
        }

        public async Task<List<ApplicationPart>> GetPartListAsync()
        {
            return await _partStore.GetApplicationPartsAsync();
        }

        public async Task<bool> UpdateApplicationPartAsync(ApplicationPart applicationPart)
        {
            return await _partStore.UpdateApplicationPartAsync(applicationPart);
        }
    }
}
