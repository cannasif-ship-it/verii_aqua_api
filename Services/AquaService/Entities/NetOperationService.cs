using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Infrastructure.Time;
using aqua_api.Interfaces;
using aqua_api.Models;
using aqua_api.UnitOfWork;
using aqua_api.Helpers;
using Microsoft.EntityFrameworkCore;

namespace aqua_api.Services
{
    public class NetOperationService : INetOperationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INetOperationRepository _netOperationRepository;
        private readonly IBalanceLedgerManager _balanceLedgerManager;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public NetOperationService(
            IUnitOfWork unitOfWork,
            INetOperationRepository netOperationRepository,
            IBalanceLedgerManager balanceLedgerManager,
            IMapper mapper,
            ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _netOperationRepository = netOperationRepository;
            _balanceLedgerManager = balanceLedgerManager;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<NetOperationDto>> GetByIdAsync(long id)
        {
            try
            {
                var entity = await _unitOfWork.Repository<NetOperation>()
                    .Query()
                    .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

                if (entity == null)
                {
                    return ApiResponse<NetOperationDto>.ErrorResult(
                        _localizationService.GetLocalizedString("NetOperationService.NotFound"),
                        _localizationService.GetLocalizedString("NetOperationService.NotFound"),
                        StatusCodes.Status404NotFound);
                }

                var dto = _mapper.Map<NetOperationDto>(entity);
                return ApiResponse<NetOperationDto>.SuccessResult(dto, _localizationService.GetLocalizedString("NetOperationService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<NetOperationDto>.ErrorResult(
                    _localizationService.GetLocalizedString("NetOperationService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<PagedResponse<NetOperationDto>>> GetAllAsync(PagedRequest request)
        {
            try
            {
                request ??= new PagedRequest();
                request.Filters ??= new List<Filter>();

                var query = _unitOfWork.Repository<NetOperation>()
                    .Query()
                    .Where(x => !x.IsDeleted)
                    .ApplyFilters(request.Filters, request.FilterLogic);

                var sortBy = string.IsNullOrWhiteSpace(request.SortBy) ? nameof(NetOperation.Id) : request.SortBy;
                query = query.ApplySorting(sortBy, request.SortDirection);

                var totalCount = await query.CountAsync();

                var entities = await query
                    .ApplyPagination(request.PageNumber, request.PageSize)
                    .ToListAsync();

                var items = entities.Select(x => _mapper.Map<NetOperationDto>(x)).ToList();

                var pagedResponse = new PagedResponse<NetOperationDto>
                {
                    Items = items,
                    TotalCount = totalCount,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize
                };

                return ApiResponse<PagedResponse<NetOperationDto>>.SuccessResult(
                    pagedResponse,
                    _localizationService.GetLocalizedString("NetOperationService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<PagedResponse<NetOperationDto>>.ErrorResult(
                    _localizationService.GetLocalizedString("NetOperationService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<NetOperationDto>> CreateAsync(CreateNetOperationDto dto)
        {
            try
            {
                var entity = _mapper.Map<NetOperation>(dto);
                await _unitOfWork.Repository<NetOperation>().AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<NetOperationDto>(entity);
                return ApiResponse<NetOperationDto>.SuccessResult(result, _localizationService.GetLocalizedString("NetOperationService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<NetOperationDto>.ErrorResult(
                    _localizationService.GetLocalizedString("NetOperationService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<NetOperationDto>> UpdateAsync(long id, UpdateNetOperationDto dto)
        {
            try
            {
                var repo = _unitOfWork.Repository<NetOperation>();
                var entity = await repo.GetByIdForUpdateAsync(id);

                if (entity == null)
                {
                    return ApiResponse<NetOperationDto>.ErrorResult(
                        _localizationService.GetLocalizedString("NetOperationService.NotFound"),
                        _localizationService.GetLocalizedString("NetOperationService.NotFound"),
                        StatusCodes.Status404NotFound);
                }

                _mapper.Map(dto, entity);
                await repo.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<NetOperationDto>(entity);
                return ApiResponse<NetOperationDto>.SuccessResult(result, _localizationService.GetLocalizedString("NetOperationService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<NetOperationDto>.ErrorResult(
                    _localizationService.GetLocalizedString("NetOperationService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<bool>> SoftDeleteAsync(long id)
        {
            try
            {
                var repo = _unitOfWork.Repository<NetOperation>();
                var isDeleted = await repo.SoftDeleteAsync(id);

                if (!isDeleted)
                {
                    return ApiResponse<bool>.ErrorResult(
                        _localizationService.GetLocalizedString("NetOperationService.NotFound"),
                        _localizationService.GetLocalizedString("NetOperationService.NotFound"),
                        StatusCodes.Status404NotFound);
                }

                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResult(true, _localizationService.GetLocalizedString("NetOperationService.OperationSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult(
                    _localizationService.GetLocalizedString("NetOperationService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<bool>> Post(long netOperationId, long userId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var operation = await _netOperationRepository.GetForPost(netOperationId)
                    ?? throw new InvalidOperationException("Net operation not found.");

                EnsureDraftStatus(operation.Status, nameof(NetOperation));

                foreach (var line in operation.Lines.Where(x => !x.IsDeleted && x.FishBatchId.HasValue))
                {
                    var signedBiomass = Math.Round(line.Quantity * (line.UnitGram ?? 0m), 3, MidpointRounding.AwayFromZero);

                    await _balanceLedgerManager.ApplyDelta(
                        operation.ProjectId,
                        line.FishBatchId!.Value,
                        line.ProjectCageId,
                        0,
                        signedBiomass,
                        BatchMovementType.Adjustment,
                        operation.OperationDate,
                        "Net operation adjustment",
                        "RII_NetOperation",
                        operation.Id,
                        line.ProjectCageId,
                        line.ProjectCageId,
                        null,
                        null,
                        null,
                        null);
                }

                operation.Status = DocumentStatus.Posted;
                operation.UpdatedBy = userId;
                operation.UpdatedDate = DateTimeProvider.UtcNow;

                await _unitOfWork.SaveChanges();
                await _unitOfWork.Commit();

                return ApiResponse<bool>.SuccessResult(
                    true,
                    _localizationService.GetLocalizedString("NetOperationService.OperationSuccessful"));
            }
            catch (InvalidOperationException ex)
            {
                await _unitOfWork.Rollback();
                return ApiResponse<bool>.ErrorResult(
                    _localizationService.GetLocalizedString("NetOperationService.BusinessRuleError"),
                    ex.Message,
                    StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                return ApiResponse<bool>.ErrorResult(
                    _localizationService.GetLocalizedString("NetOperationService.InternalServerError"),
                    ex.Message,
                    StatusCodes.Status500InternalServerError);
            }
        }

        private static void EnsureDraftStatus(DocumentStatus status, string documentName)
        {
            if (status != DocumentStatus.Draft)
                throw new InvalidOperationException($"{documentName} must be Draft before posting.");
        }

    }
}
