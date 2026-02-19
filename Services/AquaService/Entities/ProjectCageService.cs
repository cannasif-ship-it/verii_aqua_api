using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Interfaces;
using aqua_api.Models;
using aqua_api.UnitOfWork;
using aqua_api.Helpers;
using Microsoft.EntityFrameworkCore;

namespace aqua_api.Services
{
    public class ProjectCageService : IProjectCageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public ProjectCageService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<ProjectCageDto>> GetByIdAsync(long id)
        {
            try
            {
                var entity = await _unitOfWork.Repository<ProjectCage>()
                    .Query()
                    .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

                if (entity == null)
                {
                    return ApiResponse<ProjectCageDto>.ErrorResult(
                        _localizationService.GetLocalizedString("ProjectCageService.NotFound"),
                        _localizationService.GetLocalizedString("ProjectCageService.NotFound"),
                        StatusCodes.Status404NotFound);
                }

                var dto = _mapper.Map<ProjectCageDto>(entity);
                return ApiResponse<ProjectCageDto>.SuccessResult(dto, _localizationService.GetLocalizedString("ProjectCageService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ProjectCageDto>.ErrorResult(
                    _localizationService.GetLocalizedString("ProjectCageService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<PagedResponse<ProjectCageDto>>> GetAllAsync(PagedRequest request)
        {
            try
            {
                request ??= new PagedRequest();
                request.Filters ??= new List<Filter>();

                var query = _unitOfWork.Repository<ProjectCage>()
                    .Query()
                    .Where(x => !x.IsDeleted)
                    .ApplyFilters(request.Filters, request.FilterLogic);

                var sortBy = string.IsNullOrWhiteSpace(request.SortBy) ? nameof(ProjectCage.Id) : request.SortBy;
                query = query.ApplySorting(sortBy, request.SortDirection);

                var totalCount = await query.CountAsync();

                var entities = await query
                    .ApplyPagination(request.PageNumber, request.PageSize)
                    .ToListAsync();

                var items = entities.Select(x => _mapper.Map<ProjectCageDto>(x)).ToList();

                var pagedResponse = new PagedResponse<ProjectCageDto>
                {
                    Items = items,
                    TotalCount = totalCount,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize
                };

                return ApiResponse<PagedResponse<ProjectCageDto>>.SuccessResult(
                    pagedResponse,
                    _localizationService.GetLocalizedString("ProjectCageService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<PagedResponse<ProjectCageDto>>.ErrorResult(
                    _localizationService.GetLocalizedString("ProjectCageService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ProjectCageDto>> CreateAsync(CreateProjectCageDto dto)
        {
            try
            {
                var entity = _mapper.Map<ProjectCage>(dto);
                await _unitOfWork.Repository<ProjectCage>().AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<ProjectCageDto>(entity);
                return ApiResponse<ProjectCageDto>.SuccessResult(result, _localizationService.GetLocalizedString("ProjectCageService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ProjectCageDto>.ErrorResult(
                    _localizationService.GetLocalizedString("ProjectCageService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ProjectCageDto>> UpdateAsync(long id, UpdateProjectCageDto dto)
        {
            try
            {
                var repo = _unitOfWork.Repository<ProjectCage>();
                var entity = await repo.GetByIdForUpdateAsync(id);

                if (entity == null)
                {
                    return ApiResponse<ProjectCageDto>.ErrorResult(
                        _localizationService.GetLocalizedString("ProjectCageService.NotFound"),
                        _localizationService.GetLocalizedString("ProjectCageService.NotFound"),
                        StatusCodes.Status404NotFound);
                }

                _mapper.Map(dto, entity);
                await repo.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<ProjectCageDto>(entity);
                return ApiResponse<ProjectCageDto>.SuccessResult(result, _localizationService.GetLocalizedString("ProjectCageService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ProjectCageDto>.ErrorResult(
                    _localizationService.GetLocalizedString("ProjectCageService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<bool>> SoftDeleteAsync(long id)
        {
            try
            {
                var repo = _unitOfWork.Repository<ProjectCage>();
                var isDeleted = await repo.SoftDeleteAsync(id);

                if (!isDeleted)
                {
                    return ApiResponse<bool>.ErrorResult(
                        _localizationService.GetLocalizedString("ProjectCageService.NotFound"),
                        _localizationService.GetLocalizedString("ProjectCageService.NotFound"),
                        StatusCodes.Status404NotFound);
                }

                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResult(true, _localizationService.GetLocalizedString("ProjectCageService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult(
                    _localizationService.GetLocalizedString("ProjectCageService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }
    }
}
