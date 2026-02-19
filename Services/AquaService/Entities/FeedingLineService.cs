using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Interfaces;
using aqua_api.Models;
using aqua_api.UnitOfWork;
using aqua_api.Helpers;
using Microsoft.EntityFrameworkCore;

namespace aqua_api.Services
{
    public class FeedingLineService : IFeedingLineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public FeedingLineService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<FeedingLineDto>> GetByIdAsync(long id)
        {
            try
            {
                var entity = await _unitOfWork.Repository<FeedingLine>()
                    .Query()
                    .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

                if (entity == null)
                {
                    return ApiResponse<FeedingLineDto>.ErrorResult(
                        _localizationService.GetLocalizedString("FeedingLineService.NotFound"),
                        _localizationService.GetLocalizedString("FeedingLineService.NotFound"),
                        StatusCodes.Status404NotFound);
                }

                var dto = _mapper.Map<FeedingLineDto>(entity);
                return ApiResponse<FeedingLineDto>.SuccessResult(dto, _localizationService.GetLocalizedString("FeedingLineService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<FeedingLineDto>.ErrorResult(
                    _localizationService.GetLocalizedString("FeedingLineService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<PagedResponse<FeedingLineDto>>> GetAllAsync(PagedRequest request)
        {
            try
            {
                request ??= new PagedRequest();
                request.Filters ??= new List<Filter>();

                var query = _unitOfWork.Repository<FeedingLine>()
                    .Query()
                    .Where(x => !x.IsDeleted)
                    .ApplyFilters(request.Filters, request.FilterLogic);

                var sortBy = string.IsNullOrWhiteSpace(request.SortBy) ? nameof(FeedingLine.Id) : request.SortBy;
                query = query.ApplySorting(sortBy, request.SortDirection);

                var totalCount = await query.CountAsync();

                var entities = await query
                    .ApplyPagination(request.PageNumber, request.PageSize)
                    .ToListAsync();

                var items = entities.Select(x => _mapper.Map<FeedingLineDto>(x)).ToList();

                var pagedResponse = new PagedResponse<FeedingLineDto>
                {
                    Items = items,
                    TotalCount = totalCount,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize
                };

                return ApiResponse<PagedResponse<FeedingLineDto>>.SuccessResult(
                    pagedResponse,
                    _localizationService.GetLocalizedString("FeedingLineService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<PagedResponse<FeedingLineDto>>.ErrorResult(
                    _localizationService.GetLocalizedString("FeedingLineService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<FeedingLineDto>> CreateAsync(CreateFeedingLineDto dto)
        {
            try
            {
                var entity = _mapper.Map<FeedingLine>(dto);
                await _unitOfWork.Repository<FeedingLine>().AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<FeedingLineDto>(entity);
                return ApiResponse<FeedingLineDto>.SuccessResult(result, _localizationService.GetLocalizedString("FeedingLineService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<FeedingLineDto>.ErrorResult(
                    _localizationService.GetLocalizedString("FeedingLineService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<FeedingLineDto>> UpdateAsync(long id, UpdateFeedingLineDto dto)
        {
            try
            {
                var repo = _unitOfWork.Repository<FeedingLine>();
                var entity = await repo.GetByIdForUpdateAsync(id);

                if (entity == null)
                {
                    return ApiResponse<FeedingLineDto>.ErrorResult(
                        _localizationService.GetLocalizedString("FeedingLineService.NotFound"),
                        _localizationService.GetLocalizedString("FeedingLineService.NotFound"),
                        StatusCodes.Status404NotFound);
                }

                _mapper.Map(dto, entity);
                await repo.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<FeedingLineDto>(entity);
                return ApiResponse<FeedingLineDto>.SuccessResult(result, _localizationService.GetLocalizedString("FeedingLineService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<FeedingLineDto>.ErrorResult(
                    _localizationService.GetLocalizedString("FeedingLineService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<bool>> SoftDeleteAsync(long id)
        {
            try
            {
                var repo = _unitOfWork.Repository<FeedingLine>();
                var isDeleted = await repo.SoftDeleteAsync(id);

                if (!isDeleted)
                {
                    return ApiResponse<bool>.ErrorResult(
                        _localizationService.GetLocalizedString("FeedingLineService.NotFound"),
                        _localizationService.GetLocalizedString("FeedingLineService.NotFound"),
                        StatusCodes.Status404NotFound);
                }

                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResult(true, _localizationService.GetLocalizedString("FeedingLineService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult(
                    _localizationService.GetLocalizedString("FeedingLineService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }
    }
}
