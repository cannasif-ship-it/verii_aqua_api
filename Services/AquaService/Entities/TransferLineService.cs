using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Interfaces;
using aqua_api.Models;
using aqua_api.UnitOfWork;
using aqua_api.Helpers;
using Microsoft.EntityFrameworkCore;

namespace aqua_api.Services
{
    public class TransferLineService : ITransferLineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public TransferLineService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<TransferLineDto>> GetByIdAsync(long id)
        {
            try
            {
                var entity = await _unitOfWork.TransferLines
                    .Query()
                    .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

                if (entity == null)
                {
                    return ApiResponse<TransferLineDto>.ErrorResult(
                        _localizationService.GetLocalizedString("TransferLineService.NotFound"),
                        _localizationService.GetLocalizedString("TransferLineService.NotFound"),
                        StatusCodes.Status404NotFound);
                }

                var dto = _mapper.Map<TransferLineDto>(entity);
                return ApiResponse<TransferLineDto>.SuccessResult(dto, _localizationService.GetLocalizedString("TransferLineService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<TransferLineDto>.ErrorResult(
                    _localizationService.GetLocalizedString("TransferLineService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<PagedResponse<TransferLineDto>>> GetAllAsync(PagedRequest request)
        {
            try
            {
                request ??= new PagedRequest();
                request.Filters ??= new List<Filter>();

                var query = _unitOfWork.TransferLines
                    .Query()
                    .Where(x => !x.IsDeleted)
                    .ApplyFilters(request.Filters, request.FilterLogic);

                var sortBy = string.IsNullOrWhiteSpace(request.SortBy) ? nameof(TransferLine.Id) : request.SortBy;
                query = query.ApplySorting(sortBy, request.SortDirection);

                var totalCount = await query.CountAsync();

                var entities = await query
                    .ApplyPagination(request.PageNumber, request.PageSize)
                    .ToListAsync();

                var items = entities.Select(x => _mapper.Map<TransferLineDto>(x)).ToList();

                var pagedResponse = new PagedResponse<TransferLineDto>
                {
                    Items = items,
                    TotalCount = totalCount,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize
                };

                return ApiResponse<PagedResponse<TransferLineDto>>.SuccessResult(
                    pagedResponse,
                    _localizationService.GetLocalizedString("TransferLineService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<PagedResponse<TransferLineDto>>.ErrorResult(
                    _localizationService.GetLocalizedString("TransferLineService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<TransferLineDto>> CreateAsync(CreateTransferLineDto dto)
        {
            try
            {
                var entity = _mapper.Map<TransferLine>(dto);
                await _unitOfWork.TransferLines.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<TransferLineDto>(entity);
                return ApiResponse<TransferLineDto>.SuccessResult(result, _localizationService.GetLocalizedString("TransferLineService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<TransferLineDto>.ErrorResult(
                    _localizationService.GetLocalizedString("TransferLineService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<TransferLineDto>> UpdateAsync(long id, UpdateTransferLineDto dto)
        {
            try
            {
                var repo = _unitOfWork.TransferLines;
                var entity = await repo.GetByIdForUpdateAsync(id);

                if (entity == null)
                {
                    return ApiResponse<TransferLineDto>.ErrorResult(
                        _localizationService.GetLocalizedString("TransferLineService.NotFound"),
                        _localizationService.GetLocalizedString("TransferLineService.NotFound"),
                        StatusCodes.Status404NotFound);
                }

                _mapper.Map(dto, entity);
                await repo.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<TransferLineDto>(entity);
                return ApiResponse<TransferLineDto>.SuccessResult(result, _localizationService.GetLocalizedString("TransferLineService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<TransferLineDto>.ErrorResult(
                    _localizationService.GetLocalizedString("TransferLineService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<bool>> SoftDeleteAsync(long id)
        {
            try
            {
                var repo = _unitOfWork.TransferLines;
                var isDeleted = await repo.SoftDeleteAsync(id);

                if (!isDeleted)
                {
                    return ApiResponse<bool>.ErrorResult(
                        _localizationService.GetLocalizedString("TransferLineService.NotFound"),
                        _localizationService.GetLocalizedString("TransferLineService.NotFound"),
                        StatusCodes.Status404NotFound);
                }

                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResult(true, _localizationService.GetLocalizedString("TransferLineService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult(
                    _localizationService.GetLocalizedString("TransferLineService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }
    }
}
